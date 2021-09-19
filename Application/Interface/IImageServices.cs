using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.ViewModel;

namespace Application.Interface
{
    public interface IImageServices
    {
        Task<CreateProductViewModel> SaveImage(CreateProductViewModel model,string wwwrootpath,string extension);
        Task Delete(string imgname,string wwwrootpath);
        Task<CreateProductViewModel> SaveImageNoPicture(CreateProductViewModel model);
    }
}
