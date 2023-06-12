using crudapp.Data;
using crudapp.EmpVM;
using crudapp.Models;
using Microsoft.AspNetCore.Mvc;

namespace crudapp.Controllers
{
    public class LoginController : Controller
    {
        private readonly DataContext _dataContext;

        public LoginController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public IActionResult Sinup()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Sinup(SinupLoginVM model)
        {
            if(ModelState.IsValid)
            {
                var data = new Sinup_Login()
                {
                    username = model.username,
                    password = model.password,
                    email = model.email,
                    phone = model.phone,
                    IsActive = model.IsActive

                };
                _dataContext.sinup_Logins.Add(data);
                _dataContext.SaveChanges();
                return RedirectToAction("Login");
            }
            else
            {
                return View(model);
            }

            
        }
        [AcceptVerbs("Post","Get")]
        public IActionResult emailIsExists(string name)
        {
            var extists = _dataContext.sinup_Logins.Where(e=>e.username==name).SingleOrDefault();
            if(extists!=null)
            {
                return Json($"username {name} already in use!");
            }
            else
            {
                return Json(true);
            }
            
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginVM model)
        {
            var data = _dataContext.sinup_Logins.Where(e => e.email == model.email).SingleOrDefault();
            if(data != null)
            {
                bool isValid=(data.email==model.email && data.password==model.password);
                return RedirectToAction("Index","Home");
            }
            else
            {
                return View(model);
            }
            
        }

    }
}
