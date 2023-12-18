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
    public class AssignmentManager : IAssignmentService
    {
        private readonly IAssignmentDal _assignmentDal;

        public AssignmentManager(IAssignmentDal assignmentDal)
        {
            _assignmentDal = assignmentDal;
        }

        public void TDelete(Assignment t)
        {
            _assignmentDal.Delete(t);
        }

        public Assignment TGetById(int id)
        {
            return _assignmentDal.GetById(id);
        }

        public List<Assignment> TGetList()
        {
            return _assignmentDal.GetList();
        }

        public void TInsert(Assignment t)
        {
            _assignmentDal.Insert(t);
        }

        public void TUpdate(Assignment t)
        {
            _assignmentDal.Update(t);
        }
    }
}
