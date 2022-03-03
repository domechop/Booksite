using System;
using System.Linq;

namespace Booksite.Models
{
    public interface ISummaryRepository
    {
        IQueryable<Summary> Summarys { get; }

        void SaveSummary(Summary summary);

        
      
    }
}
