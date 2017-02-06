using CrisMAcAPI.Models.Repository.CommonInterface;
using System.Collections.Generic;

namespace CrisMAcAPI.Models.Repository.AttributeRepository
{
    public interface IAttributeRepository : ICommonInterface
    {
        List<object> GetSegmentParameterFetch(string ParaStr);
    }
    
}