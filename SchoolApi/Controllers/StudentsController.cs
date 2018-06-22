using SchoolApi.Models;
using SchoolApi.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SchoolApi.Controllers
{
    public class StudentsController : ApiController
    {
		private SchoolContext db = new SchoolContext();

		[HttpGet]
		[ActionName("List")]
		public JsonResponse List() {
			return new JsonResponse { Data=db.Students.ToList()};
		}
		[HttpGet]
		[ActionName("Get")]
		public JsonResponse Get(int? id) {
			if (id == null)
				return new JsonResponse { Error=null,Message="The value is null",Result="Failed"};
			return new JsonResponse { Data = db.Students.Find(id) };			
		}

		[HttpPost]
		[ActionName("Create")]
		public JsonResponse Create(Student student)
		{
			if (student == null)
				return new JsonResponse { Error = null, Message = "The value is null", Result = "Failed" };
			if (!ModelState.IsValid)
				return new JsonResponse { Error = null, Message = "The value is not valid", Result = "Failed" };
			db.Students.Add(student);
			db.SaveChanges();
			return new JsonResponse();
		}

		[HttpPost]
		[ActionName("Change")]
		public JsonResponse Change(Student student) {
			if (student == null)
				return new JsonResponse { Error = null, Message = "The value is null", Result = "Failed" };
			if (!ModelState.IsValid)
				return new JsonResponse { Error = null, Message = "The value is not valid", Result = "Failed" }; ;
			var cha = db.Students.Find(student.Id);
			cha.MajorId = student.MajorId;
			cha.Name = student.Name;
			cha.Sat = student.Sat;
			cha.Major = student.Major;
			db.SaveChanges();
			return new JsonResponse();
		}

		[HttpPost]
		[ActionName("Remove")]
		public JsonResponse Remove(Student student) {
			if (student == null)
				return new JsonResponse { Error = null, Message = "The value is null", Result = "Failed" };
			if (!ModelState.IsValid)
				return new JsonResponse { Error = null, Message = "The value is not valid", Result = "Failed" };
			var cha = db.Students.Find(student.Id);
			db.Students.Remove(cha);
			db.SaveChanges();
			return new JsonResponse();
		}
    }
}
