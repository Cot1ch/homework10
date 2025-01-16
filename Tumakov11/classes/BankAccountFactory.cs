using System;
using System.Collections;

namespace Tumakov11
{
    internal class BankAccountFactory
    {
        #region Field
        private static Hashtable _HTAccounts = new Hashtable();
        #endregion

        #region Properties
        public static Hashtable HTAccounts
        {
            get { return _HTAccounts; }
            set { _HTAccounts = value; }
        }
        #endregion

        #region Methods
        /// <summary>
        /// Фабричный метод
        /// </summary>
        /// <returns>Объект BankAccount</returns>
        protected BankAccount MakeProduct(decimal balance, BankAccount.Account account)
        {
            BankAccount product = new BankAccount(balance, account);
            HTAccounts.Add(product.Id, product);
            return product;
        }

        /// <summary>
        /// Фабричный метод
        /// </summary>
        /// <returns>Объект BankAccount</returns>
        public BankAccount CreateProduct(decimal balance, BankAccount.Account account)
        {
            return MakeProduct(balance, account);
        }

        /// <summary>
        /// Метод удаляет объект по его номеру и возврадает результат операции
        /// </summary>
        /// <returns>Булево значение</returns>
        public static bool DeleteAccount(Guid id)
        {
            if (HTAccounts.ContainsKey(id))
            {
                HTAccounts.Remove(id);
                return true;
            }

            return false;
        }
        #endregion
    }
}
