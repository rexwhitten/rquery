using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RaasRM.Extensions.Test.Db;

namespace RaasRM.Extensions.Test
{
    [TestClass]
    public class RqueryTests
    {
        private void LoadTestRecords()
        {
            int i = 0;
            int c = 100;

            using (Test.Db.TestDbEntities db = new TestDbEntities())
            {
                db.Headers.SqlQuery("TRUNCATE TABLE [dbo].[Headers]");
            }

            while (i <= (c - 1))
            {
                using (Test.Db.TestDbEntities db = new TestDbEntities())
                {
                    Header h = new Header();
                    h.PublicId = Guid.NewGuid();
                    h.Active = true;
                    h.CreateDate = DateTime.Now;
                    h.UpdateDate = DateTime.Now;
                    db.Headers.Add(h);
                    db.SaveChanges();
                }
                i++;
            }
        }

        [TestMethod]
        public void TestMethod1()
        {
            LoadTestRecords();

            var context = new Test.Db.TestDbEntities();

            var result1 = context.Headers.Search(record => record.Id > 0);

            Assert.IsTrue(result1.Count != 0);

        }

        [TestMethod]
        public void TestMethod2()
        {
            LoadTestRecords();
             
            var context = new Test.Db.TestDbEntities();

            var result2 = context.Headers.Search(record => record.UpdateDate < DateTime.Now && record.Active == true);

            Assert.IsTrue(result2.Count != 0);
        }
    }
}
