using System;
using System.Collections.Generic;
using System.Threading.Tasks;
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

        /// <summary>
        /// Название команд, каналов для поиска в ссылок
        /// </summary>
        string[] Parametrs { get; set; }

        void ConfigureView();

        Task SetLinksAsync();

        void SetError();
    }

    public interface ILinkInteractor
    {
        Task<List<LinkDto>> GetLinksAsync(string[] parametr);
    }

    public interface ILinkRouter
    {
        void Prepare(UIStoryboardSegue segue, string link);
    }

    public interface ILinkView
    {
        void SetSettings();
        void SetLinks(List<LinkDto> links);

        void SetError();
    }
}
