using System;
using System.Collections.Generic;
using AceStream.Dto;
using UIKit;

namespace AceStream.SubModules.LinkSubModule
{
    public interface ILinkConfigurator
    {
        void Configure(LinkViewController viewController);
    }

    public interface ILinkPresenter
    {
        ILinkRouter Router { get; set; }
        ILinkInteractor Interactor { get; set; }

        List<LinkDto> Links { get; set; }

        void ConfigureView();
    }

    public interface ILinkInteractor
    {
    }

    public interface ILinkRouter
    {
        void Prepare(UIStoryboardSegue segue, string link);
    }

    public interface ILinkView
    {
        void SetSettings();
        void SetLinks(List<LinkDto> links);
    }
}
