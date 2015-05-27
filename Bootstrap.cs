using Ionic.Zip;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

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
          const string downloadUrl = "https://github.com/lukevenediger/champ-bootstrap/releases/download/v1.0/champ-bootstrap.zip";
        Console.WriteLine("Downloading champ-bootstrap.zip (github.com)");
        try
        {
          client.DownloadFile(downloadUrl, targetFile);
        }
        catch (System.Net.WebException e)
        {
          Console.WriteLine("Cannot download bootstrap. Reason: {0}.\nYou might want to manually download it from ({1}) and then use -s option", e.Message, downloadUrl);
          return;
        }
      }
      else
      {
        var file = new FileInfo(_uncLocation);
        Console.WriteLine("Copying " + file.Name + " from " + file.Directory.FullName);
        file.CopyTo(targetFile, true);
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
