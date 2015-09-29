using System;
using System.IO;
using System.Net;
using Ionic.Zip;

namespace champ
{
    public class Bootstrap
    {
        private DirectoryInfo _source;
        private string _uncLocation;

        public Bootstrap(string sourceDirectory, string bootstrapUNCLocation)
        {
            _source = new DirectoryInfo(sourceDirectory);
            _uncLocation = bootstrapUNCLocation;
        }

        public void Run()
        {
            // Download the template
            var targetFile = Path.GetTempFileName();
            if (String.IsNullOrEmpty(_uncLocation))
            {
                var client = new WebClient();
                const string downloadUrl =
                    "https://github.com/lukevenediger/champ-bootstrap/archive/master.zip";
                Console.WriteLine("Downloading champ-bootstrap.zip (github.com)");
                try
                {
                    client.DownloadFile(downloadUrl, targetFile);
                }
                catch (WebException e)
                {
                    Console.WriteLine(
                        "Cannot download bootstrap. You might want to manually download it from ({1}) and then use -s option.\n" +
                        "Exception details: {0}",
                        e.Message, downloadUrl);
                    return;
                }
            }
            else
            {
                try
                {
                    var file = new FileInfo(_uncLocation);
                    Console.WriteLine("Copying " + file.Name + " from " + file.Directory.FullName);
                    file.CopyTo(targetFile, true);
                }
                catch (Exception e)
                {
                    Console.WriteLine(
                        "Cannot copy the bootstrap. Please make sure the file is spelled correctly, and is accessible.\n" +
                        "Exception details: {0}", e.Message);
                    return;
                }
            }
            // Unzip it to the source directory
            using (var zipFile = ZipFile.Read(targetFile))
            {
                zipFile.ExtractAll(_source.FullName, ExtractExistingFileAction.OverwriteSilently);
            }
            Console.WriteLine("Done.");
        }
    }
}
