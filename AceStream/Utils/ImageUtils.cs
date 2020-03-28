using System;
using System.Drawing;
using CoreAnimation;
using CoreGraphics;
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
    }
}
