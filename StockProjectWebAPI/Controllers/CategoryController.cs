using Business.Abstract;
using Entities.Concrete;
using Entities.Concrete.Dtos.Category;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace StockProjectWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {

        private ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet("getall")]
        [Authorize(Roles = "Member,Admin")]
        public IActionResult GetList()
        {
            var result = _categoryService.GetList();
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest();
        }

        //FromBody - FromQuery

        [HttpGet("getbyid")]
        [Authorize(Roles = "Member,Admin")]
        public IActionResult GetById(int categoryId)
        {

            var result = _categoryService.GetById(categoryId).Data;
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest();
        }



        [HttpPost("add")]
        [Authorize(Roles = "Admin")]
        public IActionResult Add(CategoryAddDto categoryAddDto)
        {
            var result = _categoryService.Add(categoryAddDto);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }


        [HttpPost("update")]
        [Authorize(Roles = "Admin")]
        public IActionResult Update(Category category)
        {
            var result = _categoryService.Update(category);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("delete")]
        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int categoryId)
        {
            var result = _categoryService.Delete(categoryId);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }
    }
}
