using System;
using Xunit;

namespace TDDBank.Tests
{
    public class BankAccountTests
    {
        [Fact]
        public void New_BankAccounts_should_have_zero_as_Balance()
        {
            var ba = new BankAccount();

            Assert.Equal(0m, ba.Balance);
        }

        [Fact]
        public void Can_Deposit()
        {
            var ba = new BankAccount();

            ba.Deposit(8m);

            Assert.Equal(8m, ba.Balance);
        }

        [Fact]
        public void Deposits_add_money()
        {
            var ba = new BankAccount();

            ba.Deposit(8m);
            ba.Deposit(4m);

            Assert.Equal(12m, ba.Balance);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        [InlineData(-0.1)]
        public void Deposit_can_not_be_a_negative_or_zero_value(decimal amount)
        {
            var ba = new BankAccount();

            Assert.Throws<ArgumentException>(() => ba.Deposit(amount));
        }

        [Fact]
        public void Can_Withdraw()
        {
            var ba = new BankAccount();

            ba.Deposit(10m);
            ba.Withdraw(8m);

            Assert.Equal(2m, ba.Balance);
        }

        [Fact]
        public void Withdraw_substract_money()
        {
            var ba = new BankAccount();

            ba.Deposit(12m);
            ba.Withdraw(8m);
            ba.Withdraw(4m);

            Assert.Equal(0m, ba.Balance);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        [InlineData(-0.1)]
        public void Withdraw_can_not_be_a_negative_or_zero_value(decimal amount)
        {
            var ba = new BankAccount();

            Assert.Throws<ArgumentException>(() => ba.Withdraw(amount));
        }

        [Fact]
        public void Withdraw_can_not_be_more_than_Balance()
        {
            var ba = new BankAccount();
            ba.Deposit(12m);

            Assert.Throws<InvalidOperationException>(() => ba.Withdraw(13m));
        }
    }
}