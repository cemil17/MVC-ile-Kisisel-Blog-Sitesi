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
    public class ProjectManager : IProjectService
    {

        IProjectDal _projectDal;

        public ProjectManager(IProjectDal projectDal)
        {
            _projectDal = projectDal;
        }

        public void ProjectDelete(int id)
        {
            Project project = _projectDal.Find(x => x.ID == id);
            _projectDal.Delete(project);
        }

        public Project GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public List<Project> GetList()
        {
            return _projectDal.List();
        }

        public void TAdd(Project p)
        {
            _projectDal.Insert(p);
        }

        public void TUpdate(Project p)
        {
            _projectDal.Update(p);
        }
    }
}
