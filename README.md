# DigitalExpress

## Description of approach

A bank account may have more than one card to access it. Banks normally have multiple ATMs to access accounts. This presents a problem where the same bank account may be accessed at the same time, at separate ATMs. This could lead to inconsistencies within the system. To overcome this, we decided we would implement a locking technique. To demonstrate both the data race and non data race we wanted to add a button in the options menu that toggled these modes on and off. The non-data race mode would utilise the lock we implemented and the non data race would not. We designed our system first, to minimise problems later on, deciding on 4 main classes; Home, ATM_Window, Account, Bank. This proved useful, however we still ran into problems.

## Problems and Solutions

A problem faced when creating our ATM was adding the non-data race condition. Originally, when we tried to implement the non-race condition we added the lock into the ATM thread itself. This didn't work and it took us some time to realise that the lock should be within the account class instead. We then moved our function to decrease the account balance from the ATM window class to the account class and added the lock, which ended up fixing this error.

Secondly, there was the problem of finding a way of inputting data such as account number and pin using the same buttons. We wanted our ATM to look like a physical ATM as much as possible, so we had the same form for everything but only had the display change. This led to a problem of sometimes the same button would have to do different things for a different display. This was fixed by creating a variable inputType, which was changed depending on the display that was currently being displayed to the user

Finally, there was displaying error messages to the user on the same ATM window.This meant that we had to find a way for the program to display the error message to the user, wait for a period of time, then prompt them to enter the correct data. We used the Thread.Sleep() function to wait for a small period of time however we had a problem that was making the UI not update to show the error message. After some research we found that we had to call this.Update before we used the sleep function.

## Features

The multi window ATM system we designed has the look and feel of an ATM. Instead of having multiple forms for each time you press a button, the display on the ATM will update and change according to selections, much like a real ATM screen.

When the “Non Data Race” condition is toggled to be on, it will always show the correct balance. When it is toggled off, it will show an incorrect account balance after 2 or more withdrawals. This demonstrates both consistent and inconsistent behavior.

Within the first menu there are features; Options, which will allow you to toggle “Non Race Condition” and to view the currently running threads . Open ATM Window, this will open a new window in which the ATM will run. Reset, this will reset all changes made to the ATM and accounts. Exit which simply closes all windows and exits the program.

Features of the ATM window include; Withdraw, where you can select one of the preset amounts of cash to withdraw or you can enter your own specific amount (of course if it is not a multiple of 10, it will not allow you to withdraw). Display balance, which will show you the current balance of the account which you are currently accessing. $20 quick cash, Which simply allows you to instantly withdraw cash at the press of a button as it is the most common amount to be taken out of ATMs. Account info, will show you the account number and balance of the account you are currently accessing. Withdraw limit, will allow you to set a maximum amount which can be withdrawn at one time. 
