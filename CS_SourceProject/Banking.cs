using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_SourceProject
{
    // define a delegate at namespace level
    // to execute a method with delegate
    // the signeture of delegate must match with the signeture of method it is executing
    // if a delegate is used to declare an event then delegate mujst have return type as void

    public delegate void TransactionHandler(int amt);


    public class Banking
    {
        // declare events using delegate
        public event TransactionHandler OverBalance;
        public event TransactionHandler UnderBalance;

        private int NetBalance = 0;

        public Banking(int opbal)
        {
            NetBalance = opbal;
        }
        /// <summary>
        /// One way methods with void
        /// </summary>
        /// <param name="tranAmt"></param>
        public void Deposit(int tranAmt)
        {
            NetBalance = NetBalance + tranAmt;

            if (NetBalance > 100000)
            {
                // raise event
                OverBalance(NetBalance);
            }
        }

        public void Withdrawal(int tranAmt)
        {
            NetBalance = NetBalance - tranAmt;
            if (NetBalance < 5000)
            {
                // raise event
                UnderBalance(NetBalance);
            }
        }

        public int ShowBalance()
        {
            return NetBalance;
        }
    }

    public class EventListener
    {
        private readonly Banking bank;
        /// <summary>
        /// The Event Listener has Dependency on the Banking object
        /// The event listener will generate the Notiofication
        /// Based on the Status of the event
        /// </summary>
        /// <param name="bank"></param>
        public EventListener(Banking bank)
        {
            this.bank = bank;
            // event subscription
            this.bank.OverBalance += Bank_OverBalance;
            this.bank.UnderBalance += Bank_UnderBalance;
        }

        private void Bank_UnderBalance(int amt)
        {
            Console.WriteLine($"Your balance is Rs.{amt} please maintain min Rs. 5000");
        }

        private void Bank_OverBalance(int amt)
        {
            int taxableAmount = amt - 100000;
            int tax = taxableAmount / 10;
            Console.WriteLine($"Your Netbalanace is Rs. {taxableAmount} more than Rs 10000. SO " +
                $"Please pay tax of Rs. {tax}, else I-T is watching you.");
        }


    }


}
