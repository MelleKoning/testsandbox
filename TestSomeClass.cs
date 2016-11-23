using System;
using System.CodeDom;
using NUnit.Framework;

namespace TestSandBox.UnitTest
{
    [TestFixture]
    public class TestSomeClass
    {

        [Test]
        public void CallProtectedMethod_On_TestWrapper_ReturnsResult()
        {
            var SubjectUndertest = new TestWrapperClassToTest();
            int result = SubjectUndertest.CallsInternalMethodAccessor(2, 2);
            Assert.That(result == 4);
        }


        public class TestWrapperClassToTest : ProductionCodeClass
        {
            public int CallsInternalMethodAccessor(int a, int b)
            {
                return this.CallsInternalMethod(a, b);
            }
        }
    }
    // end unit test class


    public class ProductionCodeClass
    {
        public void CodeEntryPointMethod()
        {
            int i = CallsInternalMethod(1, 1);
        }

        protected int CallsInternalMethod(int a, int b)
        {
            return a + b;
        }
    }
}