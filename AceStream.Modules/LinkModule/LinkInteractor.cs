using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AceStream.Dto;
using AceStream.Services.Interfaces;

namespace AceStream.Modules.LinkModule
{
    public class LinkInteractor : ILinkInteractor
    {
        private ILinkService _service;

        public LinkInteractor(ILinkService service)
        {
            _service = service;
        }

        public async Task<List<LinkDto>> GetLinksAsync(string[] parametrs)
        {
            var links = await _service.GetLinksAsync(parametrs);

            return links;
        }
    }
}
