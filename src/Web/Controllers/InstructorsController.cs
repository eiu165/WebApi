using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MvcApplication18.Controllers
{
    public class Instructor
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class InstructorsController : ApiController
    {
        static List<Instructor> _instructors = InitInstructors();
        public static List<Instructor> InitInstructors()
        {
            var r = new List<Instructor>();
            r.Add(new Instructor { Id = 1, Name = "Cory" });
            r.Add(new Instructor { Id = 2, Name = "Jeff" });
            r.Add(new Instructor { Id = 3, Name = "Justin" });
            return r;
        }

        // get   {baseUrl}/api/Instructors
        [HttpGet]
        public IEnumerable<Instructor> Get()
        {
            var instructors = _instructors;
            return instructors;
        }


        // get   {baseUrl}/api/Instructors/1
        [HttpGet]
        public Instructor Get(int id)
        {
            var instructor = (from i in _instructors
                              where i.Id == id
                              select i).FirstOrDefault();
            return instructor;
        }

        //Post Url           {baseUrl}/api/Instructors
        //Request Headers    Content-Type:application/json
        //Request Body       {"Id":0, "Name":"Jon"}
        [HttpPost]
        public Instructor Post(Instructor instructor)
        {
            var newId = _instructors.Count + 1;
            instructor.Id = newId;
            _instructors.Add(instructor);
            return instructor;
        }

        //Put Url            {baseUrl}/api/Instructors
        //Request Headers    Content-Type:application/json
        //Request Body       {"Id":1, "Name":"Jooooooooooo"}
        [HttpPut]
        public Instructor Put(Instructor instructor)
        {
            var realinstructor = (from i in _instructors
                                  where i.Id == instructor.Id
                                  select i).FirstOrDefault();
            realinstructor.Name = instructor.Name;
            return instructor;
        }

        // delete   {baseUrl}/api/Instructors/1
        [HttpDelete]
        public void Delete(int id)
        {
            var instructor = (from i in _instructors
                              where i.Id == id
                              select i).FirstOrDefault();
            _instructors.Remove(instructor);
        }
    }
}
