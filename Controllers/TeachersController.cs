using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using student.Data;
using student.Models;

namespace student.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TeachersController : ControllerBase
    {
        private readonly StudentsContext _context;
        public TeachersController(StudentsContext tcontext){
            _context=tcontext;
        }

        [HttpPost]
        public JsonResult CreateEdit(Teachers teacher)
        {
            if(teacher.Id==0){
                _context.Teachers.Add(teacher);
            }
            else{
                var teacherinDb=_context.Teachers.Find(teacher.Id);
                if(teacherinDb==null){
                    return new JsonResult(NotFound());
                }
                teacherinDb=teacher;
            }
            _context.SaveChanges();
            return new JsonResult(Ok(teacher));
        }

        [HttpGet]
        public JsonResult getAll(){
            var result = _context.Teachers.ToList();
            return new JsonResult(Ok(result));
        }

        [HttpGet("{id}")]
        public JsonResult get(int id)
        {
            var teacher=_context.Teachers.Find(id);
            if(teacher==null)
                return new JsonResult(NotFound());
            return new JsonResult(Ok(teacher));
        }

        [HttpDelete("{id}")]
        public JsonResult delete(int id)
        {
            var teacherinDb=_context.Teachers.Find(id);
            if(teacherinDb==null)
                return new JsonResult(NotFound());
            var result =_context.Teachers.Remove(teacherinDb);
            _context.SaveChanges();
            return new JsonResult(Ok(result));
        }
    }
}