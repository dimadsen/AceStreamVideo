using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CoreAnimation;
using CoreGraphics;
using Foundation;
using UIKit;

namespace AceStream.Utils
{
    public static class ImageUtils
    {
        public static UIImage GetGradientImage(CALayer gradient, CGSize size)
        {
            UIGraphics.BeginImageContext(size);
            var ctx = UIGraphics.GetCurrentContext();
            gradient.RenderInContext(ctx);

            var image = UIGraphics.GetImageFromCurrentImageContext();
            UIGraphics.EndImageContext();

            return image;
        }

        public static string DownloadFile(string fileName, string url)
        {
            var cachePath = GetCachePath(fileName);

            if (!File.Exists(cachePath))
            {
                SaveFileToCache(url, cachePath);
            }

            return cachePath;
        }

        private static string GetCachePath(string fileName)
        {
            var cachesFolder = NSSearchPath.GetDirectories(NSSearchPathDirectory.CachesDirectory, NSSearchPathDomain.User, true).FirstOrDefault();

            var cachePath = cachesFolder + "/" + fileName + ".png";

            return cachePath;
        }

        private static void SaveFileToCache(string url, string cachePath)
        {
            var download = Task.Run(async () => await NSUrlSession.SharedSession.CreateDownloadTaskAsync(new NSUrl(url)));

            try
            {
                var tempFile = download.Result.Location.AbsoluteUrl;

                var cacheUrl = NSUrl.CreateFileUrl(cachePath, false, null);

                NSFileManager.DefaultManager.Move(tempFile, cacheUrl, out NSError error);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }
}
