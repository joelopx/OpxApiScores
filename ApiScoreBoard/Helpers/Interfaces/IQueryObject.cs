using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiScoreBoard.Helpers.interfaces
{
    public interface IQueryObject
    {
        string FilterBy { get; set; }
        string SortBy { get; set; }
        bool IsSortAscending { get; set; }
        int Page { get; set; }
        byte PageSize { get; set; }
        bool Paginate { get; set; }
    }
}
