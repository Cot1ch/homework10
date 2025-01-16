using System;
using System.Collections;

namespace Tumakov11
{
    internal class BankAccountFactory
    {
        private static Hashtable _HTAccounts = new Hashtable();
        public static Hashtable HTAccounts
        {
            get { return _HTAccounts; }
            set { _HTAccounts = value; }
        }

        protected BankAccount MakeProduct(decimal balance, BankAccount.Account account)
        {
            BankAccount product = new BankAccount(balance, account);
            HTAccounts.Add(product.Id, product);
            return product;
        }

        public BankAccount CreateProduct(decimal balance, BankAccount.Account account)
        {
            return MakeProduct(balance, account);
        }

        public static bool DeleteAccount(Guid id)
        {
            if (HTAccounts.ContainsKey(id))
            {
                HTAccounts.Remove(id);
                return true;
            }

            return false;
        }
    }
}
