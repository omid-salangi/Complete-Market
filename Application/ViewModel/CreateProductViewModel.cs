using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Application.ViewModel
{
    public class CreateProductViewModel
    {
        [Required(ErrorMessage = "نام محصول را وارد کنید.")]
        [Display(Name = "نام محصول")]
        public string Name { get; set; }

        [Display(Name = "توضیح کوتاه")] 
        public string ShortDescription { get; set; }
        [Required(ErrorMessage = "توضیحی برای محصول بنویسید.")]
        [Display(Name = "توضیح بلند")]
        public string  LongDescription { get; set; }
        [Display(Name = "تصویر محصول")]
        public IFormFile ImageFile { get; set; }
        [Display(Name = "تعداد موجودی")]
        [Range(1, int.MaxValue, ErrorMessage = "فقط اعداد مثبت وارد کنید.")]
        public int  quantityInStock { get; set; }
        [Display(Name = "قیمت محصول")]
        [DataType(DataType.Currency)]
        public double Price { get; set; }

        public string ImageName { get; set; }


    }
}
