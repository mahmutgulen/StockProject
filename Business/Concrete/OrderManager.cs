using Business.Abstract;
using Business.Contants;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.Concrete.Dtos.Cart;
using Entities.Concrete.Dtos.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class OrderManager : IOrderService
    {
        private IOrderDal _orderDal;
        private readonly ICartDal _cartDal;
        private readonly IUserDal _userDal;
        private readonly IProductDal _productDal;
        private readonly IProductService _productService;

        public OrderManager(IUserDal userDal, ICartDal cartDal, IOrderDal orderDal)
        {
            _userDal = userDal;
            _cartDal = cartDal;
            _orderDal = orderDal;
        }

        public IDataResult<List<Order>> GetList()
        {
            var order = _orderDal.GetList().ToList();
            return new SuccessDataResult<List<Order>>(order);
        }

        public IDataResult<IList<Order>> GetOrder(int userId)
        {
            var result = _orderDal.GetList(x => x.UserId == userId);
            return new SuccessDataResult<IList<Order>>(result);
        }

        //public IResult Add(OrderAddDto orderAddDto)
        //{
        //    var user = _userDal.Get(x => x.UserId == orderAddDto.UserId);
        //    Random rnd = new();
        //    var orderAdd = new Order
        //    {
        //        UserId = orderAddDto.UserId,
        //        OrderNumber = rnd.Next(),
        //        TotalPrice = rnd.Next()
        //    };
        //    _orderDal.Add(orderAdd);
        //    return new SuccessResult();

        //}

        //public IResult Delete(OrderDeleteDto orderDeleteDto)
        //{
        //    var orderDelete = new Order
        //    {
        //        OrderId = orderDeleteDto.OrderId
        //    };

        //    _orderDal.Delete(orderDelete);
        //    return new SuccessResult(Messages.CartDeleted);
        //}

        //public IResult Update(Order order)
        //{
        //    var orderUpdate = new Order
        //    {
        //        OrderId = order.OrderId,
        //        OrderNumber = order.OrderNumber,
        //        UserId = order.UserId,
        //        TotalPrice = order.TotalPrice
        //    };
        //    _orderDal.Update(orderUpdate);
        //    return new SuccessResult("Sipariş Güncellendi");
        //}
    }
}
