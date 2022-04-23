using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AceStream.Dto;
using AceStream.Services.Interfaces;

namespace AceStream.Services.Impl
{
    public class LinkService : ILinkService
    {
        public Task<List<LinkDto>> GetLinksAsync(string[] parameters)
        {
            return Task.Run(() => parameters.Select(p => new LinkDto
            {
                Name = p,
                Link = "http://89.43.111.242:6878/ace/m/6cdb8ae6a133b8b8a3a4f529da2943ebedcd3afa/2d59ef4e67a80bab8f2920660d4562d4.m3u8"
            }).ToList());

        }
    }
}
