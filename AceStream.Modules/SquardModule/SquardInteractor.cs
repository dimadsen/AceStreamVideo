using System.Threading.Tasks;
using AceStream.Core.Exceptions;
using AceStream.Services.Clients;
using AceStream.Services.Dto;

namespace AceStream.iOS.Modules.SquardModule
{
    public class SquardInteractor : ISquardInteractor
    {
        private ISourceClient _client;

        public SquardInteractor(ISourceClient client)
        {
            _client = client;
        }

        public async Task<SquardDto> GetSquardsAsync(int matchId)
        {
            var squardDto = await _client.GetSquardsAsync(matchId);           

            return squardDto.HomeSquard.Startings.Count == 11 && squardDto.VisitorSquard.Startings.Count == 11 ?
                squardDto : throw new PlayersNotFoundException();
        }        
    }
}
