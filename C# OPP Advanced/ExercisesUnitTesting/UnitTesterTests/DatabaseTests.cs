using NUnit.Framework;
using System;
using System.Linq;
using System.Reflection;

namespace UnitTesterTests
{
    public class DatabaseTests
    {

        [Test]
        [TestCase(new int[] { 1, 2, 3, 4 })]
        [TestCase(new int[] { 1 })]
        public void DatabaseTestConstutorValid(int[] values)
        {
            var database = new Database(values);

            var numbers = database.Numbers.Take(values.Length);
            Assert.That(numbers, Is.EquivalentTo(values));
        }

        [Test]
        public void DatabaseTestConstructorInvalid()
        {
            int[] values = new int[17];
            Assert.That(() => new Database(values), Throws.InvalidOperationException);
        }

        [Test]
        [TestCase(30)]
        [TestCase(int.MinValue)]
        [TestCase(int.MaxValue)]
        [TestCase(0)]
        [TestCase(-500)]
        public void DatabaseTestAddMethodValid(int value)
        {
            var database = new Database();
            database.Add(value);

            FieldInfo fieldInfo = typeof(Database).GetFields(BindingFlags.NonPublic | BindingFlags.Instance).First(f => f.FieldType == typeof(int));

            var currentIndexFieldInfo = (int)fieldInfo.GetValue(database);
            Assert.That(database.Numbers[currentIndexFieldInfo] == value);
            Assert.That(currentIndexFieldInfo == 0);
        }

        [Test]
        public void DatabaseTestAddMethodInvalid()
        {
            int[] values = new int[16];
            var database = new Database(values);

            Assert.That(() => database.Add(1), Throws.InvalidOperationException);
        }

        [Test]
        [TestCase(new int[] { 1, 2, 3, 4, 5})]
        [TestCase(new int[] { 1 })]
        [TestCase(new int[] { 1, 2 })]
        public void DatabaseTestRemoveMethodValid(int[] values)
        {
            var database = new Database(values);

            database.Remove();

            FieldInfo fieldInfo = typeof(Database).GetFields(BindingFlags.NonPublic | BindingFlags.Instance).First(f => f.FieldType == typeof(int));
            var currentIndexFromFieldInfo = (int)fieldInfo.GetValue(database);
            
            Assert.That(currentIndexFromFieldInfo == values.Length-2);
        }

        [Test]
        public void DatabaseTestRemoveMethodInvalid()
        {
            var database = new Database();

            Assert.That(() => database.Remove(), Throws.InvalidOperationException);
        }

        //[Test]
        //public void DatabaseTestFetchMethod()
        //{
        //    var database = new Database(1, 2, 3, 4, 5, 6);

        //    Assert.That(database.Fetch(), Is.EqualTo("1 2 3 4 5 6"));
        //}
    }
}
