# Banking Simulator

A console-based banking simulation built with C# and .NET 8. This project demonstrates object-oriented programming, input validation, transaction processing, and incremental software development.

## Project Goals

- Refresh and strengthen C# fundamentals
- Apply object-oriented programming principles
- Separate banking logic from the console interface
- Protect account data through encapsulation
- Build the application through small, testable increments

## Minimum Viable Product

The first version will allow a user to:

- View account information
- Deposit funds
- Withdraw funds
- View transaction history
- Exit the application

## Planned Domain Objects

### BankAccount

Responsible for:

- Storing the account owner's name
- Storing an account number
- Tracking the current balance
- Processing deposits
- Processing withdrawals
- Maintaining transaction history

### Transaction

Responsible for recording:

- Transaction date and time
- Transaction type
- Transaction amount
- Balance after the transaction

## Business Rules

- Deposit amounts must be greater than zero.
- Withdrawal amounts must be greater than zero.
- A withdrawal cannot exceed the available balance.
- The balance can only be changed through account operations.
- Successful deposits and withdrawals are recorded in transaction history.

## Technologies

- C#
- .NET 8
- Git
- GitHub
- Visual Studio Code
- GitHub Copilot

## Project Status

Initial project setup is complete. Domain-model implementation is the next development milestone.