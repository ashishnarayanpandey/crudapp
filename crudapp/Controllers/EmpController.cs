using crudapp.Data;
using crudapp.Models;
using crudapp.EmpVM;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Drawing;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace crudapp.Controllers
{
    public class EmpController : Controller
    {
        private readonly DataContext _Context;
        private readonly IWebHostEnvironment _environment;


        public EmpController(DataContext context, IWebHostEnvironment environment)
        {
            _Context = context;
            _environment = environment;
        }


        public IActionResult Index()
        {
            var data = _Context.Employees.ToList();
            return View(data);
        }

        public IActionResult Create()
        {
            return View();
        }




        [HttpPost]
        public IActionResult Create(EmployeeVM emp)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    string uniqeFile = uploadImage(emp);
                    var data = new Employee
                    {
                        Name = emp.Name,
                        Age = emp.Age,
                        City = emp.City,
                        Salary = emp.Salary,
                        ImagePath = uniqeFile
                    };
                    _Context.Employees.Add(data);
                    _Context.SaveChanges();
                    TempData["Success"] = "Record Successfully Save";
                    return RedirectToAction("Index");

                }

            }
            catch(Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }
            return View(emp);

            //var path = _environment.WebRootPath;
            //var filepath = "Content/Images/" + emp.ImagePath.FileName;
            //var fullpath = Path.Combine(path, filepath);
            //uploadFile(emp.ImagePath, fullpath);
            //var data = new Employee()
            //{
            //    Name = emp.Name,
            //    Age = emp.Age,
            //    City = emp.City,
            //    Salary = emp.Salary,
            //    ImagePath = filepath
            //};
            //_Context.Add(data);
            //_Context.SaveChanges();
            
        }

        private string uploadImage(EmployeeVM em)
        {
            string uploagUniqFile = string.Empty;
            if(em.ImagePath!=null)
            {
                string uploadFolder = Path.Combine(_environment.WebRootPath, "Content/Images/");
                uploagUniqFile = Guid.NewGuid().ToString() + "_" + em.ImagePath.FileName;
                string filePath = Path.Combine(uploadFolder, uploagUniqFile);
                using (var fileStrem = new FileStream(filePath, FileMode.Create))
                {
                    em.ImagePath.CopyTo(fileStrem);
                }
            }
            return uploagUniqFile;
        }


        //public void uploadFile(IFormFile file, string path)
        //{
        //    FileStream stream = new FileStream(path, FileMode.Create);
        //    file.CopyTo(stream);
        //}


        public IActionResult Edit(int id)
        {
            
            var data = _Context.Employees.Where(Model => Model.Id == id).FirstOrDefault();
            if(data != null)
            {
                return View(data);
            }
            else
            {
                return RedirectToAction("Index");
            }
            
        }
        [HttpPost]

        public IActionResult Edit(EmployeeVM emp)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    var data=_Context.Employees.Where(e=>e.Id==emp.Id).FirstOrDefault();
                    string uniqeFileName = string.Empty;
                    if(emp.ImagePath!=null)
                    {
                        string filePath = Path.Combine(_environment.WebRootPath, "Content/Images", data.ImagePath);
                        if(System.IO.File.Exists(filePath))
                        {
                            System.IO.File.Delete(filePath);
                        }
                    }
                    uniqeFileName = uploadImage(emp);
                    data.Name = emp.Name;
                    data.Age=emp.Age;
                    data.City = emp.City;
                    data.Salary=emp.Salary;
                    if(emp.ImagePath!= null)
                    {
                        data.ImagePath = uniqeFileName;
                    }
                    _Context.Employees.Update(data);
                    _Context.SaveChanges();
                }
                else
                {
                    return View();
                }
            }
            catch(Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }
            

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            else
            {
                var data = _Context.Employees.Where(e => e.Id == id).SingleOrDefault();
                if (data != null)
                {
                    string deleteFromFolder = Path.Combine(_environment.WebRootPath, "Content/Images/");
                    string currentImages = Path.Combine(Directory.GetCurrentDirectory(), deleteFromFolder, data.ImagePath);
                    if (currentImages != null)
                    {
                        if (System.IO.File.Exists(currentImages))
                        {
                            System.IO.File.Delete(currentImages);
                        }
                    }
                    _Context.Employees.Remove(data);
                    _Context.SaveChanges();

                    TempData["success"] = "record delete";
                }
            }
            return RedirectToAction("Index");

        }
        

        public IActionResult Details(int id)
        {
            var data = _Context.Employees.Where(Model => Model.Id == id).FirstOrDefault();
            return View(data);
        }

    }
}
