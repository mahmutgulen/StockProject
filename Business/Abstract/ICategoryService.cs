using Core.Utilities.Results;
using Entities.Concrete;
using Entities.Concrete.Dtos.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICategoryService
    {
        IDataResult<List<Category>> GetList();

        IDataResult<Category> GetById(int categoryId);


        IResult Add(CategoryAddDto categoryAddDto);
        IResult Delete(int categoryId);
        IResult Update(Category category);
    }
}
