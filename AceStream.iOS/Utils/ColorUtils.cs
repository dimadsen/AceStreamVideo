using UIKit;

namespace AceStream.Utils
{
    public static class ColorUtils
    {
        public static UIColor GetInterfaceStyle(UIColor light, UIColor dark)
        {
            return new UIColor((UITraitCollection arg) =>
            {
                switch (arg.UserInterfaceStyle)
                {
                    case UIUserInterfaceStyle.Dark:
                        return dark;
                    default:
                        return light;
                }
            });
        }

        public static UIColor GetInterfaceStyle()
        {
            return new UIColor((UITraitCollection arg) =>
            {
                switch (arg.UserInterfaceStyle)
                {
                    case UIUserInterfaceStyle.Dark:
                        return UIColor.FromRGB(3, 218, 198);
                    default:
                        return UIColor.FromRGB(1, 135, 134);
                }
            });
        }

        public static UIColor GetInterfaceTextStyle()
        {
            return new UIColor((UITraitCollection arg) =>
            {
                switch (arg.UserInterfaceStyle)
                {
                    case UIUserInterfaceStyle.Dark:
                        return UIColor.FromRGB(240, 236, 236);
                    default:
                        return UIColor.FromRGB(30, 30, 30);
                }
            });
        }

        public static UIColor GetInterfaceImageStyle()
        {
            return new UIColor((UITraitCollection arg) =>
            {
                switch (arg.UserInterfaceStyle)
                {
                    case UIUserInterfaceStyle.Dark:
                        return UIColor.FromRGB(205, 205, 205);
                    default:
                        return UIColor.FromRGB(236, 236, 236);
                }
            });
        }
    }
}
