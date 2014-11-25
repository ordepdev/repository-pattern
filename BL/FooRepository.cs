using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPattern.BL
{
    public static class FooRepository
    {
        // Summary
        //      Creates an extension method for BL.Repository
        //      when called with - this IRepository<DL.Foo> repository
        //      as first argument. Defaults can be accessed
        //      by typing - repository.{method}.
        public static DL.Foo GetByFooName(this IRepository<DL.Foo> repository, string foo)
        {
            if (string.IsNullOrEmpty(foo))
                return null;

            return repository.FirstOrDefault(x => x.Name == foo);
        }
    }
}