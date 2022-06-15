using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class CategoryManager : ICategoryService
    {

        ICategoryDal _categoryDal;
        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }
     

        public List<Category> CategoryTrueList()
        {
            return _categoryDal.List(x => x.CategoryStatus == true);
        }
        public List<Category> CategoryFalseList()
        {
            return _categoryDal.List(x => x.CategoryStatus == false);
        }
        public void CategoryDelete(int id)
        {
            Category category = _categoryDal.Find(x => x.CategoryID == id);
            category.CategoryStatus = false;
            _categoryDal.Update(category);
        }
        public void CategoryUpdateToTrue(int id)
        {
            Category category = _categoryDal.Find(x => x.CategoryID == id);
            category.CategoryStatus = true;
            _categoryDal.Update(category);
        }



        public void ICategoryUpdate(Category category)
        {
            _categoryDal.Update(category);
        }


        public void ICategoryAdd(Category category)
        {
            category.CategoryStatus = true;
            _categoryDal.Insert(category);
        }

        public Category GetByID(int id)
        {
            return _categoryDal.GetByID(id);
        }
    }
}
