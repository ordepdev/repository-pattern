using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPattern.BL
{
    public static class FooRepository
    {
        public static DL.Foo GetByFooName(this IRepository<DL.Foo> repository, string foo)
        {
            if (string.IsNullOrEmpty(foo))
                return null;

            return repository.FirstOrDefault(x => x.Name == foo);
        }
    }
}
