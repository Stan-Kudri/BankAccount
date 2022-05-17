using FourthLabWorkInSeventhChapters;
using Xunit;

namespace TestFourthLab
{
    public class FailedTransactionsTest
    {
        [Theory]
        [InlineData(1000, 1200)]
        public void Transfer_more_money_than_available(int balance, ushort withdrawAmounMoney)
        {
            var balanceAcount = new Money(balance);
            //�������� ���������� ������ � ������������ �������� �� ������� ������.
            var firstAccountBank = new BankAccount(new NumberBankAccount("1000 0000 0000 0000"), balanceAcount, BankAccountType.Current);
            var secondAccountBank = new BankAccount(new NumberBankAccount("1000 0000 0000 0001"), balanceAcount, BankAccountType.Current);

            //���������� �������� � �������.
            var isFirstOperation = firstAccountBank.TransferTo(secondAccountBank, new Money(withdrawAmounMoney));
            var isSecondOperation = firstAccountBank.Withdraw(new Money(withdrawAmounMoney));

            //�������� �������� ������� �����.
            Assert.Equal(new Money(balance), firstAccountBank.Balance);
            Assert.Equal(new Money(balance), secondAccountBank.Balance);
            //�������� ���������� ����������, ���� ����� ��� �������� (�������� ����� � ������ ����� �� ������) ��� ������ ������������� ���������� ����� �� ����������.
            Assert.False(isFirstOperation);
            Assert.False(isSecondOperation);
            //�������� �� ������� �������� ����������.
            Assert.Empty(firstAccountBank.Transaction);
            Assert.Empty(secondAccountBank.Transaction);
        }

        [Theory]
        [InlineData(1000)]
        public void Transfer_zero_money_impossible(int balance)
        {
            var balanceAcount = new Money(balance);
            //�������� ���������� ������ � ������������ �������� �� ������� ������.
            var firstAccountBank = new BankAccount(new NumberBankAccount("1000 0000 0000 0000"), balanceAcount, BankAccountType.Current);
            var secondAccountBank = new BankAccount(new NumberBankAccount("1000 0000 0000 0001"), balanceAcount, BankAccountType.Current);

            //���������� �������� �� �������� 0 ����� �� ����.
            var operation = firstAccountBank.TransferTo(secondAccountBank, new Money(0));

            //�������� �������� ������� �����
            Assert.Equal(new Money(balance), firstAccountBank.Balance);
            Assert.Equal(new Money(balance), secondAccountBank.Balance);
            //�������� ���������� ���������� ��� �������� 0 �����.
            Assert.False(operation);
            //�������� �� ������� �������� ����������.
            Assert.Empty(firstAccountBank.Transaction);
            Assert.Empty(secondAccountBank.Transaction);
        }

        [Theory]
        [InlineData(1000)]
        public void Put_zero_money_impossible(int balance)
        {
            var balanceAcount = new Money(balance);
            //�������� ���������� ������ � ������������ �������� �� ������� ������.
            var AccountBank = new BankAccount(new NumberBankAccount("1000 0000 0000 0000"), balanceAcount, BankAccountType.Current);

            //���������� �������� �� �������� 0 ����� �� ����.
            var operation = AccountBank.Put(new Money(0));

            //�������� �������� ������� �����
            Assert.Equal(new Money(balance), AccountBank.Balance);
            //�������� ���������� ���������� ��� ���������� ����� �� 0 �����.
            Assert.False(operation);
            //�������� �� ������� �������� ����������.
            Assert.Empty(AccountBank.Transaction);
        }

        [Theory]
        [InlineData(1000)]
        public void Withdrawals_zero_money_impossible(int balance)
        {
            var balanceAcount = new Money(balance);
            //�������� ���������� ������ � ������������ �������� �� ������� ������.
            var AccountBank = new BankAccount(new NumberBankAccount("1000 0000 0000 0000"), balanceAcount, BankAccountType.Current);

            //���������� �������� �� �������� 0 ����� �� ����.
            var operation = AccountBank.Withdraw(new Money(0));

            //�������� �������� ������� �����
            Assert.Equal(new Money(balance), AccountBank.Balance);
            //�������� ���������� ���������� ��� ������ �� ����� 0 �����.
            Assert.False(operation);
            //�������� �� ������� �������� ����������.
            Assert.Empty(AccountBank.Transaction);
        }
    }
}