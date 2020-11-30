using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;

namespace ATM_Assignment
{
    public class Bank
    {
        private Account[] ac = new Account[3];
        private Thread newAtmThread;
        private bool dataRaceOption = false;
        //constructor
        public Bank()
        {
            ac[0] = new Account(300, 1111, 111111);
            ac[1] = new Account(750, 2222, 222222);
            ac[2] = new Account(3000, 3333, 333333);
        }

        /// <summary>
        /// Create new ATM thread
        /// </summary>
        public void createNewATM()
        {
            newAtmThread = new Thread(launchATM);
            newAtmThread.Start();
        }

        /// <summary>
        /// Open new ATM window
        /// </summary>
        public void launchATM()
        {
            ATM_Window atm = new ATM_Window(ac, dataRaceOption);
            // Display the ATM form window
            atm.ShowDialog();
        }

        public Account[] getAc()
        {
            return ac;
        }
        public void resetBank()
        {
            ac[0] = new Account(300, 1111, 111111);
            ac[1] = new Account(750, 2222, 222222);
            ac[2] = new Account(3000, 3333, 333333);
        }

        /// <summary>
        /// Sets the (non-)race option
        /// </summary>
        /// <param name="TorF"></param>
        public void setDataRaceOption(bool TorF)
        {
            this.dataRaceOption = TorF;
        }
    }
}