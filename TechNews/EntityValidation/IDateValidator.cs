using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechNews.Business.EntityValidation
{
    interface IDateValidator
    {
        public bool BeAValidDate<T>(T date);
    }
}
