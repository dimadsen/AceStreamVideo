using System.Collections.Generic;
using System.Threading.Tasks;
using AceStream.Dto;

namespace AceStream.Modules.LinkModule
{
    public interface ILinkPresenter
    {
        /// <summary>
        /// Название команд, каналов для поиска в ссылок
        /// </summary>
        string[] Parametrs { get; set; }

        void ConfigureView(ILinkView view);

        Task SetLinksAsync();

        void PrepareForSegue(object destinationView, string link);
    }

    public interface ILinkInteractor
    {
        Task<List<LinkDto>> GetLinksAsync(string[] parametr);
    }

    public interface ILinkRouter
    {
        void PrepareForSegue(object destinationView, string link);
    }

    public interface ILinkView
    {
        ILinkPresenter Presenter { get; set; }

        void SetSettings();
        void SetLinks(List<LinkDto> links);

        void SetError();
    }
}
