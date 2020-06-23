using System;
using Contracts;
using Entities;

namespace Repository
{
    // implementation of IRepositoryWrapper to expose instances of each entity repository
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private RepositoryContext _repoContext;
        private ITeamRepository _team;
        private IPlayerRepository _player;

        public RepositoryWrapper(RepositoryContext repositoryContext)
        {
            _repoContext = repositoryContext;
        }

        public ITeamRepository Team
        {
            get
            {
                if (_team == null)
                {
                    _team = new TeamRepository(_repoContext);
                }
                return _team;
            }
        }

        public IPlayerRepository Player
        {
            get
            {
                if (_player == null)
                {
                    _player = new PlayerRepository(_repoContext);
                }
                return _player;
            }
        }

        public void Save()
        {
            _repoContext.SaveChanges();
        }
    }
}
