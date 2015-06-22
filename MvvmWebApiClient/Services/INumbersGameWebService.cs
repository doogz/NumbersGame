using System.Threading.Tasks;
using ScottLogic.NumbersGame;

namespace MvvmWebApiClient.Services
{
    /// <summary>
    /// Top-level interface for the Numbers Game Web API service
    /// At present, we have one implementation only, and it's hard-coded to a port on localhost
    /// TODO: Support configuration of web api server e.g. location, port
    /// </summary>
    public interface INumbersGameWebService
    {
        Task<IPuzzle> GetNextGameAsync();
    }
}
