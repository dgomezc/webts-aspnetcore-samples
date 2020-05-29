using WebApiMongo.Models;
using System.Collections.Generic;

namespace WebApiMongo.Contracts
{
    public interface ISampleDataService
    {
        IEnumerable<SampleCompany> GetSampleCompanies();
    }
}
