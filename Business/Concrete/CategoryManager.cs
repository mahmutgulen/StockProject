using Business.Abstract;
using Business.Contants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.Concrete.Dtos.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private readonly ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public IResult Add(CategoryAddDto categoryAddDto)
        {
            var name = _categoryDal.Get(x => x.CategoryName == categoryAddDto.CategoryName);
            if (name == null)
            {
                var category = new Category
                {
                    CategoryName = categoryAddDto.CategoryName.Trim()
                };

                _categoryDal.Add(category);
                return new SuccessResult(Messages.CategoryAdded);

            }
            return new ErrorResult(Messages.CategoryAlreadyExists);


        }

        public IResult Delete(int categoryId)
        {
            var category = _categoryDal.Get(x => x.CategoryId == categoryId);
            if (category != null)
            {
                _categoryDal.Delete(category);
                return new SuccessResult(Messages.CategoryDeleted);
            }
            return new ErrorResult(Messages.CategoryNotFound);
        }

        public IDataResult<Category> GetById(int categoryId)
        {
            var category = _categoryDal.Get(p => p.CategoryId == categoryId);
            return new SuccessDataResult<Category>(category);

        }

        public IDataResult<List<Category>> GetList()
        {
            var category = _categoryDal.GetList().ToList();
            return new SuccessDataResult<List<Category>>(category);
        }

        public IResult Update(Category category)
        {
            var id = _categoryDal.Get(x => x.CategoryId == category.CategoryId);
            if (id != null)
            {
                var name = _categoryDal.Get(x => x.CategoryName == category.CategoryName);
                if (name != null)
                {
                    if (!String.IsNullOrEmpty(category.CategoryName))
                    {
                        _categoryDal.Update(category);
                        return new SuccessResult(Messages.CategoryUpdated);
                    }
                    return new ErrorResult(Messages.namebosolamaz);
                }
                return new ErrorResult(Messages.Buisimdecategoryvar);
            }
            return new ErrorResult(Messages.idgiriniz);


        }

    }
}
