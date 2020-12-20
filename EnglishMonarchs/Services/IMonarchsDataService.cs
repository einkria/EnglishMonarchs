using System.Collections.Generic;
using System.Threading.Tasks;
using EnglishMonarchs.Models;

namespace EnglishMonarchs.Services
{
    public interface IMonarchsDataService
    {
        /*
         * Get a list of monarchs from API.
         */
        Task<IList<Monarch>> GetMonarchs();
    }
}
