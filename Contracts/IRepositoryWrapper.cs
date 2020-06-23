using System;
namespace Contracts
{
    // exposes all of the individual entity repositories so we can use one class across all controllers
    public interface IRepositoryWrapper
    {
        ITeamRepository Team { get; }
        IPlayerRepository Player { get; }
        void Save();
    }
}
