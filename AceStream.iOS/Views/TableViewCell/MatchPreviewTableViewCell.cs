using System;
using System.Dynamic;
using AceStream.Dto;
using Foundation;
using UIKit;

namespace AceStream.Views.TableViewCell
{
    public partial class MatchPreviewTableViewCell : UITableViewCell
    {
        public static readonly NSString Key = new NSString("MatchPreviewTableViewCell");
        public static readonly UINib Nib;

        static MatchPreviewTableViewCell()
        {
            Nib = UINib.FromName("MatchPreviewTableViewCell", NSBundle.MainBundle);
        }

        protected MatchPreviewTableViewCell(IntPtr handle) : base(handle)
        {
        }

        public MatchPreviewTableViewCell(NSString cellId) : base(UITableViewCellStyle.Default, cellId)
        {

        }

        public void UpdateCell(MatchPreviewDto dto)
        {
            Home.Text = dto.Home;
            Visitor.Text = dto.Visitor;

            if (dto.Status != "завершен")
            {
                Time.Text = dto.Time;
            }
            else
            {
                Time.Hidden = true;

                HomeScore.Hidden = false;
                HomeScore.Text = dto.HomeScore;

                VisitorScore.Hidden = false;
                VisitorScore.Text = dto.VisitorScore;
            }

            HomeIcon.Image = UIImage.FromFile(dto.HomePicture);
            VisitorIcon.Image = UIImage.FromFile(dto.VisitorPicture);

            Favorites.ImageView.ContentMode = UIViewContentMode.ScaleAspectFit;

            HomeIcon.Layer.BorderWidth = 1;
            HomeIcon.Layer.MasksToBounds = false;
            HomeIcon.Layer.BorderColor = UIColor.DarkGray.CGColor;
            HomeIcon.BackgroundColor = UIColor.White;
            //HomeIcon.Layer.CornerRadius = HomeIcon.Frame.Height / 2;
            HomeIcon.ClipsToBounds = true;

            VisitorIcon.Layer.BorderWidth = 1;
            VisitorIcon.Layer.MasksToBounds = false;
            VisitorIcon.Layer.BorderColor = UIColor.DarkGray.CGColor;
            VisitorIcon.BackgroundColor = UIColor.White;
            //VisitorIcon.Layer.CornerRadius = VisitorIcon.Frame.Height / 2;
            VisitorIcon.ClipsToBounds = true;
        }

        partial void AddToFavorites(UIButton sender)
        {
            Console.WriteLine(sender.Tag);
        }
    }
}
