using System;
namespace Contracts
{
    public interface IRepositoryWrapper
    {
        ITeamRepository Team { get; }
        void Save();
    }
}
