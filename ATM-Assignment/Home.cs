using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using System.Diagnostics;

namespace ATM_Assignment
{
    public partial class Home : Form
    {
        public Bank newBank;
       
        public Home()
        {
            InitializeComponent();
            menuStrip1.BackColor = Color.White;
            newBank = new Bank();
        }

        /// <summary>
        /// Opens new ATM window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOpenATM_Click(object sender, EventArgs e)
        {
            newBank.createNewATM();
        }

        /// <summary>
        /// Closes all running ATM windows and exists the application.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// Resets all bank accounts to their initial state
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReset_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Do you really want to Reset the ATM Simulator? \nBank amounts and account info will change to initial values.", "Warrning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (dialog == DialogResult.Yes)
            {
                this.newBank.resetBank();
            }
            else if (dialog == DialogResult.No)
            {
                // nothing
            }
        }

        /// <summary>
        /// Displays all running thrads's ID as debug information in the output window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void viewRunningThreadsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            

            ProcessThreadCollection currentThreads = Process.GetCurrentProcess().Threads;

            foreach (ProcessThread thread in currentThreads)
            {
                // Do whatever you need
                Debug.WriteLine(thread.Id);
            }
        }

        /// <summary>
        /// Set race contition from the option menu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void raceConditionTSMI_Click(object sender, EventArgs e)
        {
            if (raceConditionTSMI.Checked == true)
            {
                raceConditionTSMI.Checked = false;
                newBank.setDataRaceOption(true);
            }
            else
            {
                raceConditionTSMI.Checked = true;
                newBank.setDataRaceOption(false);
            }
        }

        /// <summary>
        /// Closes all running ATM windows and exists the application.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Home_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
