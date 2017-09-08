using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiScoreBoard.Resources.Interfaces
{
    public interface IBase
    {
        int Id { get; set; }
        string CreatedBy { get; set; }
        DateTime? CreatedDate { get; set; }
        string UpdatedBy { get; set; }
        DateTime? UpdatedDate { get; set; }
    }
}
