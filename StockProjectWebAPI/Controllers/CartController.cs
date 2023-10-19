using Business.Abstract;
using Business.Concrete;
using Business.Contants;
using Core.Utilities.Security.Jwt;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Concrete.Dtos.Cart;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace StockProjectWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICartService _cartService;

        public CartController(ICartService cartService)
        {
            _cartService = cartService;
        }

        [HttpPost("add")]
        [Authorize(Roles = "Member,Admin")]
        public IActionResult Add(CartAddDto cartAddDto)
        {
            var result = _cartService.Add(cartAddDto);
            if (result.Success)
            {
                return Ok(result.Message);
            }

            return BadRequest(result.Message);
        }

        [HttpPost("update")]
        [Authorize(Roles = "Member,Admin")]
        public IActionResult Update(CartUpdateDto cartUpdateDto)
        {
            var result = _cartService.Update(cartUpdateDto);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("delete")]
        [Authorize(Roles = "Member,Admin")]
        public IActionResult Delete(CartDeleteDto cartDeleteDto)
        {
            var result = _cartService.Delete(cartDeleteDto);

            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("getcart")]
        [Authorize(Roles = "Member,Admin")]
        public IActionResult GetCart(int userId)
        {
            //cartid getiriyor
            var result = _cartService.GetCart(userId).Data;
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
            var result = _cartService.GetList();
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest();
        }


    }
}
