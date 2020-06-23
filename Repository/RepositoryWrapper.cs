using System;
using Contracts;
using Entities;

namespace Repository
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private RepositoryContext _repoContext;
        private ITeamRepository _team;

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

        public void Save()
        {
            _repoContext.SaveChanges();
        }
    }
}
