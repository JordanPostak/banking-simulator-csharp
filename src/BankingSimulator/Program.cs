using BankingSimulator.Models;
using BankingSimulator.UI;

var account = new BankAccount("Jordan", "100001");
var menu = new ConsoleMenu(account);

menu.Run();