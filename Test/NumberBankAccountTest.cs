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
        public void NumberAccount(string? expectNumberAccount, string line)
        {
            var numberAccount = new NumberBankAccount(line);
            var stringFormat = numberAccount.NumberAccount;
            Assert.Equal(expectNumberAccount, stringFormat);
        }

        [Theory]
        [InlineData("Строка нулевая", null)]
        [InlineData("Строка не правильного формата", "0000 0002 0323 4242")]
        [InlineData("Строка не правильного формата", "1000 ff02 0323 4242")]
        public void ThrowsExceptionNumberAccount(string thrownException, string line)
        {
            var exception = Assert.Throws<Exception>(() => new NumberBankAccount(line));
            Assert.Equal(exception.Message, thrownException);
        }
    }
}
