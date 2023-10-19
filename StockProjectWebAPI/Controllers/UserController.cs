using Business.Abstract;
using Business.Contants;
using Core.Entities;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using Entities.Concrete.Dtos;
using Entities.Concrete.Dtos.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Data;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Security.Claims;

namespace StockProjectWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class UserController : ControllerBase
    {
        private IUserService _userService;
       

        public UserController(IUserService userService)
        {
            _userService = userService;
            
        }



        [HttpGet("getall")]
        public IActionResult GetList()
        {
            var result = _userService.GetList().Data;
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpGet("getbyid")]

        public IActionResult GetById(int userId)
        {
            var result = _userService.GetById(userId).Data;
            if (result != null)
            {
                return Ok(result);
            }
            else if (result == null)
            {
                return Ok($"[{userId}] Id'ye Sahip " + Messages.UserNotFound);
            }
            return BadRequest();
        }

        [HttpPost("add")]
        public IActionResult Add(UserAddDto userAddDto,string password)
        {
            var result = _userService.Add(userAddDto,password);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }


        [HttpPost("update")]
        public IActionResult Update(UserUpdateDto userUpdateDto,string password)
        {
            var result = _userService.Update(userUpdateDto,password);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("delete")]
        public IActionResult Delete(int userId)
        {
            var result = _userService.Delete(userId);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }

        



    }
}
