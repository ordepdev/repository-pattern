using System;
using System.Collections.Generic;
using System.Linq;
using RepositoryPattern.BL;
using RepositoryPattern.DL;

namespace RepositoryPattern.Core
{
    public class RepositoryPattern
    {
        public UnitOfWork unitOfWork;

        public RepositoryPattern()
        {
            unitOfWork = new UnitOfWork();

            unitOfWork.Repository<DL.Foo>().Add(new Foo() { Name = "foo" });
            unitOfWork.Commit();

            var foo = unitOfWork.Repository<DL.Foo>().Where(x => x.Name == "foo");
            foo.Name = "bar";

            unitOfWork.Repository<DL.Foo>().Update(foo);
            unitOfWork.Commit();

            var bar = unitOfWork.Repository<DL.Foo>().GetByFooName("bar");

            unitOfWork.Repository<DL.Foo>().Remove(bar);
            unitOfWork.Commit();
        }
    }
}