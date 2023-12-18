namespace ProjeUI.Models.Personel
{
    public class PersonelViewModel
    {
        public int ID { get; set; }
        public string NameSurname { get; set; }
        public string Mail { get; set; }
        public string Address { get; set; }
        public string Departman { get; set; }
        public string Rol { get; set; }
        public bool Status { get; set; } = true;
    }
}
