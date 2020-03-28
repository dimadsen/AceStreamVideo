using System;
using CoreAnimation;
using CoreGraphics;
using Foundation;
using UIKit;

namespace AceStream.Additionals
{
    public static class GradientColor
    {
        public static CALayer CloudyApple(nfloat width, nfloat height)
        {
            var top = UIColor.FromRGB(243, 231, 233).CGColor;
            var bottom = UIColor.FromRGB(227,238,255).CGColor;

            var gradientlayer = new CAGradientLayer()
            {
                Colors = new CGColor[] { top, bottom },
                Locations = new NSNumber[] { 0.0, 1.0 },
                Frame = new CGRect(0, 0, width, height),
                StartPoint = new CGPoint(0, 1),
                EndPoint = new CGPoint(1, 1)
            };

            return gradientlayer;
        }

        public static CALayer MagicLake(nfloat width, nfloat height)
        {
            var top = UIColor.FromRGB(213,222,231).CGColor;
            var bottom = UIColor.FromRGB(255, 175, 189).CGColor;
            var bpttom2 = UIColor.FromRGB(201, 255, 191).CGColor;

            var gradientlayer = new CAGradientLayer()
            {
                Colors = new CGColor[] { top, bottom, bpttom2 },
                Locations = new NSNumber[] { 0.0, 1.0 },
                Frame = new CGRect(0, 0, width, height),
                StartPoint = new CGPoint(0, 1),
                EndPoint = new CGPoint(1, 1)
            };

            return gradientlayer;
        }

        public static CALayer SoftGrass(nfloat width, nfloat height)
        {
            var top = UIColor.FromRGB(193, 223, 196).CGColor;
            var bottom = UIColor.FromRGB(222, 236, 221).CGColor;

            var gradientlayer = new CAGradientLayer()
            {
                Colors = new CGColor[] { top, bottom },
                Locations = new NSNumber[] { 0.0, 1.0 },
                Frame = new CGRect(0, 0, width, height),
                StartPoint = new CGPoint(0, 1),
                EndPoint = new CGPoint(1, 1)
            };

            return gradientlayer;
        }

        public static CALayer AquaSplash(nfloat width, nfloat height)
        {
            var top = UIColor.FromRGB(19, 84, 122).CGColor;
            var bottom = UIColor.FromRGB(128, 208, 199).CGColor;

            var gradientlayer = new CAGradientLayer()
            {
                Colors = new CGColor[] { top, bottom },
                Locations = new NSNumber[] { 0.0, 1.0 },
                Frame = new CGRect(0, 0, width, height),
                StartPoint = new CGPoint(0, 1),
                EndPoint = new CGPoint(1, 1)
            };

            return gradientlayer;
        }

        public static CALayer RipeMalinka(nfloat width, nfloat height)
        {
            var top = UIColor.FromRGB(240, 147, 251).CGColor;
            var bottom = UIColor.FromRGB(245, 87, 108).CGColor;

            var gradientlayer = new CAGradientLayer()
            {
                Colors = new CGColor[] { top, bottom },
                Locations = new NSNumber[] { 0.0, 1.0 },
                Frame = new CGRect(0, 0, width, height),
                StartPoint = new CGPoint(0, 1),
                EndPoint = new CGPoint(1, 1)
            };

            return gradientlayer;
        }
        public static CALayer ConfidentCloud(nfloat width, nfloat height)
        {
            var top = UIColor.FromRGB(218, 212, 236).CGColor;
            var bottom = UIColor.FromRGB(243, 231, 233).CGColor;

            var gradientlayer = new CAGradientLayer()
            {
                Colors = new CGColor[] { top, bottom },
                Locations = new NSNumber[] { 0.0, 1.0 },
                Frame = new CGRect(0, 0, width, height),
                StartPoint = new CGPoint(0, 1),
                EndPoint = new CGPoint(1, 1)
            };

            return gradientlayer;
        }

        public static CALayer GlassWater(nfloat width, nfloat height)
        {
            var top = UIColor.FromRGB(223, 233, 243).CGColor;
            var bottom = UIColor.FromRGB(255, 255, 255).CGColor;

            var gradientlayer = new CAGradientLayer()
            {
                Colors = new CGColor[] { top, bottom },
                Locations = new NSNumber[] { 0.0, 1.0 },
                Frame = new CGRect(0, 0, width, height),
                StartPoint = new CGPoint(0, 1),
                EndPoint = new CGPoint(1, 1)
            };

            return gradientlayer;
        }

        public static CALayer PaloAlto(nfloat width, nfloat height)
        {
            var top = UIColor.FromRGB(22, 160, 133).CGColor;
            var bottom = UIColor.FromRGB(141, 150, 33).CGColor;

            var gradientlayer = new CAGradientLayer()
            {
                Colors = new CGColor[] { top, bottom },
                Locations = new NSNumber[] { 0.0, 1.0 },
                Frame = new CGRect(0, 0, width, height),
                StartPoint = new CGPoint(0, 1),
                EndPoint = new CGPoint(1, 1)
            };

            return gradientlayer;
        }

        public static CALayer ShowAgain(nfloat width, nfloat height)
        {
            var top = UIColor.FromRGB(230, 233, 240).CGColor;
            var bottom = UIColor.FromRGB(238, 241, 245).CGColor;

            var gradientlayer = new CAGradientLayer()
            {
                Colors = new CGColor[] { top, bottom },
                Locations = new NSNumber[] { 0.0, 1.0 },
                Frame = new CGRect(0, 0, width, height),
                StartPoint = new CGPoint(0, 1),
                EndPoint = new CGPoint(1, 1)
            };

            return gradientlayer;
        }
    }
}
