using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExamenStefanini.Models;
using ExamenStefanini.Services.Interfaces;

namespace ExamenStefanini.Services
{
	public class MockAppData: IMockAppData<Applications>
	{
        List<Applications> Items;

		public MockAppData()
		{
            Items = new List<Applications>();
            var mockItems = new List<Applications>
            {
                new Applications{Id=Guid.NewGuid().ToString(), Name="App 1",Developer="Desarrollador 1", Price="Free"},
                new Applications{Id=Guid.NewGuid().ToString(), Name="App 2",Developer="Desarrollador 2", Price="$200.00"},
                new Applications{Id=Guid.NewGuid().ToString(), Name="App 3",Developer="Desarrollador 3", Price="$300.00"},
                new Applications{Id=Guid.NewGuid().ToString(), Name="App 4",Developer="Desarrollador 4", Price="$400.00"},
                new Applications{Id=Guid.NewGuid().ToString(), Name="App 5",Developer="Desarrollador 5", Price="$500.00"},
            };

            foreach (var item in mockItems)
            {
                Items.Add(item);
            }
		}

        public async Task<Applications> GetItemAsync(string id)
        {
            return await Task.FromResult(Items.FirstOrDefault(x => x.Id == id));
        }

        public async Task<IEnumerable<Applications>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(Items);
        }
    }
}

