using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class RepairRequestManager : IRepairRequestService
    {
        private readonly IRepairRequestDal _repairRequestDal;
        public void TDelete(RepairRequest t)
        {
            _repairRequestDal.Delete(t);
        }

        public RepairRequest TGetById(int id)
        {
            return _repairRequestDal.GetById(id);
        }

        public List<RepairRequest> TGetList()
        {
            return _repairRequestDal.GetList();
        }

        public void TInsert(RepairRequest t)
        {
            _repairRequestDal.Insert(t);
        }

        public void TUpdate(RepairRequest t)
        {
            _repairRequestDal.Update(t);
        }
    }
}
