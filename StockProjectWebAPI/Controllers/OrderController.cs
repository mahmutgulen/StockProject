using Business.Abstract;
using Business.Contants;
using Entities.Concrete;
using Entities.Concrete.Dtos.Cart;
using Entities.Concrete.Dtos.Order;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace StockProjectWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet("getorder")]
        [Authorize(Roles = "Member,Admin")]
        public IActionResult GetOrder(int userId)
        {
            var result = _orderService.GetOrder(userId).Data;
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpGet("getall")]
        [Authorize(Roles = "Member,Admin")]
        public IActionResult GetList()
        {
            var result = _orderService.GetList();
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest();
        }

        //[HttpPost("delete")]
        //[Authorize(Roles = "Member,Admin")]
        //public IActionResult Delete(OrderDeleteDto orderDeleteDto)
        //{
        //    var result = _orderService.Delete(orderDeleteDto);

        //    if (result.Success)
        //    {
        //        return Ok(result.Message);
        //    }
        //    return BadRequest(result);
        //}

        //[HttpPost("update")]
        //[Authorize(Roles = "Member,Admin")]
        //public IActionResult Update(Order order)
        //{
        //    var result = _orderService.Update(order);
        //    if (result.Success)
        //    {
        //        return Ok(result.Message);
        //    }
        //    return BadRequest(result);
        //}


        //[HttpPost("add")]
        //[Authorize(Roles = "Member,Admin")]
        //public IActionResult Add(OrderAddDto orderAddDto)
        //{
        //    var result = _orderService.Add(orderAddDto);
        //    if (result.Success)
        //    {
        //        return Ok(result.Message);
        //    }

        //    return BadRequest(Messages.ProductNotExistsStock);
        //}

    }
}
