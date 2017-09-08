using ApiScoreBoard.Helpers.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiScoreBoard.Helpers
{
    public class Query : IQueryObject
    {
        public string FilterBy { get ; set ; }
        public string SortBy { get; set ; }
        public bool IsSortAscending { get ; set; }
        public int Page { get ; set ; }
        public byte PageSize { get ; set ; }
        public bool Paginate { get ; set ; }
    }
}