using System.ComponentModel.DataAnnotations;

namespace MyTask.Web.Models.ViewModels
{
    public class RegisterPostViewModel
    {
        public int Id { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        [RegularExpression("^([\\w\\.\\-]+)@([\\w\\-]+)((\\.(\\w){2,3})+)$", ErrorMessage ="Invalid Email")]
        public string Email { get; set; }
        [Required]
        [MinLength(6,ErrorMessage ="Password length shoul be 8 characters")]
        [RegularExpression("(?=^.{8,}$)((?=.*\\d)|(?=.*\\W+))(?![.\\n])(?=.*[A-Z])(?=.*[a-z]).*$",ErrorMessage ="8 characters including UpperCase,LowerCase,SpecialCharacter and one number")]
        public string Password { get; set; }
    }
}
