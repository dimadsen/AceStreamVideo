using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AceStream.Core.Exceptions;
using AceStream.Dto;
using AceStream.Services;

namespace AceStream.iOS.Modules.ChampionatModule
{
    public class ChampionatInteractor : IChampionatInteractor
    {
        private IChampionatPresenter _presenter;

        private IChampionatService _service;

        public ChampionatInteractor(IChampionatPresenter presenter, IChampionatService service)
        {
            _presenter = presenter;

            _service = service;
        }

        public string Title => _service.Title;

        public async Task<List<ChampionatDto>> GetChampionatsAsync()
        {
            try
            {
                var championats = await _service.GetChampionatsAsync();

                return championats?.Count > 0 ?
                    championats : throw new ChampionatsNotFoundException();
            }
            catch (ChampionatsNotFoundException ex)
            {
                _presenter.SetNotFoundChampionats(ex.Message);

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
