using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TerseTests
{
    [TestClass]
    public class CounterTest
    {        
        [TestMethod]
        public void Test_WeKnowOurOperators()
        {

            #region Test values
            var singleValue = new
            {
                Description = "This is a single value"
            };

            var manyValues = new[]
            {
                singleValue,
                new { Description = "Another of many values" },
                new { Description = "Yet Another of many values" },
                new { Description = "The last of many values" }
            };
            #endregion
            var counter = new Counter();

            Assert.AreEqual(counter.WithNoValues().Count_Terse, counter.WithNoValues().Count_Interpreted);
            Assert.AreEqual(counter.WithOneValue(singleValue).Count_Terse, counter.WithOneValue(singleValue).Count_Interpreted);
            Assert.AreEqual(counter.WithManyValues(manyValues).Count_Terse, counter.WithManyValues(manyValues).Count_Interpreted);
        }
    }

    class Counter
    {
        private static object _value;
        private static object[] _values;
       
        public int Count_Terse => _value != null ? 1 : (_values?.Length ?? 0);

        public int Count_Interpreted
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        //public int Count_Interpreted
        //{
        //    get
        //    {
        //        if (_value != null)
        //            return 1;

        //        if (_values != null)
        //            return _values.Length;

        //        return 0;
        //    }
        //}

        #region With methods

        public Counter WithNoValues()
        {
            _value = null;
            _values = null;

            return this;
        }

        public Counter WithOneValue(object value)
        {
            _value = value;
            _values = new object[] { value };

            return this;
        }

        public Counter WithManyValues(object[] values)
        {
            _value = null;
            _values = values;

            return this;
        }
        #endregion
    }
}
