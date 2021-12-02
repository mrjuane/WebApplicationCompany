using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DLCompany.Factory;
using DLCompany.Model;
using System.Collections.Generic;
using System.Linq;

namespace UTDLCompany
{
    [TestClass]
    public class TestEmployee
    {
        [TestMethod]
        public void TestInsert()
        {
            IBaseController<EmployeeHeader> employee = new EmployeeController();

            var resul = employee.Insert(new EmployeeHeader() { Id = 1, FirstName = "Juan", LastName = "perez" });

            Assert.IsTrue(resul);
        }
        [TestMethod]
        public void TestGetEntity()
        {
            IBaseController<EmployeeHeader> employee = new EmployeeController();

            var resul = employee.GetEntity(1);

            Assert.IsTrue(resul != null);
        }

        [TestMethod]
        public void TestGetEntities()
        {
            IBaseController<EmployeeHeader> employee = new EmployeeController();

            var resul = employee.GetEntities().ToList();

            Assert.IsTrue(resul.Count > 0);
        }

        [TestMethod]
        public void TestUpdate()
        {
            IBaseController<EmployeeHeader> employee = new EmployeeController();

            var entity = employee.GetEntity(1);

            if (entity != null)
            {
                entity.LastName = "sal";
            }

            var resul = employee.Update(entity);

            Assert.IsTrue(resul);
        }

        [TestMethod]
        public void TestDelete()
        {
            IBaseController<EmployeeHeader> employee = new EmployeeController();

            var entityResul = employee.Insert(new EmployeeHeader() { Id = 1, FirstName = "Juan", LastName = "perez" });

            var entity = employee.GetEntity(1);

            var resul = employee.Delete(entity);

            Assert.IsTrue(resul);
        }
    }
}
