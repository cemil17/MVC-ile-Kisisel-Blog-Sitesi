using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface ICategoryService
    {
        void ICategoryUpdate(Category category);
        void ICategoryAdd(Category category);
        Category GetByID(int id);
    }
}
