using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuitSmoking.Repository.NamHH.Pangination
{
    public class PaginatedList<T>
    {
        public List<T> Items { get; set; }
        public int TotalCount { get; set; }

        public PaginatedList(List<T> items, int totalCount)
        {
            Items = items;
            TotalCount = totalCount;
        }
    }
}
