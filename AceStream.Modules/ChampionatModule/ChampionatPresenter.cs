using System;
using System.Threading.Tasks;
using AceStream.Core.Exceptions;
using AceStream.Dto;

namespace AceStream.iOS.Modules.ChampionatModule
{
    public class ChampionatPresenter : IChampionatPresenter
    {
        public IChampionatInteractor Interactor { get; set; }
        public IChampionatRouter Router { get; set; }

        public IChampionatView View;

        public ChampionatPresenter(IChampionatRouter router, IChampionatInteractor interactor)
        {
            Router = router;
            Interactor = interactor;
        }

        public void PrepareForSegue(object destinationView, ChampionatDto dto)
        {
            Router.PrepareForSegue(destinationView, dto);
        }

        public async Task SetChampionatsAsync()
        {
            try
            {
                var championats = await Interactor.GetChampionatsAsync();

                View.SetChampionats(championats);
            }
            catch (ChampionatsNotFoundException ex)
            {
                View.SetNotFoundView(ex.Message);
            }
            catch (Exception ex)
            {
                View.SetErrorView();
            }
        }

        public void ConfigureView(IChampionatView view)
        {
            View = view;

            View.SetSettings("Чемпионаты");
        }

        public void SetError()
        {
            View.SetErrorView();
        }

        public void SetNotFoundChampionats(string message)
        {
            View.SetNotFoundView(message);
        }
    }
}
