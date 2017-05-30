using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Wired
{
    public class MockDataSource : INewsSource<Item>
    {
        IEnumerable<Item> items;

        public MockDataSource()
        {
            items = new List<Item>
            {
                new Item { Id = 1, Title = "First item", Description="This is a nice description"},
                new Item { Id = 2, Title = "Second item", Description="This is a nice description"},
                new Item { Id = 3, Title = "Third item", Description="This is a nice description"},
                new Item { Id = 4, Title = "Fourth item", Description="This is a nice description"},
                new Item { Id = 5, Title = "Fifth item", Description="This is a nice description"},
                new Item { Id = 6, Title = "Sixth item", Description="This is a nice description"},
            };
        }

        public Task<IEnumerable<Item>> GetLatestAsync()
        {
            return Task.FromResult(items);
        }

        public Task<IEnumerable<Item>> GetLatestAsync(string category)
        {
            return Task.FromResult(items);
        }
    }
}
