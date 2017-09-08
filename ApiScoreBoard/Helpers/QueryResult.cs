using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiScoreBoard.Helpers
{
    public class QueryResult<T>
    {
        public int TotalItems { get; set; }
        public IEnumerable<T> Items { get; set; }
    }
}