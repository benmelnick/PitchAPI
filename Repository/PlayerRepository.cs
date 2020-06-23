using System;
using Entities;
using Entities.Models;
using Contracts;

namespace Repository
{
    // implementation of the IPlayerRepository, extends RepositoryBase (inherits base repository functionality)
    public class PlayerRepository : RepositoryBase<Player>, IPlayerRepository
    {
        public PlayerRepository(RepositoryContext repositoryContext)
            :base(repositoryContext)
        {
        }
    }
}
