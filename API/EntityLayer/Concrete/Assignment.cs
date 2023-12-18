using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Assignment
    {
        public int AssignmentId { get; set; }
        public int productID { get; set; }
        public int personelID { get; set; }
        public DateTime AssignmentDate { get; set; } = DateTime.Now;
        public bool isReturned { get; set; }

        public virtual Product Product { get; set; }
        public virtual Personel Personel { get; set; }
    }
}
