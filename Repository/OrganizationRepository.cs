using Contracts;
using Entities;
using Entities.Models;
using System.Collections.Generic;
using System.Linq;

namespace Repository
{
    public class OrganizationRepository : RepositoryBase<Organization>, IOrganizationRepository
    {
        public OrganizationRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }
        public IEnumerable<Organization> GetAllOrganizations(bool trackChanges) =>
          FindAll(trackChanges)
          .OrderBy(c => c.OrgName)
          .ToList();
    }
}