using FourthLabWorkInSeventhChapters;
using Xunit;

namespace Test
{
    public class NumberBankAccountTest
    {
        [Theory]
        [InlineData("1000 0002 0323 4242", "10000002    03234242")]
        [InlineData(null, "0000 0002 0323 4242")]
        [InlineData(null, "1000 ff02 0323 4242")]
        [InlineData("1000 0002 0323 4642", "1000000203234642")]
        public void NumberAccount(string? expectNumberAccount, string line)
        {
            var numberAccount = new NumberBankAccount(line);
            var stringFormat = numberAccount.NumberAccount;
            Assert.Equal(expectNumberAccount, stringFormat);
        }
    }
}
