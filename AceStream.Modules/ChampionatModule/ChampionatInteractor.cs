using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AceStream.Core.Exceptions;
using AceStream.Dto;
using AceStream.Services.Interfaces;

namespace AceStream.iOS.Modules.ChampionatModule
{
    public class ChampionatInteractor : IChampionatInteractor
    {
        private IChampionatService _service;

        public ChampionatInteractor(IChampionatService service)
        {
            _service = service;
        }

        public async Task<List<ChampionatDto>> GetChampionatsAsync()
        {
            var championats = await _service.GetChampionatsAsync();

            return championats.Any() ? championats : throw new ChampionatsNotFoundException();
        }
    }
}
