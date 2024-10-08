﻿using System;
using System.Dynamic;
using AceStream.Core.Domain.Enums;
using AceStream.Core.Extansions;
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

            if (dto.Status == MatchStatus.NotStarted)
            {
                Time.Text = dto.Time;
            }
            else if (dto.Status == MatchStatus.Completed)
            {
                Time.Hidden = true;

                HomeScore.Hidden = false;
                HomeScore.Text = dto.HomeScore;

                VisitorScore.Hidden = false;
                VisitorScore.Text = dto.VisitorScore;
            }
            else
            {
                Time.Text = dto.Status.GetDescription();
            }

            HomeIcon.Image = UIImage.FromFile(dto.HomePicture);
            VisitorIcon.Image = UIImage.FromFile(dto.VisitorPicture);

            Favorites.ImageView.ContentMode = UIViewContentMode.ScaleAspectFit;

            HomeIcon.Layer.MasksToBounds = false;
            HomeIcon.ClipsToBounds = true;

            VisitorIcon.Layer.MasksToBounds = false;            
            VisitorIcon.ClipsToBounds = true;
        }

        partial void AddToFavorites(UIButton sender)
        {
            Console.WriteLine(sender.Tag);
        }
    }
}
