using System;


namespace Tumakov12
{
    internal class BankAccount
    {
        #region Fields
        private static Guid _Id;
        private decimal _Balance;
        private Account _account;
        #endregion

        #region Properties
        public Guid Id
        {
            get { return Id; }
        }

        public decimal balance
        {
            get { return _Balance; }
            set { _Balance = value; }
        }
        public Account account
        {
            get { return _account; }
            set { _account = value; }
        }
        #endregion

        #region Constructors
        public BankAccount(decimal balance, Account account)
        {
            _account = account;
            _Balance = balance;
            _Id = Guid.NewGuid();
        }
        public BankAccount(decimal balance)
        {
            _Balance = balance;
            _Id = Guid.NewGuid();
        }
        #endregion


        #region Methods
        /// <summary>
        /// Выводит информацию о банковском счёте
        /// </summary>
        /// <returns>-</returns>
        public void PrintInfo()
        {
            Console.WriteLine($"Номер счёта: {Id}, баланс: {balance}, тип: {account}");
        }

        /// <summary>
        /// Добавляет введённую сумму к сумме на счету. 
        /// </summary>
        /// <returns>-</returns>
        public void Put(decimal moneyy)
        {
            _Balance += moneyy;
        }

        /// <summary>
        /// Проверяет, можно ли снять введённую сумму.
        /// Если да, то вычитает её со счёта, 
        /// в противном случае уведомляет пользователя о невозможности операции.
        /// </summary>
        /// <returns>Значение типа bool</returns>
        public bool Remove(decimal moneyy)
        {
            if (moneyy <= _Balance)
            {
                _Balance -= moneyy;
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool MoneyTransfer(BankAccount bankAccount, decimal moneyy)
        {
            if (Remove(moneyy))
            {
                bankAccount.Put(moneyy);
                return true;
            }
            return false;
        }

        public override bool Equals(object obj)
        {
            if (obj is BankAccount)
            {
                BankAccount bankAcc = (BankAccount)obj;
                return balance == bankAcc.balance && account == bankAcc.account;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return (_Balance, _Id, _account).GetHashCode();
        }

        public override string ToString()
        {
            return $" Номер счёта: {Id}\nТип: {account}\nБаланс{_Balance}";
        }

        public static bool operator ==(BankAccount bankAcc1, BankAccount bankAcc2)
        {
            return bankAcc1.Equals(bankAcc2);
        }
        public static bool operator !=(BankAccount bankAcc1, BankAccount bankAcc2)
        {
            return !bankAcc1.Equals(bankAcc2);
        }
        #endregion

        #region Enum
        public enum Account
        {
            Текущий, Сберегательный
        }
        #endregion
    }
}