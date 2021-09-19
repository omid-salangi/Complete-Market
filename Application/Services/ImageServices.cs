using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Interface;
using Application.ViewModel;

namespace Application.Services
{
    public class ImageServices:IImageServices
    {
        public async Task Delete(string imgname,string wwwrootpath)
        {
            string path = Path.Combine(wwwrootpath, "img", imgname);
            if (File.Exists(path) && imgname!="nopicpath.jpg")
            {
                File.Delete(path);
            }
        }

        public async Task<CreateProductViewModel> SaveImage(CreateProductViewModel model,string wwwrootpath,string extension)
        {
            string fileName = Path.GetFileNameWithoutExtension(model.ImageFile.FileName);
            model.ImageName = fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
            string path = Path.Combine(wwwrootpath, "img", fileName);
            using (var fileStream = new FileStream(path, FileMode.Create))
            {
                await model.ImageFile.CopyToAsync(fileStream);
            }

            model.ImageUrl = Path.Combine("/" + "img", model.ImageName).Replace('\\', '/');
            return model;
        }

        public async Task<CreateProductViewModel> SaveImageNoPicture(CreateProductViewModel model)
        {
           string  nopicpath = Path.Combine("/"+ "img", "nopicture.jpg").Replace('\\','/');
            model.ImageName = "nopicture.jpg";
            model.ImageUrl = nopicpath;

            return model;
        }

    }
}
