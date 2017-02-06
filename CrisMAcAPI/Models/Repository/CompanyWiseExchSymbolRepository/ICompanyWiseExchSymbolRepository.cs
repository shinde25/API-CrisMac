using CrisMAcAPI.Models.Repository.CommonInterface;
namespace CrisMAcAPI.Models.Repository.CompanyWiseExchSymbolRepository
{
    public interface ICompanyWiseExchSymbolRepository : ICommonInterface
    {
        object CompanyWiseExchSymbolInsertUpdateData(string jsonData);
    }
}
