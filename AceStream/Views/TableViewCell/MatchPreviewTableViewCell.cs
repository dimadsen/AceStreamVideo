﻿using System;
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

            Time.Text = dto.Time;
            
            HomeIcon.Image = UIImage.FromFile(dto.HomePicture);
            VisitorIcon.Image = UIImage.FromFile(dto.VisitorPicture);

            Favorites.ImageView.ContentMode = UIViewContentMode.ScaleAspectFit;

            HomeIcon.Layer.BorderWidth = 1;
            HomeIcon.Layer.MasksToBounds = false;
            HomeIcon.Layer.BorderColor = UIColor.LightGray.CGColor;
            HomeIcon.Layer.CornerRadius = HomeIcon.Frame.Height / 2;
            HomeIcon.ClipsToBounds = true;

            VisitorIcon.Layer.BorderWidth = 1;
            VisitorIcon.Layer.MasksToBounds = false;
            VisitorIcon.Layer.BorderColor = UIColor.LightGray.CGColor;
            VisitorIcon.Layer.CornerRadius = VisitorIcon.Frame.Height / 2;
            VisitorIcon.ClipsToBounds = true;
        }

        partial void AddToFavorites(UIButton sender)
        {
            Console.WriteLine(sender.Tag); 
        }
    }
}
