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
        public UnitOfWork uow;

        public RepositoryPatternTests()
        {
            uow = new UnitOfWork();
        }

        [TestMethod]
        public void TypesMustMatch()
        {
            var repo = uow.Repository<DL.Foo>().GetType();
            Assert.AreEqual(typeof (DL.Foo).FullName, uow.Repository<DL.Foo>().GetType().GenericTypeArguments[0].FullName);
        }

        [TestMethod]
        public void ShouldInsertOneRow()
        {
            uow.Repository<DL.Foo>().Add(new Foo() { Name = "foo" });

            uow.Commit();

            Assert.AreNotEqual(0, uow.Repository<DL.Foo>().Where(x => x.Name == "foo").Count);
        }

        [TestMethod]
        public void ExtendedMethodShouldRetrieveOneResult()
        {
            Assert.AreNotEqual(null, uow.Repository<DL.Foo>().GetByFooName("foo"));
        }
        
        [TestMethod]
        public void FirstOrDefaultShouldRetrieveOneResult()
        {
            Assert.AreNotEqual(null, uow.Repository<DL.Foo>().FirstOrDefault());
        }
        
        [TestMethod]
        public void RemoveShouldWork()
        {
            var before = uow.Repository<DL.Foo>().All();
            var foo = uow.Repository<DL.Foo>().FirstOrDefault();
            
            uow.Repository<DL.Foo>().Remove(foo);
            uow.Commit();
            
            var after = uow.Repository<DL.Foo>().All();
            
            Assert.AreNotEqual(before.Count, after.Count);
        }
    }
}
