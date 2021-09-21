using System.ComponentModel.DataAnnotations;

namespace Application.ViewModel
{
    public class IndexUserNameViewModel
    {
        [Display(Name = "آیدی")]
        public string Id { get; set; }
        [Display(Name = "نام کاربری")]
        public string UserName { get; set; }
        [Display(Name = "ایمیل")]
        public string Email { get; set; }
        [Display(Name = "شماره تلفن")]
        public string PhoneNumber { get; set; }

    }
}