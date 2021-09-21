using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public static class ClaimStore
    {
        public static List<Claim> AllClaims = new List<Claim>()
        {
            new  Claim(ClaimTypeStore.ProductCreate,true.ToString()),
            new  Claim(ClaimTypeStore.ProductDelete,true.ToString()),
            new  Claim(ClaimTypeStore.ProductDetail,true.ToString()),
            new  Claim(ClaimTypeStore.ProductEdit,true.ToString()),
            new  Claim(ClaimTypeStore.ProductList,true.ToString())
    };
    }

    public static class ClaimTypeStore
    {
        public const string ProductList = "ProductList";
        public const string ProductCreate = "ProductCreate";
        public const string ProductEdit = "ProductEdit";
        public const string ProductDelete = "ProductDelete";
        public const string ProductDetail = "ProductDetail";
    }
}
