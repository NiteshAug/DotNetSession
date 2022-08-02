using System;
using Xunit;
using DelegatesPractice;

namespace TestProject
{
    public class UnitTest1
    {
        [Fact]
        public void onWordTest()
        {
            DelegatesImpl.DelegatesPrac del = DelegatesImpl.ReadingValue;
            DelegatesImpl.DelegateCallBack("nitesh", del);
        }

        [Fact]
        public void onNumberTest()
        {
            DelegatesImpl.DelegatesPrac del = DelegatesImpl.ReadingValue;
            DelegatesImpl.DelegateCallBack("123", del);
        }

        [Fact]
        public void onJunkTest()
        {
            DelegatesImpl.DelegatesPrac del = DelegatesImpl.ReadingValue;
            DelegatesImpl.DelegateCallBack("$#", del);
        }
    }
}
