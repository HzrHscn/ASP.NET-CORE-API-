using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class RepairRequest
    {
        public int RepairRequestId { get; set; }
        public int ProductId { get; set; }
        public DateTime RequestDate { get; set; }
        public string IssueDescription { get; set; }
        public bool IsResolved { get; set; } = false;

        public virtual Product Product { get; set; }
    }
}
