using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Diagnostics;
using System.Threading;

/// <summary>
/// TODO - Add try-catch for withdraw amount
/// </summary>


namespace ATM_Assignment
{
    public partial class ATM_Window : Form
    {
        private Account[] bankAccounts;

        /// <summary>
        /// 1 - Account number
        /// 2 - PIN
        /// 3 - Main option menu
        /// 4 - Withdraw
        /// 5 - Withdraw Other Amount
        /// 6 - Set withdraw limit
        /// </summary>
        private int inputType = 0;
        private int isCardIn = 0;
        private string accountNum = "";
        private string pin = "";
        private string withdrawAmount;
        private string withdrawLimit;
        private Account activeAccount;
        private bool datarace;

        public ATM_Window(Account[] accountList, bool dataRaceOption)
        {
            InitializeComponent();
            bankAccounts = accountList;
            datarace = dataRaceOption;
            displayDataRace();
            startOptions();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            DrawDisplay(e);

        }

        /// <summary>
        /// Draws the gray ATM display
        /// </summary>
        /// <param name="e"></param>
        private void DrawDisplay(PaintEventArgs e)
        {

            // Create solid brush.
            SolidBrush blueBrush = new SolidBrush(Color.FromArgb(51, 51, 51));

            // Create rectangle.
            Rectangle rect = new Rectangle(70, 15, 323, 295);

            // Fill rectangle to screen.
            e.Graphics.FillRectangle(blueBrush, rect);
        }
        
        /// <summary>
        /// Displays what type of data race is selected as a tiny label down-right.
        /// </summary>
        private void displayDataRace()
        {
            if(this.datarace)
            {
                lblDataRace.Text = "Race Condition";
            }
            else
            {
                lblDataRace.Text = "Non Race Condition";
            }
        }

        /// <summary>
        /// Initial screen
        /// </summary>
        public void startOptions()
        {
            //initialize fileds to default value
            this.inputType = 0;
            this.accountNum = "";
            this.pin = "";

            clearAllElements();
            lblMain.Text = "Welcome to ATM. Please insert your card";

        }

        /// <summary>
        /// Initialtes login
        /// </summary>
        public void logIn()
        {
            //enable buttons needed
            enableNumPad();
            //ask for account number
            getAccountNumber();
        }

        private void getAccountNumber()
        {
            this.inputType = 1;
            this.accountNum = "";
            //reads from the text box that contains the number the user has entered and converts to an int.
            lblMain.Text = "Please enter account number: \n";
        }

        private bool checkAccountNumber()
        {
            try
            {
                int number;
                // Check if the lenght is right
                if (accountNum.Length == 6 && Int32.TryParse(accountNum, out number))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }

        }

        private void getPinNumber()
        {
            this.inputType = 2;
            this.pin = "";
            //reads from the text box that contains the number the user has entered and converts to an int.
            lblMain.Text = "Please enter pin number: \n";
            
        }

        private bool checkPin()
        {
            try
            {
                // Check if the combination of this.accountNumber and this.pin is correct
                for (int i = 0; i < bankAccounts.Length; i++)
                {
                    if (Int32.Parse(this.accountNum) == bankAccounts[i].getAccountNum())
                    {
                        if (Int32.Parse(this.pin) == bankAccounts[i].getPin())
                        {
                            Debug.WriteLine("Valid combination");

                            activeAccount = bankAccounts[i];
                            return true;

                        }
                    }
                }

                return  false;
            }
            catch
            {
                return false;
            } 
        }

        //keypad
        private void btn1_Click(object sender, EventArgs e)
        {
            if (this.inputType == 1)
            {
                this.accountNum += "1";
                lblMain.Text += "1";
            }
            else if (this.inputType == 2)
            {
                this.pin += "1";
                lblMain.Text += "*";
            }
            else if (this.inputType == 5)
            {
                this.withdrawAmount += "1";
                lblMain.Text += "1";
            }
            else if (this.inputType == 6)
            {
                this.withdrawLimit += "1";
                lblMain.Text += "1";
            }

        }

        private void btn2_Click(object sender, EventArgs e)
        {
            if (this.inputType == 1)
            {
                this.accountNum += "2";
                lblMain.Text += "2";
            }
            else if (this.inputType == 2)
            {
                this.pin += "2";
                lblMain.Text += "*";
            }
            else if (this.inputType == 5)
            {
                this.withdrawAmount += "2";
                lblMain.Text += "2";
            }
            else if (this.inputType == 6)
            {
                this.withdrawLimit += "2";
                lblMain.Text += "2";
            }
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            if (this.inputType == 1)
            {
                this.accountNum += "3";
                lblMain.Text += "3";
            }
            else if (this.inputType == 2)
            {
                this.pin += "3";
                lblMain.Text += "*";
            }
            else if (this.inputType == 5)
            {
                this.withdrawAmount += "3";
                lblMain.Text += "3";
            }
            else if (this.inputType == 6)
            {
                this.withdrawLimit += "3";
                lblMain.Text += "3";
            }
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            if (this.inputType == 1)
            {
                this.accountNum += "4";
                lblMain.Text += "4";
            }
            else if (this.inputType == 2)
            {
                this.pin += "4";
                lblMain.Text += "*";
            }
            else if (this.inputType == 5)
            {
                this.withdrawAmount += "4";
                lblMain.Text += "4";
            }
            else if (this.inputType == 6)
            {
                this.withdrawLimit += "4";
                lblMain.Text += "4";
            }
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            if (this.inputType == 1)
            {
                this.accountNum += "5";
                lblMain.Text += "5";
            }
            else if (this.inputType == 2)
            {
                this.pin += "5";
                lblMain.Text += "*";
            }
            else if (this.inputType == 5)
            {
                this.withdrawAmount += "5";
                lblMain.Text += "5";
            }
            else if (this.inputType == 6)
            {
                this.withdrawLimit += "5";
                lblMain.Text += "5";
            }
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            if (this.inputType == 1)
            {
                this.accountNum += "6";
                lblMain.Text += "6";
            }
            else if (this.inputType == 2)
            {
                this.pin += "6";
                lblMain.Text += "*";
            }
            else if (this.inputType == 5)
            {
                this.withdrawAmount += "6";
                lblMain.Text += "6";
            }
            else if (this.inputType == 6)
            {
                this.withdrawLimit += "6";
                lblMain.Text += "6";
            }
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            if (this.inputType == 1)
            {
                this.accountNum += "7";
                lblMain.Text += "7";
            }
            else if (this.inputType == 2)
            {
                this.pin += "7";
                lblMain.Text += "*";
            }
            else if (this.inputType == 5)
            {
                this.withdrawAmount += "7";
                lblMain.Text += "7";
            }
            else if (this.inputType == 6)
            {
                this.withdrawLimit += "7";
                lblMain.Text += "7";
            }
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            if (this.inputType == 1)
            {
                this.accountNum += "8";
                lblMain.Text += "8";
            }
            else if (this.inputType == 2)
            {
                this.pin += "8";
                lblMain.Text += "*";
            }
            else if (this.inputType == 5)
            {
                this.withdrawAmount += "8";
                lblMain.Text += "8";
            }
            else if (this.inputType == 6)
            {
                this.withdrawLimit += "8";
                lblMain.Text += "8";
            }
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            if (this.inputType == 1)
            {
                this.accountNum += "9";
                lblMain.Text += "9";
            }
            else if (this.inputType == 2)
            {
                this.pin += "9";
                lblMain.Text += "*";
            }
            else if (this.inputType == 5)
            {
                this.withdrawAmount += "9";
                lblMain.Text += "9";
            }
            else if (this.inputType == 6)
            {
                this.withdrawLimit += "9";
                lblMain.Text += "9";
            }
        }

        private void btn0_Click(object sender, EventArgs e)
        {
            if (this.inputType == 1)
            {
                this.accountNum += "0";
                lblMain.Text += "0";
            }
            else if (this.inputType == 2)
            {
                this.pin += "0";
                lblMain.Text += "*";
            }
            else if (this.inputType == 5)
            {
                this.withdrawAmount += "0";
                lblMain.Text += "0";
            }
            else if (this.inputType == 6)
            {
                this.withdrawLimit += "0";
                lblMain.Text += "0";
            }
        }

        /// <summary>
        /// Checks if valid account number is provided
        /// </summary>
        private void validateAccountNumber()
        {
            bool valid = checkAccountNumber();
            if (!valid)
            {
                lblMain.Text = "Please, enter 6 digit number!";
                updateAllElements();
                Thread.Sleep(2000);
                getAccountNumber();
            }
            else
            {
                getPinNumber();
            }
        }


        /// <summary>
        /// Checks if valid valid combination of pin and account number is provided
        /// </summary>
        private void validatePIN()
        {
            Debug.WriteLine("accountNum = " + this.accountNum + "; pin = " + this.pin);
            bool valid = checkPin();
            if (!valid)
            {
                lblMain.Text = "Not valid combination!";
                updateAllElements();
                Thread.Sleep(2000);
                //Back to the start
                getAccountNumber();
            }
            else
            {
                //Call a function which shows user options.
                showOptions();
            }
        }
        
        /// <summary>
        /// Checks if valid withdraw limit is provided
        /// true if manualy provide
        /// false if selected to be default
        /// </summary>
        /// <param name="manual"></param>
        private void validateWithdrawLimit(bool manual)
        {
            try
            {
                if (manual)
                {
                    int withdrawLimitInt = Int32.Parse(this.withdrawLimit);

                    //check if valid withdraw
                    if (withdrawLimitInt == 0)
                    {
                        clearAllElements();
                        //invalid transaction
                        lblMain.Text = "Invalid input. \nLimit cannot be £0.";
                        updateAllElements();
                        Thread.Sleep(2500);
                        setWithdrawLimit();
                    }
                    // multiple of 10
                    else if (withdrawLimitInt % 10 != 0)
                    {
                        clearAllElements();
                        //invalid transaction
                        lblMain.Text = "Invalid input. \nLimit must be multiple of 10.";
                        updateAllElements();
                        Thread.Sleep(2500);
                        setWithdrawLimit();
                    }
                    else
                    {
                        // set manual withdraw limit
                        activeAccount.setWithdrawLimit(withdrawLimitInt);

                        clearAllElements();
                        lblMain.Text = "Succesfully set limit to \n£" + withdrawLimitInt;
                        updateAllElements();
                        Thread.Sleep(2500);
                        showOptions();
                    }
                }
                else
                {
                    // set default withdraw limit
                    activeAccount.setWithdrawLimit(null);

                    clearAllElements();
                    lblMain.Text = "Succesfully set limit to \n£500 (default)";
                    updateAllElements();
                    Thread.Sleep(2500);
                    showOptions();
                }
            }
            catch
            {
                clearAllElements();
                //invalid transaction
                lblMain.Text = "Invalid input. \nAmount too big or empty.";
                updateAllElements();
                Thread.Sleep(2500);
                setWithdrawLimit();
            }

        }

        /// <summary>
        /// Checks if valid withdraw amount is provided
        /// </summary>
        /// <param name="withdrawAmountInt"></param>
        private void validateWithdraw(int withdrawAmountInt = -1)
        {
            try
            {
                bool manual = false;
                if (withdrawAmountInt == -1)
                {
                    withdrawAmountInt = Int32.Parse(this.withdrawAmount);
                    manual = true;
                }
                //check if valid withdraw
                if (withdrawAmountInt == 0)
                {
                    clearAllElements();
                    //invalid transaction
                    lblMain.Text = "Invalid transaction. \nTrying to withdraw £0.";
                    updateAllElements();
                    Thread.Sleep(2500);
                    withdrawOtherAmount();
                }
                // multiple of 10
                else if (withdrawAmountInt % 10 != 0)
                {
                    clearAllElements();
                    //invalid transaction
                    lblMain.Text = "Invalid transaction. \nEnter amount multiple of 10.";
                    updateAllElements();
                    Thread.Sleep(2500);
                    withdrawOtherAmount();
                }
                // withdraw limit
                else if (withdrawAmountInt > this.activeAccount.getWithdrawLimit())
                {
                    clearAllElements();
                    //invalid transaction
                    lblMain.Text = "Invalid transaction. \nOver the withdraw limit.";
                    updateAllElements();
                    Thread.Sleep(2500);

                    if (manual)
                    {
                        withdrawOtherAmount();
                    }
                    else
                    {
                        withdrawCash();
                    }
                }
                else
                {

                    bool transactionStatus;           
                    transactionStatus = activeAccount.reduceBalanceLock(withdrawAmountInt, datarace);         
                    //Successful
                    if (transactionStatus == true)
                    {
                        clearAllElements();
                        lblMain.Text = "Succesfully withdrew £" + withdrawAmountInt + ". \nThanks for using ATM!";
                        picMoney.Visible = true;
                        updateAllElements();
                        Thread.Sleep(2500);
                        picMoney.Visible = false;
                        showOptions();
                    }
                    else
                    {
                        clearAllElements();
                        //invalid transaction
                        lblMain.Text = "Invalid transaction. \nTrying to withdraw more than what is in your account.";
                        updateAllElements();
                        Thread.Sleep(2500);

                        if (manual)
                        {
                            withdrawOtherAmount();
                        }
                        else
                        {
                            withdrawCash();
                        }
                    }
                }
            }
            catch
            {
                clearAllElements();
                //invalid transaction
                lblMain.Text = "Invalid transaction. \nAmount too big or empty.";
                updateAllElements();
                Thread.Sleep(2500);
                withdrawOtherAmount();
            }

        }

        private void rbtnOK_Click(object sender, EventArgs e)
        {
            //input type is 1 if its an account number
            if (this.inputType == 1)
            {
                validateAccountNumber();
            }
            //input type is 2 if is a pin
            else if (this.inputType == 2)
            {
                validatePIN();
            }
            else if (this.inputType == 5)
            {
                validateWithdraw();
            }
            else if (this.inputType == 6)
            {
                validateWithdrawLimit(true);
            }
        }

        /// <summary>
        /// Display all menu options
        /// </summary>
        private void showOptions()
        {
            this.inputType = 3;

            clearAllElements();

            lblMain.Text = "Welcome to the options menu!";
            lblOption1.Text = "$20 Quick Cash";
            lblOption2.Text = "Display Balance";
            lblOption3.Text = "Withdraw Cash";
            lblOption4.Text = "Account Info";
            lblOption5.Text = "Withdraw Limit";
            lblOption6.Text = "Transfer Funds";

            btnOption1.Enabled = true; 
            btnOption2.Enabled = true; 
            btnOption3.Enabled = true; 
            btnOption4.Enabled = true;
            btnOption5.Enabled = true; 
            btnOption6.Enabled = true;                 
        }


        private void quickCash()
        {
            validateWithdraw(20);
        }

        /// <summary>
        /// Except from btnCard. This button is always active.
        /// </summary>
        private void clearAllElements()
        {
            //empty text
            lblMain.Text = "";
            lblOption1.Text = " "; lblOption2.Text = " "; lblOption3.Text = " "; lblOption4.Text = " "; lblOption5.Text = " "; lblOption6.Text = " "; lblOption7.Text = " "; lblOption8.Text = " ";
            //disabling buttons that cannot be used at start.
            btnCash.Enabled = false;
            btn0.Enabled = false; btn1.Enabled = false; btn2.Enabled = false; btn3.Enabled = false; btn4.Enabled = false;
            btn5.Enabled = false; btn6.Enabled = false; btn7.Enabled = false; btn8.Enabled = false; btn9.Enabled = false;
            btnEmpty.Enabled = false; btnEmpty2.Enabled = false;
            btnOption1.Enabled = false; btnOption2.Enabled = false; btnOption3.Enabled = false; btnOption4.Enabled = false;
            btnOption5.Enabled = false; btnOption6.Enabled = false; btnOption7.Enabled = false; btnOption8.Enabled = false;
            rbtnCancel.Enabled = false; rbtnClear.Enabled = false; rbtnOK.Enabled = false; rbtnEmpty.Enabled = false;
        }

        /// <summary>
        /// Except from btnCard. This button is always active.
        /// </summary>
        private void updateAllElements()
        {
            this.Update();
        }

        private void enableNumPad()
        {
            btn0.Enabled = true; btn1.Enabled = true; btn2.Enabled = true; btn3.Enabled = true; btn4.Enabled = true;
            btn5.Enabled = true; btn6.Enabled = true; btn7.Enabled = true; btn8.Enabled = true; btn9.Enabled = true;
            rbtnCancel.Enabled = true;
            rbtnClear.Enabled = true;
            rbtnOK.Enabled = true;
        }

        private void displayBalance()
        {
            clearAllElements();
            lblMain.Text = "Balance in account: £" + activeAccount.getBalance().ToString();
            lblOption8.Text = "Go Back";
            btnOption8.Enabled = true;
        }

        private void withdrawCash()
        {
            inputType = 4;
            

            clearAllElements();
            lblMain.Text = "Please select amount to withdraw:";
            lblOption8.Text = "Go Back";
            btnOption8.Enabled = true;

            lblOption1.Text = "£10";
            lblOption2.Text = "£20";
            lblOption3.Text = "£40";
            lblOption4.Text = "£100";
            lblOption5.Text = "£500";
            lblOption6.Text = "Other amount";

            btnOption1.Enabled = true;
            btnOption2.Enabled = true;
            btnOption3.Enabled = true;
            btnOption4.Enabled = true;
            btnOption5.Enabled = true;
            btnOption6.Enabled = true;
            //give new withdraw options
        }

        private void withdrawOtherAmount()
        {
            this.inputType = 5;
            this.withdrawAmount = "";

            clearAllElements();
            lblMain.Text = "Enter other amount: \n£";

            lblOption8.Text = "Go Back";
            btnOption8.Enabled = true;

            enableNumPad();
        }

        private void accountInfo()
        {
            clearAllElements();
            lblMain.Text = "Account number: " + activeAccount.getAccountNum().ToString() + "\nWithdraw limit: " + ((activeAccount.getWithdrawLimit() == null) ? "£500 (default)" : ("£" + activeAccount.getWithdrawLimit().ToString()));
            lblOption8.Text = "Go Back";
            btnOption8.Enabled = true;
        }

        private void setWithdrawLimit()
        {
            this.inputType = 6;
            this.withdrawLimit = "";

            clearAllElements();
            lblMain.Text = "Enter withdraw limit: \n£";

            lblOption1.Text = "£500 (default)";
            btnOption1.Enabled = true;

            lblOption8.Text = "Go Back";
            btnOption8.Enabled = true;

            enableNumPad();
        }

        private void transferFunds()
        {
            MessageBox.Show("Transfer Funds Selected");
        }

        private void btnOption1_Click(object sender, EventArgs e)
        {
            if (inputType == 3)
            {
                quickCash();
            }
            else if (inputType == 4)
            {
                validateWithdraw(10);
            }
            else if (inputType == 6)
            {
                validateWithdrawLimit(false);
            }
        }

        private void btnOption2_Click(object sender, EventArgs e)
        {
            if (inputType == 3)
            {
                displayBalance();
            }
            else if (inputType == 4)
            {
                validateWithdraw(20);
            }
        }

        private void btnOption3_Click(object sender, EventArgs e)
        {
            if (inputType == 3)
            {
                withdrawCash();
            }
            else if (inputType == 4)
            {
                validateWithdraw(40);
            }
        }

        private void btnOption4_Click(object sender, EventArgs e)
        {
            if (inputType == 3)
            {
                accountInfo();
            }
            else if (inputType == 4)
            {
                validateWithdraw(100);
            }
        }

        private void btnOption5_Click(object sender, EventArgs e)
        {
            if (inputType == 3)
            {
                setWithdrawLimit();
            }
            else if (inputType == 4)
            {
                validateWithdraw(500);
            }
        }

        private void btnOption6_Click(object sender, EventArgs e)
        {
            if (inputType == 3)
            {
                transferFunds();
            }
            else if (inputType == 4)
            {
                withdrawOtherAmount();
            }
        }

        private void btnOption7_Click(object sender, EventArgs e)
        {

        }

        private void btnOption8_Click(object sender, EventArgs e)
        {
            if(inputType == 5)
            {
                withdrawCash();
            }
            else
            {
                showOptions();
            }
            
        }

        private void btnCard_Click(object sender, EventArgs e)
        {
                   
            if (isCardIn==0) {
                btnCard.Text = "Remove Card";
                isCardIn = 1;
                logIn();
            }
            else
            {
                btnCard.Text = "Insert Card";
                isCardIn = 0;
                //disable buttons.
                startOptions();

            }
            
        }

        private void rbtnCancel_Click(object sender, EventArgs e)
        {
            if (inputType == 1 || inputType == 2)
            {
                logIn();
            }
            else
            {
                showOptions();
            }
        }

        private void rbtnClear_Click(object sender, EventArgs e)
        {
            if (inputType == 1)
            {
                getAccountNumber();
            }
            else if (inputType == 2)
            {
                getPinNumber();
            }
            else if (inputType == 5)
            {
                withdrawOtherAmount();
            }
            else if (inputType == 6)
            {
                setWithdrawLimit();
            }
        }
    }

}


