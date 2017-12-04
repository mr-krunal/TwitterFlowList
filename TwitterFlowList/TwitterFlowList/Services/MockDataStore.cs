using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

[assembly:Xamarin.Forms.Dependency(typeof(TwitterFlowList.MockDataStore))]
namespace TwitterFlowList
{
    public class MockDataStore : IDataStore<Item>
    {
        List<Item> items;

        public MockDataStore()
        {
            items = new List<Item>();
            var mockItems = new List<Item>
            {
                new Item { Id = Guid.NewGuid().ToString(), Text = "First item", Description="This is an item description." },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Second item", Description="This is an item description." },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Third item", Description="This is an item description." },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Fourth item", Description="This is an item description." },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Fifth item", Description="This is an item description." },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Sixth item", Description="This is an item description." },
                new Item { Id = Guid.NewGuid().ToString(), Text = "A First item", Description="This is an item description." },
                new Item { Id = Guid.NewGuid().ToString(), Text = "B Second item", Description="This is an item description." },
                new Item { Id = Guid.NewGuid().ToString(), Text = "C Third item", Description="This is an item description." },
                new Item { Id = Guid.NewGuid().ToString(), Text = "D Fourth item", Description="This is an item description." },
                new Item { Id = Guid.NewGuid().ToString(), Text = "E Fifth item", Description="This is an item description." },
                new Item { Id = Guid.NewGuid().ToString(), Text = "F Sixth item", Description="This is an item description." },
                new Item { Id = Guid.NewGuid().ToString(), Text = "ABCD First item", Description="This is an item description." },
                new Item { Id = Guid.NewGuid().ToString(), Text = "ABCDEF Second item", Description="This is an item description." },
                new Item { Id = Guid.NewGuid().ToString(), Text = "ABCDEFGH Third item", Description="This is an item description." },
                new Item { Id = Guid.NewGuid().ToString(), Text = "ABCDEFGHIJ Fourth item", Description="This is an item description." },
                new Item { Id = Guid.NewGuid().ToString(), Text = "ABCDEFGH Fifth item", Description="This is an item description." },
                new Item { Id = Guid.NewGuid().ToString(), Text = "ABCDEF Sixth item", Description="This is an item description." },
            };

            foreach (var item in mockItems)
            {
                items.Add(item);
            }
        }

        public async Task<bool> AddItemAsync(Item item)
        {
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Item item)
        {
            var _item = items.Where((Item arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(_item);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var _item = items.Where((Item arg) => arg.Id == id).FirstOrDefault();
            items.Remove(_item);

            return await Task.FromResult(true);
        }

        public async Task<Item> GetItemAsync(string id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Item>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }
    }
}
