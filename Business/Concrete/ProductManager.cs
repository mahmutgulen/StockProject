using Business.Abstract;
using Business.Contants;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.Concrete.Dtos.Product;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        private readonly IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public IResult Add(ProductAddDto productAddDto)
        {
            //aynı isim ile başka category eklersem patlıyor
            //Trim()
            var name = _productDal.Get(x => x.ProductName == productAddDto.ProductName);
            // var category = _productDal.Get(x => x.CategoryId == productAddDto.CategoryId);
            //SqlConnection connection = new SqlConnection(@"Server=intern-db.cjq6i1xxy6zz.eu-central-1.rds.amazonaws.com;Database=StockProjectMako;Uid=sa;Password=ntKjHbkxnkdEDRYbEGgdnXGZ");
            //connection.Open();

            //var category = $"SELECT CategoryId FROM Products WHERE {productAddDto.CategoryId}";
            
            //SqlCommand command = new SqlCommand(category, connection);
            //SqlDataReader reader = command.ExecuteReader();

            if (name == null)
            {
                var product = new Product
                {
                    CategoryId = productAddDto.CategoryId,
                    ProductId = productAddDto.CategoryId,
                    ProductName = productAddDto.ProductName,
                    ProductPrice = productAddDto.ProductPrice,
                    ProductStock = productAddDto.ProductStock
                };

                _productDal.Add(product);
                return new SuccessResult(Messages.ProductAdded);


            }
            return new ErrorResult(Messages.ProductAlreadyExists);
        }


        public IResult Delete(int productId)
        {
            var product = _productDal.Get(x => x.ProductId == productId);
            if (product != null)
            {
                _productDal.Delete(product);
                return new SuccessResult(Messages.ProductDeleted);
            }
            return new ErrorResult(Messages.ProductNotFound);

        }

        public IDataResult<Product> GetById(int productId)
        {

            var product = _productDal.Get(p => p.ProductId == productId);
            return new SuccessDataResult<Product>(product);

        }

        public IDataResult<List<Product>> GetList()
        {
            var product = _productDal.GetList().ToList();
            return new SuccessDataResult<List<Product>>(product);
        }

        public IResult Update(Product product)
        {
            var id = _productDal.Get(x => x.ProductId == product.ProductId);
            if (id != null)
            {
                var name = _productDal.Get(x => x.ProductName == product.ProductName);
                if (name == null)
                {
                    if (!String.IsNullOrEmpty(product.ProductName))
                    {
                        _productDal.Update(product);
                        return new SuccessResult(Messages.ProductUpdated);
                    }
                    return new ErrorResult(Messages.namebosolamaz);

                }
                return new ErrorResult(Messages.Buisimdeurunvar);
            }
            return new ErrorResult(Messages.idgiriniz);


        }
    }
}
