using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Wired
{
    public interface INewsSource<T>
    {
        Task<IEnumerable<T>> GetLatestAsync();

        Task<IEnumerable<T>> GetLatestAsync(string category);
    }
}
