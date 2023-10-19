using Business.Abstract;
using Business.Contants;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using Core.Utilities.Security.Jwt;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entities.Concrete;

using Entities.Concrete.Dtos.Cart;

using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CartManager : ICartService
    {
        private readonly ICartDal _cartDal;
        private readonly IUserDal _userDal;
        private readonly IProductDal _productDal;
        private readonly IOrderDal _orderDal;
        private readonly ITokenHelper _tokenHelper;


        public CartManager(ICartDal cartDal, IUserDal userDal, IProductDal productDal, IOrderDal orderDal, ITokenHelper tokenHelper)
        {
            _cartDal = cartDal;
            _userDal = userDal;
            _productDal = productDal;
            _orderDal = orderDal;
            _tokenHelper = tokenHelper;
        }

        public IResult Add(CartAddDto cartAddDto)
        {
            var cartAdd = new Cart
            {
                UserId = cartAddDto.UserId,
                ProductId = cartAddDto.ProductId,
                OrderAmount = cartAddDto.OrderAmount,
                CreatedTime = DateTime.Now,
            };

            var stoksayisi = cartAdd.OrderAmount;
            var product = _productDal.Get(x => x.ProductId == cartAddDto.ProductId);
            var user = _userDal.Get(x => x.UserId == cartAddDto.UserId);
            //product boşmu döndürüldü?
            if (product != null)
            {       //stok vrsa gir
                if (product.ProductStock >= cartAdd.OrderAmount)
                {
                    //stok düşürme islemi
                    product.ProductStock = product.ProductStock - cartAdd.OrderAmount;
                    //balance düsürme
                    var price = product.ProductPrice * cartAdd.OrderAmount;
                    user.UserWallet -= (product.ProductPrice * cartAdd.OrderAmount);
                    //user balance kontrolü
                    if (user.UserWallet >= price)
                    {
                        Random rnd = new();
                        var order = new Order
                        {
                            UserId = cartAddDto.UserId,
                            OrderNumber = rnd.Next(999999),
                            TotalPrice = price
                        };

                        _productDal.Update(product);
                        _orderDal.Add(order);
                        _userDal.Update(user);

                        _cartDal.Add(cartAdd);

                        return new SuccessResult(Messages.CartAdded);
                    }
                    return new ErrorResult(Messages.UserIsPoor);

                }
                return new ErrorResult(Messages.ProductNotExistsStock);
            }
            return new ErrorResult(Messages.UrunGirilmedi);
        }



        public IResult Delete(CartDeleteDto cartDeleteDto)
        {
            var variables= _cartDal.Get(x=> x.CartId ==cartDeleteDto.CartId && x.UserId == cartDeleteDto.UserId);
           
            if (variables!=null)
            {
                var cartDelete = new Cart
                {
                    CartId = cartDeleteDto.CartId,
                    UserId = cartDeleteDto.UserId
                };
                _cartDal.Delete(cartDelete);
                return new SuccessResult(Messages.CartDeleted);
            }
            return new ErrorResult(Messages.CartNotFound);
           
        }



        public IDataResult<IList<Cart>> GetCart(int userId)
        {
            var results = _cartDal.GetList(x => x.UserId == userId);
            return new SuccessDataResult<IList<Cart>>(results);
        }



        public IDataResult<List<Cart>> GetList()
        {
            var cart = _cartDal.GetList().ToList();
            return new SuccessDataResult<List<Cart>>(cart);
        }



        public IResult Update(CartUpdateDto cartUpdateDto)
        {
            var variables = _cartDal.Get(x => x.UserId == cartUpdateDto.UserId && x.CartId == cartUpdateDto.CartId);
            if (variables != null)
            {
                var cartUpdate = new Cart
                {
                    CartId = cartUpdateDto.CartId,
                    UserId = cartUpdateDto.UserId,
                    ProductId = cartUpdateDto.ProductId,
                    OrderAmount = cartUpdateDto.OrderAmount,
                    ModifiedTime = DateTime.Now
                };

                _cartDal.Update(cartUpdate);
                return new SuccessResult(Messages.CartUpdated);
            }
            return new ErrorResult(Messages.idgiriniz);



           
           



        }
    }
}
