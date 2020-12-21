using System.Threading.Tasks;

namespace EnglishMonarchs.RunApp
{
    public interface IApp
    {
        /*
         * Run the application
         */
        Task<bool> Run();
    }
}
