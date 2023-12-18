using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class PersonelManager : IPersonelService
    {
        private readonly IPersonelDal _personelDal;

        public PersonelManager(IPersonelDal personelDal)
        {
            _personelDal = personelDal;
        }

        public void TDelete(Personel t)
        {
            _personelDal.Delete(t);
        }

        public Personel TGetById(int id)
        {
            return _personelDal.GetById(id);
        }

        public List<Personel> TGetList()
        {
            return _personelDal.GetList();
        }

        public void TInsert(Personel t)
        {
            _personelDal.Insert(t);
        }

        public void TUpdate(Personel t)
        {
            _personelDal.Update(t);
        }
    }
}
