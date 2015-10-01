
using System;
using System.IO;
using Microsoft.Synchronization;
using Microsoft.Synchronization.Files;

public class FileSync
{
    //public static void Main(string[] args)
    //private string _destDir;

    //public string DestDir
    //{
    //    get { return _destDir; }
    //    set { _destDir = value; }
    
    //}

    // create logger, filter
    public  void Backup(string srcDir)
    {
        if (!Directory.Exists(srcDir ))
        {
            throw  new  InvalidDataException();
            return;
        }

        string replica1RootPath = srcDir;
        string apath = srcDir.Replace(":", "XVN");
        string replica2RootPath = Path.Combine(@"\\192.168.0.210\Dir1", apath); 

        try
        {
            // If the dest dir does not exist, then create
            if (!Directory.Exists(replica2RootPath))
            {
                Directory.CreateDirectory(replica2RootPath);
            }

            // Set options for the sync operation
            FileSyncOptions options = FileSyncOptions.ExplicitDetectChanges |
                     FileSyncOptions.RecycleDeletedFiles | FileSyncOptions.RecyclePreviousFileOnUpdates | FileSyncOptions.RecycleConflictLoserFiles;

            FileSyncScopeFilter filter = new FileSyncScopeFilter();
            filter.FileNameExcludes.Add("*.lnk"); // Exclude all *.lnk files

            // Explicitly detect changes on both replicas upfront, to avoid two change 
            // detection passes for the two-way sync
            // Above not necessary, sync in one direction only
            DetectChangesOnFileSystemReplica(replica1RootPath, filter, options);
            DetectChangesOnFileSystemReplica(replica2RootPath, filter, options);

            // Sync in one  direction only
            SyncFileSystemReplicasOneWay(replica1RootPath, replica2RootPath, null, options);
            //SyncFileSystemReplicasOneWay(replica2RootPath, replica1RootPath, null, options);
        }
        catch (Exception e)
        {
            Console.WriteLine("\nException from File Sync Provider:\n" + e.ToString());
        }
    }

    public static void DetectChangesOnFileSystemReplica(
            string replicaRootPath,
            FileSyncScopeFilter filter, FileSyncOptions options)
    {
        FileSyncProvider provider = null;

        try
        {
            provider = new FileSyncProvider(replicaRootPath, filter, options);
            provider.DetectChanges();
        }
        finally
        {
            // Release resources
            if (provider != null)
                provider.Dispose(); 
        }
    }

    public static void SyncFileSystemReplicasOneWay(
            string sourceReplicaRootPath, string destinationReplicaRootPath,
            FileSyncScopeFilter filter, FileSyncOptions options)
    {
        FileSyncProvider sourceProvider = null;
        FileSyncProvider destinationProvider = null;

        try
        {
            sourceProvider = new FileSyncProvider(
                sourceReplicaRootPath, filter, options);
            destinationProvider = new FileSyncProvider(
                destinationReplicaRootPath, filter, options);

            destinationProvider.AppliedChange += 
                new EventHandler<AppliedChangeEventArgs>(OnAppliedChange);
            destinationProvider.SkippedChange += 
                new EventHandler<SkippedChangeEventArgs>(OnSkippedChange);

            SyncOrchestrator agent = new SyncOrchestrator();
            agent.LocalProvider = sourceProvider;
            agent.RemoteProvider = destinationProvider;
            agent.Direction = SyncDirectionOrder.Upload; // Sync source to destination

            Console.WriteLine("Synchronizing changes to replica: " + 
                destinationProvider.RootDirectoryPath);
            agent.Synchronize();
        }
        finally
        {
            // Release resources
            if (sourceProvider != null) sourceProvider.Dispose(); 
            if (destinationProvider != null) destinationProvider.Dispose();
        }
    }

    public static void OnAppliedChange(object sender, AppliedChangeEventArgs args)
    {
        switch(args.ChangeType)
        {
            case ChangeType.Create: 
               Console.WriteLine("-- Applied CREATE for file " + args.NewFilePath); 
               break;
            case ChangeType.Delete:
               Console.WriteLine("-- Applied DELETE for file " + args.OldFilePath); 
               break;
            case ChangeType.Update:
               Console.WriteLine("-- Applied OVERWRITE for file " + args.OldFilePath); 
               break;
            case ChangeType.Rename:
               Console.WriteLine("-- Applied RENAME for file " + args.OldFilePath + 
                                 " as " + args.NewFilePath); 
               break;
        }
    }

    public static void OnSkippedChange(object sender, SkippedChangeEventArgs args)
    {
        Console.WriteLine("-- Skipped applying " + args.ChangeType.ToString().ToUpper() 
              + " for " + (!string.IsNullOrEmpty(args.CurrentFilePath) ? 
                            args.CurrentFilePath : args.NewFilePath) + " due to error");
              
        if (args.Exception != null)
            Console.WriteLine("   [" + args.Exception.Message + "]");
    }
}
