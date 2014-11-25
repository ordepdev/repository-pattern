using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RepositoryPattern.BL;
using RepositoryPattern.DL;

namespace RepositoryPattern.Tests
{
    [TestClass]
    public class RepositoryPatternTests
    {
        [TestMethod]
        public void TypesMustMatch()
        {
            UnitOfWork uow = new UnitOfWork();
            var repo = uow.Repository<DL.Foo>().GetType();
            Assert.AreEqual(typeof (DL.Foo).FullName, uow.Repository<DL.Foo>().GetType().GenericTypeArguments[0].FullName);
        }

        [TestMethod]
        public void ShouldInsertOneRow()
        {
            UnitOfWork uow = new UnitOfWork();

            uow.Repository<DL.Foo>().Add(new Foo() { Name = "foo" });
            uow.Commit();

            Assert.AreNotEqual(0, uow.Repository<DL.Foo>().Where(x => x.Name == "foo").Count);
        }
    }
}
