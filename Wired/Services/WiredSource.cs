using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Wired.Helpers;

namespace Wired.Services
{
    public class WiredSource : INewsSource<Item>
    {
        public Task<IEnumerable<Item>> GetLatestAsync()
        {
            var url = Settings.AppSettings.GetValueOrDefault("categoryUrl", WiredPages.TopStories.GetString());
            return Task.FromResult(RssReader.GetFromApi(url).Result);
        }

        public Task<IEnumerable<Item>> GetLatestAsync(string category)
        {
            return Task.FromResult(RssReader.GetFromApi(category).Result);
        }
    }
}
