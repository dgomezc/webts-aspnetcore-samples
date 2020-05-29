using WebApi.Models;
using System.Collections.Generic;

namespace WebApi.Contracts
{
    public interface ISampleDataService
    {
        IEnumerable<SampleCompany> GetSampleCompanies();
    }
}
