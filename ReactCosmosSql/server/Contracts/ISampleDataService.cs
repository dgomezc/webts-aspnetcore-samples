using WebApiSql.Models;
using System.Collections.Generic;

namespace WebApiSql.Contracts
{
    public interface ISampleDataService
    {
        IEnumerable<SampleCompany> GetSampleCompanies();
    }
}
