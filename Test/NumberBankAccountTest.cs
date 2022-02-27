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
        public void Number_bank_account_in_correct_format(string? expectNumberAccount, string line)
        {
            var numberAccount = new NumberBankAccount(line);
            var stringFormat = numberAccount.NumberAccount;
            Assert.Equal(expectNumberAccount, stringFormat);
        }

        [Theory]
        [InlineData(typeof(ArgumentNullException), null)]
        [InlineData(typeof(FormatNumberAccountException), "0000 0002 0323 4242")]
        [InlineData(typeof(FormatNumberAccountException), "1000 ff02 0323 4242")]
        public void Failed_format_in_number_bank_account(Type type, string line)
        {
            Assert.Throws(type, () =>
            {
                new NumberBankAccount(line);
            });
        }
    }
}
