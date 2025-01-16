using System;

namespace Tumakov11
{
    internal class BankAccount
    {
        #region Fields
        private Guid _Id;
        private decimal _Balance;
        private Account _account;
        #endregion

        #region Properties
        public Guid Id
        {
            get { return _Id; }
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
        internal BankAccount(decimal balance, Account account)
        {
            _account = account;
            _Balance = balance;
            _Id = Guid.NewGuid();
        }
        #endregion

        #region Methods
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
        /// Метод перевода (вычитания с одного и прибавления на другой) денег между счетами
        /// </summary>
        /// <returns> Булево значение</returns>
        public bool MoneyTransfer(BankAccount bankAccount, decimal moneyy)
        {
            if (Remove(moneyy))
            {
                bankAccount.Put(moneyy);
                return true;
            }
            return false;
        }

        public override string ToString()
        {
            return $"Номер счёта: {Id}\nТип: {account}\nБаланс: {_Balance}\n";
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