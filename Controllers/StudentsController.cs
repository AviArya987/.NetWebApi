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
    public class StudentsController : ControllerBase
    {
        private readonly StudentsContext _context;
        public StudentsController(StudentsContext context){
            _context = context;
        }

        [HttpPost]
        public JsonResult create(Students student){
            if(student.Id==0){
                _context.Students.Add(student);
            }
            else{
                var studentinDB = _context.Students.Find(student.Id);
                if(studentinDB==null){
                    return new JsonResult(NotFound());
                }
                studentinDB=student;
            }
            _context.SaveChanges();
            return new JsonResult(Ok(student));
        }

        [HttpGet]
        public JsonResult GetAll(){
            var result=_context.Students.ToList();
            return new JsonResult(Ok(result));
        }

        [HttpGet("{id}")]
        public JsonResult GetOne(int id){
            var studentinDb=_context.Students.Find(id);
            if(studentinDb==null){
                return new JsonResult(NotFound());
            }
            return new JsonResult(Ok(studentinDb));
        }

        [HttpDelete("{id}")]
        public JsonResult DeleteStudent(int id){
            var studentinDb=_context.Students.Find(id);
            if(studentinDb==null){
                return new JsonResult(NotFound());
            }
            var result=_context.Students.Remove(studentinDb);
            _context.SaveChanges();
            return new JsonResult(Ok(result));
       }
    }
}