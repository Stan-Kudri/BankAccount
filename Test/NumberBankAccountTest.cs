using FourthLabWorkInSeventhChapters;
using System;
using Xunit;

namespace Test
{
    public class NumberBankAccountTest
    {
        [Theory]
        [InlineData("1000 0002 0323 4242", "10000002    03234242")]
        [InlineData("1000 0002 0323 4642", "1000000203234642")]
        public void NumberAccountTest(string? expectNumberAccount, string line)
        {
            var numberAccount = new NumberBankAccount(line);
            var stringFormat = numberAccount.NumberAccount;
            Assert.Equal(expectNumberAccount, stringFormat);
        }

        [Theory]
        [InlineData(typeof(ArgumentNullException), null)]
        [InlineData(typeof(FormatNumberAccountException), "0000 0002 0323 4242")]
        [InlineData(typeof(FormatNumberAccountException), "1000 ff02 0323 4242")]
        public void ThrowsExceptionTest(Type type, string line)
        {
            Assert.Throws(type, () =>
            {
                new NumberBankAccount(line);
            });
        }
    }
}
