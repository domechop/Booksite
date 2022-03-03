using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Booksite.Models
{
    public class EFSummaryRepository : ISummaryRepository
    {
        private BookstoreContext context;

        public EFSummaryRepository(BookstoreContext temp)
        {
            context = temp;
        }

        public IQueryable<Summary> Summarys => context.Summary.Include(x => x.Lines).ThenInclude(x => x.Book);

        public void SaveSummary(Summary summary)
        {
            context.AttachRange(summary.Lines.Select(x => x.Book));

            if(summary.SummaryId == 0)
            {
                context.Summary.Add(summary);
            }
            context.SaveChanges();
        }
    }
}
