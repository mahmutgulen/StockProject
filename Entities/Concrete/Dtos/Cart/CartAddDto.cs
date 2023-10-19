using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.Dtos.Cart
{
    public class CartAddDto : IDto
    {
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public int OrderAmount { get; set; }
    }
}
