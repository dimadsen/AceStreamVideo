using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AceStream.Dto;
using AceStream.Extansions;
using AceStream.Services;
using AceStreamDb;
using Parser.Client;

namespace AceStream.Modules.ChampionatModule
{
    public class ChampionatInteractor : IChampionatInteractor
    {
        private IChampionatPresenter _presenter;

        private IChampionatService service;

        public ChampionatInteractor(IChampionatPresenter presenter)
        {
            _presenter = presenter;

            service = new ChampionatService(new Client());
        }

        public string Title => service.Title;

        public async Task<List<ChampionatDto>> GetChampionatsAsync()
        {
            try
            {
                var championats = await service.GetChampionatsAsync();
                
                return championats;
            }
            catch (NotFoundMatchesException)
            {
                _presenter.SetNotFoundMatches();

                return new List<ChampionatDto>();
            }
            catch (Exception)
            {
                _presenter.SetError();

                return new List<ChampionatDto>();
            }
        }
    }
}
