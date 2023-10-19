using Core.Entities.Concrete;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.Concrete.Dtos.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IProductService
    {
        IDataResult<List<Product>> GetList();

        IDataResult<Product> GetById(int productId);


        IResult Add(ProductAddDto productAddDto);
        IResult Delete(int productId);
        IResult Update(Product product);
    }
}
