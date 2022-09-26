using AngularApi.Model;
using AngularApi.Repository;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AngularApi.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("AllowSpecificOrigins")]
    [ApiController]
    public class TodoApiController : ControllerBase
    {
        private readonly TodoContext _db;
        private readonly ITodoItemRepository _itodoItemRepository;

        public TodoApiController(TodoContext todoContext, ITodoItemRepository todoItemRepository)
        {
            _db = todoContext;
            _itodoItemRepository = todoItemRepository;
        }
        //here we write the code for Get
        //[Route("~/api/GetAllUserData")]
        //[HttpGet]
        //public IActionResult GetAllUserData()
        //{
        //    var res = _db.TodoItems.Where(x => x.IsActive == true).ToList();

        //    List<TodoItem> TodoModelObj = new List<TodoItem>();
        //    if (res == null)
        //    {
        //        return Ok("Data Not Found");
        //    }
        //    else
        //    {
        //        foreach (var item in res)
        //        {
        //            TodoModelObj.Add(new TodoItem
        //            {
        //                Id = item.Id,
        //                First_Name = item.First_Name,
        //                Last_Name = item.Last_Name,
        //                Email = item.Email,
        //                Password = item.Password,
        //                IsActive=item.IsActive
        //            });
        //        }
        //    }

        //    return Ok(TodoModelObj);
        //}
        [Route("~/api/GetAllUserData")]
        [HttpGet]
        public ActionResult<List<TodoItem>> GetAllUserData()
        {
            List<TodoItem> res = _itodoItemRepository.GetAllUserData().ToList();
            return res;
        }
        [Route("~/api/GetAllUserData2")]
        [HttpGet]
        public string GetAllUserData2()
        {
            return "Success";
        }
        //[Route("~/api/GetAllUserData/{id}")]
        //[HttpGet]
        //public IActionResult GetDataById(long id)
        //{
        //    try
        //    {
        //        var result = _db.TodoItems.Find(id);
        //        if (result == null)
        //        {
        //            return NotFound();
        //        }
        //        return Ok(result);
        //    }
        //    catch(Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        [Route("~/api/GetAllUserData/{id}")]
        [HttpGet]
        public TodoItem GetDataById(long id)
        {
            TodoItem result = _itodoItemRepository.GetAllUserData(id);
            return result;
        }

        //here we write the for post
        //[Route("~/api/CreateTodoItem")]
        //[HttpPost]
        //public async Task<TodoItem> CreateTodoItem(TodoItem _object)
        //{
        //    var obj = await _db.TodoItems.AddAsync(_object);
        //    _db.SaveChanges();
        //    return obj.Entity;
        //}

        [Route("~/api/CreateTodoItem")]
        [HttpPost]
        public async Task<TodoItem> CreateTodoItem(TodoItem _object)
        {
            var res =await _itodoItemRepository.CreateTodoItem(_object);
            return res;

        }

        [Route("~/api/DeleteTodoItem/{id}")]
        public IActionResult Delete(long id)
        {
            try
            {
                var data = _db.TodoItems.Where(x => x.Id == id && x.IsActive).FirstOrDefault();
                if (data != null)
                {
                    data.IsActive = false;
                    _db.TodoItems.Update(data);
                    _db.SaveChanges();
                    return Ok(1);
                }
                else
                {
                    return Ok(0);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            //_db.Remove(_obj);
            //_db.SaveChanges();
        }

        [Route("~/api/UpdateTodoItem/{id}")]
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(long id, TodoItem product)
        {
            if (id != product.Id)
            {
                return BadRequest();
            }

            _db.Entry(product).State = EntityState.Modified;

            try
            {
                await _db.SaveChangesAsync();
                return Ok("update SuccessFully");
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw ex;
            }

            return NoContent();
        }
        public MyClass TestMethod()
        {
            return new MyClass();
        }
    }
    public class MyClass
    {
        public int Name { get; set; }
        private int Name2 { get; set; }
    }
}
