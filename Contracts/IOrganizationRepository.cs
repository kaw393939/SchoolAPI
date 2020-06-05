using Entities.Models;
using System;
using System.Collections.Generic;



namespace Contracts
{
    public interface IOrganizationRepository
    {
        IEnumerable<Organization> GetAllOrganizations(bool trackChanges);
        Organization GetOrganization(Guid companyId, bool trackChanges);
    }
}
