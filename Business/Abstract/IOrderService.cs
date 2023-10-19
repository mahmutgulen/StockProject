using Core.Utilities.Results;
using Entities.Concrete;
using Entities.Concrete.Dtos.Cart;
using Entities.Concrete.Dtos.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IOrderService
    {
        IDataResult<List<Order>> GetList();
        IDataResult<IList<Order>> GetOrder(int userId);

        //IResult Add(OrderAddDto orderAddDto);
        //IResult Delete(OrderDeleteDto orderDeleteDto);
        //IResult Update(Order order);
    }
}
