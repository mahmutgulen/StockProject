using Core.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.Dtos.Order
{
    public class OrderDeleteDto:IDto
    {
        public int OrderId { get; set; }
    }
}
