using ProjeUI.Models.Personel;
using ProjeUI.Models.Product;

namespace ProjeUI.Models.Assignment
{
    public class AssignmentViewModel
    {
        public int AssignmentId { get; set; }
        public int productID { get; set; }
        public ProductViewModel Product { get; set; }
        public int personelID { get; set; }
        public PersonelViewModel Personel { get; set; }
        public DateTime AssignmentDate { get; set; } = DateTime.Now;
        public bool isReturned { get; set; }

        //public virtual Product Product { get; set; }
        //public virtual Personel Personel { get; set; }
    }
}
