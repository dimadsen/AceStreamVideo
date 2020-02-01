using System;
using CoreGraphics;
using UIKit;

namespace AceStream
{
    public static class NavigationItemImage
    {
        private static float ImageSizeForLargeState => 40;

        private static float ImageRightMargin => 16;

        private static float ImageBottomMarginForLargeState => 12;

        private static float ImageBottomMarginForSmallState => 6;

        private static float ImageSizeForSmallState => 32;

        private static float NavBarHeightSmallState => 44;

        private static float NavBarHeightLargeState => 96.5f;

        public static UIImageView ImageView { get; set; }

        public static readonly nint Tag = 1;
                
        static NavigationItemImage()
        {
            ImageView = new UIImageView { Tag = Tag };
            
            ImageView.Layer.CornerRadius = ImageSizeForLargeState / 2;
            ImageView.ClipsToBounds = true;
            ImageView.TranslatesAutoresizingMaskIntoConstraints = false;
        }

        public static void ActivateConstraints(UINavigationBar navigationBar)
        {
            NSLayoutConstraint.ActivateConstraints(new NSLayoutConstraint[]
            {
                ImageView.RightAnchor.ConstraintEqualTo(navigationBar.RightAnchor, -ImageRightMargin),
                ImageView.BottomAnchor.ConstraintEqualTo(navigationBar.BottomAnchor, -ImageBottomMarginForLargeState),
                ImageView.HeightAnchor.ConstraintEqualTo(ImageSizeForLargeState),
                ImageView.WidthAnchor.ConstraintEqualTo(ImageView.HeightAnchor)
            });
        }

        public static void ShowImage()
        {
            ImageView.Hidden = false;
        }

        public static void HiddenImage()
        {
            ImageView.Hidden = true;
        }

        public static void MoveAndResizeImage(nfloat height)
        {
            var coefficient = CalcCoefficient(height);

            var factor = ImageSizeForSmallState / ImageSizeForLargeState;

            var scale = CalcScale(coefficient, factor);

            var sizeDiff = ImageSizeForLargeState * (1.0 - factor);

            var yTranslation = CalcYTranslation(coefficient, sizeDiff);
            var xTranslation = new nfloat(Math.Max(0, sizeDiff - coefficient * sizeDiff));

            ImageView.Transform = SetTransform(scale, xTranslation, yTranslation);
        }

        private static nfloat CalcCoefficient(nfloat height)
        {
            var delta = height - NavBarHeightSmallState;
            var heightDifferenceBetweenStates = NavBarHeightLargeState - NavBarHeightSmallState;

            var coefficient = new nfloat(delta / heightDifferenceBetweenStates);

            return coefficient;
        }

        private static nfloat CalcScale(nfloat coefficient, nfloat factor)
        {
            var sizeAddendumFactor = coefficient * (1.0 - factor);

            var scale = new nfloat(Math.Min(1.0, sizeAddendumFactor + factor));

            return scale;
        }

        private static nfloat CalcYTranslation(nfloat coefficient, double sizeDiff)
        {
            var maxYTranslation = ImageBottomMarginForLargeState - ImageBottomMarginForSmallState + sizeDiff;
            var max = Math.Max(0, Math.Min(maxYTranslation, maxYTranslation - coefficient * (ImageBottomMarginForSmallState + sizeDiff)));

            var yTranslation = new nfloat(max);

            return yTranslation;
        }

        private static CGAffineTransform SetTransform(nfloat scale, nfloat xTranslation, nfloat yTranslation)
        {
            var transform = CGAffineTransform.MakeIdentity();
            transform.Scale(scale, scale);
            transform.Translate(xTranslation, yTranslation);

            return transform;
        }
    }
}
