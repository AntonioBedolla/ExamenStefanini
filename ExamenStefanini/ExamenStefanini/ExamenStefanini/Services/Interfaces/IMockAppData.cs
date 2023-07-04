using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ExamenStefanini.Services.Interfaces
{
	public interface IMockAppData<T>
	{
        Task<T> GetItemAsync(string id);
        Task<IEnumerable<T>> GetItemsAsync(bool forceRefresh = false);
    }
}

