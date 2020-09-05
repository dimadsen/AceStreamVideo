using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AceStream.Dto;
using AceStream.Services;
using Parser.Client;

namespace AceStream.SubModules.LinkSubModule
{
    public class LinkInteractor : ILinkInteractor
    {
        private ILinkPresenter _presenter;
        private IMatchService _service;

        public LinkInteractor(ILinkPresenter presenter)
        {
            _presenter = presenter;

            _service = new MatchService(new Client());
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
