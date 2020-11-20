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
                Link = "https://rtmp.api.rt.com/hls/rtdru.m3u8"
            }).ToList());

        }
    }
}
