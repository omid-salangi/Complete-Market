using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModel
{
    public class ProductViewModel
    {
        [Display(Name = "نام محصول")]
        public string Name { get; set; }
        [Display(Name = "توضیح کوتاه")]
        public string ShortDescription { get; set; }
        [Display(Name = "توضیح بلند")]
        public string LongDescription { get; set; }
        [Display(Name = "تعداد ویزیت ")]
        public int  VisitCount { get; set; }
        [Display(Name = "تعداد خرید")]
        public int  BuyCount { get; set; }
        [Display(Name = "تصویر محصول")]
        public string ImgUrl { get; set; }

        public int ProductId { get; set; }
        [Display(Name = "تعداد موجود")]
        public int  quantityinstock { get; set; }
        [Display(Name = "قیمت")]
        public double Price { get; set; }

    }
}
