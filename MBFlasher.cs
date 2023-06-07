using System.Text;

namespace MicroBitAutoFlasher
{
    public partial class MBFlasher : Form
    {
        string downloadsPath;
        bool mbDetected = false;
        FileSystemWatcher watcher;
        string mbPath;
        Dictionary<string, bool> ignoreFileList;

        public MBFlasher()
        {
            InitializeComponent();
            downloadsPath = KnownFolders.GetPath(KnownFolder.Downloads);
            watcher = new FileSystemWatcher();
            watcher.NotifyFilter = NotifyFilters.LastWrite;
            watcher.Changed += OnNewFileDetected;

            CodePagesEncodingProvider.Instance.GetEncoding(850);
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            lstLog.Items.Add("Leave this program running while you use an online code editor for the micro:bit");
            lstLog.Items.Add("This program will scan your downloads folder for any .hex files that you save.");
            lstLog.Items.Add("If a micro:bit is plugged in it will attempt to copy it automatically");

            StartWatchingFiles(downloadsPath, "*.hex");
        }

        private bool DetectMicrobit()
        {
            try
            {
                DriveInfo[] drives = DriveInfo.GetDrives();
                for (int i = 0; i < drives.Count(); i++)
                {
                    if (drives[i].VolumeLabel == "MICROBIT")
                    {
                        mbPath = drives[i].Name;
                        mbDetected = true;
                        return mbDetected;
                    }
                }
            } catch (Exception ex)
            {
                lstLog.Items.Add($"Error scanning for micro:bit: {ex.Message}");
            }
            return false;

        }

        private void log(string message)
        {
            if (message != null)
            {
                lstLog.Invoke(() =>
                {
                    lstLog.Items.Add(message);
                    lstLog.TopIndex = lstLog.Items.Count - 1;
                });
            }
        }

        private void OnNewFileDetected(object source, FileSystemEventArgs e)
        {
            // only start processing file once, when it's been detected once already. Ignore all other times this file is detected
            if (ignoreFileList.ContainsKey(e.Name))
            {
                log($"Processing file {e.Name}");
            }
            else
            {
                ignoreFileList.Add(e.Name, true);
                log($"New hex file detected - waiting for file to be fully saved... {e.Name}");
                return;
            }

            // Only try to copy the file if a micro:bit has been detected
            if (!mbDetected)
            {
                log($"Ignoring because micro:bit not detected - is it plugged in?");
                return;
            }

            // copy the file
            RobustCopy.CopyFile(downloadsPath, e.Name, mbPath, (string msg) =>
            {
                log(msg);
                return 0;
            });
            log($"Done copying {e.Name} to {mbPath}");


        }

        private void StartWatchingFiles(string path, string filter)
        {
            watcher.Path = path;
            watcher.Filter = filter;
            watcher.EnableRaisingEvents = true;
            ignoreFileList = new Dictionary<string, bool>();
        }

        private void StopWatchingFiles()
        {
            watcher.EnableRaisingEvents = false;
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            string status = "";
            if (DetectMicrobit())
            {
                status = $"Microbit detected: {mbPath}";
            }
            else
            {
                status = "Microbit not detected";
            }
            status += watcher.EnableRaisingEvents ? $" watching {downloadsPath} for new .hex files" : " not watching for new hex files";
            statusLabel.Text = status;
        }


    }
}