using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace crudapp.EmpVM
{
    public class SinupLoginVM
    {
        public int id { get; set; }
        [Required(ErrorMessage ="Name is Required")]
        [Remote(action: "emailIsExists", controller: "Login")]
        public string username { get; set; }
        [Required(ErrorMessage = "Password is Required")]
        public string password { get; set; }
        [Required(ErrorMessage = "Confirm Password is Required")]
        [Compare("password", ErrorMessage ="Password is Mismatch")]
        public string ReEnterPassword { get; set; }
        [Required(ErrorMessage = "Email is Required")]
        [RegularExpression("^([\\w\\.\\-]+)@([\\w\\-]+)((\\.(\\w){2,3})+)$", ErrorMessage ="Wrong Email id")]
        
        public string email { get; set; }
        [Required(ErrorMessage = "Phone Number is Required")]
        [RegularExpression("\\+?\\d[\\d -]{8,12}\\d",ErrorMessage ="Wrong Mobile Number")]
        public long? phone { get; set; }
        public bool IsActive { get; set; }
    }
}
