using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InventorySales.Common
{
     public class Pagination<TEntity>
     {
          public static int ResultsPerPage { get { return 5; } }
          public int PageRequested { get; set; }
          public int TotalPages { get; set; }
          private IEnumerable<TEntity> Query { get; set; }
          public Pagination(IEnumerable<TEntity> query, int pageRequested)
          {
               Query = query;
               PageRequested = pageRequested;
               TotalPages = calculateTotalPagesInResult(query.Count());
          }

          private int calculateTotalPagesInResult(int totalRecords)
          {
               int pages = totalRecords / ResultsPerPage;
               if (totalRecords % ResultsPerPage > 0)
                    pages++;
               return pages;
          }

          public IEnumerable<TEntity> GetPaginatedResult()
          {
               int recordsToSkip = ResultsPerPage * (PageRequested - 1);
               return Query.Skip(recordsToSkip).Take(ResultsPerPage);
          }
     }
}