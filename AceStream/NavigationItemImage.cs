using System;
using CoreGraphics;
using UIKit;

namespace AceStream
{
    public class NavigationItemImage
    {
        public static float ImageSizeForLargeState => 40;

        public static float ImageRightMargin => 16;

        public static float ImageBottomMarginForLargeState => 12;

        public static float ImageBottomMarginForSmallState => 6;

        public static float ImageSizeForSmallState => 32;

        public static float NavBarHeightSmallState => 44;

        public static float NavBarHeightLargeState => 96.5f;

        public UIImageView ImageView { get; set; }

        public NavigationItemImage(string image)
        {
            ImageView = new UIImageView(UIImage.FromFile(image));

            ImageView.Layer.CornerRadius = ImageSizeForLargeState / 2;
            ImageView.ClipsToBounds = true;
            ImageView.TranslatesAutoresizingMaskIntoConstraints = false;
        }

        public void ActivateConstraints(UINavigationBar navigationBar)
        {
            NSLayoutConstraint.ActivateConstraints(new NSLayoutConstraint[]
            {
                ImageView.RightAnchor.ConstraintEqualTo(navigationBar.RightAnchor, -ImageRightMargin),
                ImageView.BottomAnchor.ConstraintEqualTo(navigationBar.BottomAnchor, -ImageBottomMarginForLargeState),
                ImageView.HeightAnchor.ConstraintEqualTo(ImageSizeForLargeState),
                ImageView.WidthAnchor.ConstraintEqualTo(ImageView.HeightAnchor)
            });
        }

        public void ShowImage(bool show)
        {
            UIView.Animate(0.2, () => { ImageView.Alpha = show ? 1.0f : 0.0f; });
        }

        public void MoveAndResizeImage(nfloat height)
        {
            var coefficient = CalcCoefficient(height);

            var factor = ImageSizeForSmallState / ImageSizeForLargeState;

            var scale = CalcScale(coefficient, factor);

            var sizeDiff = ImageSizeForLargeState * (1.0 - factor);

            var yTranslation = CalcYTranslation(coefficient, sizeDiff);
            var xTranslation = new nfloat(Math.Max(0, sizeDiff - coefficient * sizeDiff));

            ImageView.Transform = SetTransform(scale, xTranslation, yTranslation);
        }

        private nfloat CalcCoefficient(nfloat height)
        {
            var delta = height - NavBarHeightSmallState;
            var heightDifferenceBetweenStates = NavBarHeightLargeState - NavBarHeightSmallState;

            var coefficient = new nfloat(delta / heightDifferenceBetweenStates);

            return coefficient;
        }

        private nfloat CalcScale(nfloat coefficient, nfloat factor)
        {
            var sizeAddendumFactor = coefficient * (1.0 - factor);

            var scale = new nfloat(Math.Min(1.0, sizeAddendumFactor + factor));

            return scale;
        }

        private nfloat CalcYTranslation(nfloat coefficient, double sizeDiff)
        {
            var maxYTranslation = ImageBottomMarginForLargeState - ImageBottomMarginForSmallState + sizeDiff;
            var max = Math.Max(0, Math.Min(maxYTranslation, maxYTranslation - coefficient * (ImageBottomMarginForSmallState + sizeDiff)));

            var yTranslation = new nfloat(max);

            return yTranslation;
        }

        private CGAffineTransform SetTransform(nfloat scale, nfloat xTranslation, nfloat yTranslation)
        {
            var transform = CGAffineTransform.MakeIdentity();
            transform.Scale(scale, scale);
            transform.Translate(xTranslation, yTranslation);

            return transform;
        }
    }
}
