using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;

namespace ATM_Assignment
{
    //taken from provided code
    public class Account
    {
        //the attributes for the account
        private int balance;
        private int pin;
        private int accountNum;
        private int? withdrawLimit;

        // a constructor that takes initial values for each of the attributes (balance, pin, accountNumber)
        public Account(int balance, int pin, int accountNum, int? withdrawLimit = null)
        {
            this.balance = balance;
            this.pin = pin;
            this.accountNum = accountNum;
            this.withdrawLimit = withdrawLimit;
        }

        //getter and setter functions for balance
        public int getBalance()
        {
            return balance;
        }
        //method which reduces balance
        public bool reduceBalanceLock(int reduceBy, bool datarace)
        {
            //if datarace variable i true run code that causes a data race
            //using thread.sleep to create an artificial delay
            if (datarace)
            {
                if (reduceBy > this.balance)
                {
                    // not enough money
                    return false;
                }
                else
                {
                    int tempBal = this.balance;
                    Thread.Sleep(1500);
                    tempBal -= reduceBy;
                    Thread.Sleep(1500);
                    this.balance = tempBal;
                }

            }
            //if datarace variable is not true create a lock so only one thread can access this data at a time
            //using same artificial delay to show it is the lock that stops the race condition
            else
            {
                lock (this)
                {
                    if (reduceBy > this.balance)
                    {
                        // not enough money
                        return false;
                    }
                    else
                    {
                        int tempBal = this.balance;
                        Thread.Sleep(1500);
                        tempBal -= reduceBy;
                        Thread.Sleep(1500);
                        this.balance = tempBal;
                    }
                }
            }
            return true;


                
        }
            

        public int getPin()
        {
            return pin;
        }

        /*
         *   This funciton allows us to decrement the balance of an account
         *   it perfomes a simple check to ensure the balance is greater tha
         *   the amount being debeted
         *   
         *   reurns:
         *   true if the transactions if possible
         *   false if there are insufficent funds in the account
         */
        public Boolean decrementBalance(int amount)
        {
            if (this.balance > amount)
            {
                balance -= amount;
                return true;
            }
            else
            {
                return false;
            }
        }

        /*
         * This funciton check the account pin against the argument passed to it
         *
         * returns:
         * true if they match
         * false if they do not
         */
        public Boolean checkPin(int pinEntered)
        {
            if (pinEntered == pin)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        public int getAccountNum()
        {
            return accountNum;
        }

        public int? getWithdrawLimit()
        {
            return this.withdrawLimit;
        }

        /// <summary>
        /// Sets the withdraw limit. Null if default.
        /// </summary>
        /// <param name="withdrawLimit"></param>
        public void setWithdrawLimit(int? withdrawLimit)
        {
            this.withdrawLimit = withdrawLimit;
        }
    }
}
