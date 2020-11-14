using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AceStream.Dto;
using AceStream.Services;
using AceStream.Services.Interfaces;

namespace AceStream.SubModules.LinkSubModule
{
    public class LinkInteractor : ILinkInteractor
    {
        private ILinkPresenter _presenter;
        private ILinkService _service;

        public LinkInteractor(ILinkPresenter presenter, ILinkService service)
        {
            _presenter = presenter;
            _service = service;
        }

        public async Task<List<LinkDto>> GetLinksAsync(string[] parametrs)
        {
            try
            {
                var links = await _service.GetLinksAsync(parametrs);

                return links;
            }
            catch (Exception)
            {
                _presenter.SetError();

                return new List<LinkDto>();
            }
        }
    }
}
