using System.Threading.Tasks;
using ScottLogic.NumbersGame.Game;

namespace MvvmWebApiClient.Services
{
    /// <summary>
    /// Top-level interface for the Numbers Game Web API service
    /// At present, we have one implementation only, and it's hard-coded to our localhost
    /// TODO: Support configuration of web api server e.g. location, port
    /// </summary>
    public interface INumbersGameWebService
    {
        Task<Definition> GetNextGameAsync();
    }
}
