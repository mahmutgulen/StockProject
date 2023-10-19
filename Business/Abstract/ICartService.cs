using Core.Utilities.Results;
using Entities.Concrete;
using Entities.Concrete.Dtos.Cart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICartService
    {
        IDataResult<List<Cart>> GetList();
        IDataResult<IList<Cart>> GetCart( int userId);

        IResult Add(CartAddDto cartAddDto);
        IResult Delete(CartDeleteDto cartDeleteDto);
        IResult Update(CartUpdateDto cartUpdateDto);
    }
}
