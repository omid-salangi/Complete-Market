using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Repository;
using Domain.Interface;
using Xunit;

namespace Data.test
{
    public class Test:IDisposable
    {
        private ICategoryRepository _categoryRepository;

        public Test(ICategoryRepository repository)
        {
            _categoryRepository = repository;
        }

     
        public void Dispose()
        {
        }
    }
}
