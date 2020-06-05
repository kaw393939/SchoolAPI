using Entities.Models;
using System;
using System.Collections.Generic;



namespace Contracts
{
    public interface IOrganizationRepository
    {
        IEnumerable<Organization> GetAllOrganizations(bool trackChanges);
        Organization GetOrganization(Guid companyId, bool trackChanges);
        void CreateOrganization(Organization organization);
        IEnumerable<Organization> GetByIds(IEnumerable<Guid> ids, bool trackChanges);
        void DeleteCompany(Organization organization);
    }
}
