using DedAPI.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DedAPI.Services
{
    public interface IRestService
    {
        Task<List<EntryModel>> GetDataAsync();
    }
}
