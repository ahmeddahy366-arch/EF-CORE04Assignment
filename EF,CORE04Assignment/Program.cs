using EF_CORE04Assignment.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System.Net.NetworkInformation;
using System.Security.Principal;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace EF_CORE04Assignment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (BankDbcontext bank = new BankDbcontext())
            {

                bool exit = false;
                while (!exit)
                {
                    Console.Clear();
                    Console.WriteLine("=========================================");
                    Console.WriteLine("   National Bank Management System       ");
                    Console.WriteLine("=========================================");
                    Console.WriteLine("1) Add a new Customer");
                    Console.WriteLine("2) Open a new Account for a Customer");
                    Console.WriteLine("3) Update Account Status");
                    Console.WriteLine("4) Remove an Account from a Customer");
                    Console.WriteLine("5) List all Customers (with accounts)");
                    Console.WriteLine("0) Exit");
                    Console.WriteLine("=========================================");
                    Console.Write("Please enter your choice (0-5): ");



                    if (!int.TryParse(Console.ReadLine(), out int choice))
                    {
                        Console.WriteLine("\n[Error] Invalid input! Please enter a valid number.");
                        continue;

                    }

                    switch(choice)
                    {
                        case 1:
                            AddCustomer(bank);
                            break;
                        case 2:
                            OpenAccount(bank);
                            break;
                        case 3:
                            UpdateAccountStatus(bank);
                            break;
                        case 4:
                            RemoveAccountFromCustomer(bank);
                            break;
                        case 5:
                            ListCustomersWithAccounts(bank);
                            break;
                        case 0:
                            exit = true;
                            break;
                        default:
                            Console.WriteLine("\n[Error] Invalid choice! Please enter a number between 0 and 5.");
                            break;
                    }


                    if (!exit)
                    {
                        PauseAndContinue();
                    }




                }

          



            }


            static void PauseAndContinue()
            {
                Console.WriteLine("\nPress any key to return to the menu...");
                Console.ReadKey();
            }
            static void AddCustomer(BankDbcontext bank)
            {
                Console.WriteLine("Enter Customer Name:");
                string name = Console.ReadLine();
                Console.WriteLine("Enter Customer Address:");
                string address = Console.ReadLine();
                Console.WriteLine("Enter Customer Phone Number:");
                string phoneNumber = Console.ReadLine();
                Console.WriteLine("enter customer date of birth:");
                DateTime dateOfbirth = DateTime.Parse(Console.ReadLine());
                Console.WriteLine("enter customer email:");
                string email = Console.ReadLine();
                Console.WriteLine("enter customer national id:");
                string nationalId = Console.ReadLine();
                Console.WriteLine("enter customer customerType");
                string customerType = Console.ReadLine();

                customer newCustomer = new customer
                {
                    FullName = name,
                    address = address,
                    PhoneNumber = phoneNumber,
                    dateOfbirth = dateOfbirth,
                    email = email,
                    nationalld = nationalId,
                    customerType = customerType
                };
                bank.customers.Add(newCustomer);
                bank.SaveChanges();
                Console.WriteLine($"Customer '{name}' added successfully!");

            }
            static void OpenAccount(BankDbcontext bank)
            {
                Console.WriteLine("\n--- Open New Account for Customer ---");

                Console.WriteLine("Enter account number");
                if (!int.TryParse(Console.ReadLine(), out int accountNumber))
                {
                    Console.WriteLine("\n[Error] Invalid input! Please enter a valid number.");
                    return;
                }

                Console.WriteLine("enter account type ");
                string accountType = Console.ReadLine();

                Console.WriteLine("enter branch code:");
                if (!int.TryParse(Console.ReadLine(), out int branchCode))
                {
                    Console.WriteLine("\n[Error] Invalid input! Please enter a valid number.");
                    return;
                }

                if (!bank.Branches.Any(b => b.code == branchCode))
                {
                    Console.WriteLine("Invalid branch code. Please enter a valid branch code.");
                    return;
                }
                Console.WriteLine("enter customer id:");
                if (!int.TryParse(Console.ReadLine(), out int customerId))
                {
                    Console.WriteLine("\n[Error] Invalid input! Please enter a valid number.");
                    return;
                }
                if (!bank.customers.Any(c => c.id == customerId))
                {
                    Console.WriteLine("Invalid customer id. Please enter a valid customer id.");
                    return;
                }
                Console.WriteLine("Enter ownership role (Primary / CoHolder):");
                string ownershipRole = Console.ReadLine();

                    var newAccount = new account
                    {
                      
                        accountType = accountType,
                        branchId = branchCode,
                        CurrentBalance = 0.0m,
                        openingDate = DateTime.Now
                    };

                    var accountCustomer = new AccountCustomer
                    {
                        ownerShipType = ownershipRole,
                        customersId = customerId,
                        accountsId = accountNumber,
                        AccountStuats = "active",
                        ownerShipStartDate = DateTime.Now
                  
                   };
                try
                {
                    bank.accounts.Add(newAccount);
                    bank.SaveChanges();

                    bank.AccountCustomers.Add(accountCustomer);
                    bank.SaveChanges();

                    Console.WriteLine("\n[Success] Account opened successfully and linked to the customer!");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"\n[Error]: {ex.Message}");
                    if (ex.InnerException != null)
                    {
                        Console.WriteLine($"[SQL Server Inner Exception]: {ex.InnerException.Message}");
                    }
                }


            }

            static void UpdateAccountStatus(BankDbcontext bank)
            {
                Console.WriteLine("update account status");
                Console.WriteLine("enter account number:");
                if (!int.TryParse(Console.ReadLine(), out int accountNumber))
                {
                    Console.WriteLine("\n[Error] Invalid input! Please enter a valid number.");
                    return;
                }

                Console.WriteLine("enter coustomer id:");
                if (!int.TryParse(Console.ReadLine(), out int CoustomerID))
                {
                    Console.WriteLine("\n[Error] Invalid input! Please enter a valid number.");
                    return;
                }
                var accountCustomer = bank.AccountCustomers.FirstOrDefault(ac => ac.accountsId == accountNumber && ac.customersId == CoustomerID);
                if (accountCustomer == null)
                {
                    Console.WriteLine("Account or customer not found.");
                    return;
                }
                if (accountCustomer.AccountStuats == "active")
                {
                    accountCustomer.AccountStuats = "inactive";
                }
                else
                {
                    accountCustomer.AccountStuats = "active";
                }
                bank.SaveChanges();
                Console.WriteLine("Account status updated successfully.");

            }

            static void RemoveAccountFromCustomer(BankDbcontext bank)
            {
                Console.WriteLine("remove account from customer");
                Console.WriteLine("enter account number:");
                if (!int.TryParse(Console.ReadLine(), out int accountNumber))
                {
                    Console.WriteLine("\n[Error] Invalid input! Please enter a valid number.");
                    return;
                }
                Console.WriteLine("enter coustomer id:");
                if (!int.TryParse(Console.ReadLine(), out int CoustomerID))
                {
                    Console.WriteLine("\n[Error] Invalid input! Please enter a valid number.");
                    return;
                }
                var accountCustomer = bank.AccountCustomers.FirstOrDefault(ac => ac.accountsId == accountNumber && ac.customersId == CoustomerID);
                if (accountCustomer == null)
                {
                    Console.WriteLine("Account or customer not found.");
                    return;
                }
                bank.AccountCustomers.Remove(accountCustomer);
                bank.SaveChanges();
                Console.WriteLine("Account removed from customer successfully.");
            }
            static void ListCustomersWithAccounts(BankDbcontext bank)
            {
                Console.WriteLine("\n--- List All Customers with Accounts ---");

                var customersWithAccounts = bank.customers.Include(c => c.accountCustomer).
                                                          ThenInclude(ac => ac.accounts).ToList();
                if(!customersWithAccounts.Any())
                {
                    Console.WriteLine("No customers found.");
                    return;
                }
                foreach(var item in customersWithAccounts)
                {
                    Console.WriteLine($"Customer ID: {item.id}, Name: {item.FullName}, Email: {item.email}");
                    if (item.accountCustomer.Any())
                    {
                        foreach (var ac in item.accountCustomer)
                        {
                            Console.WriteLine($"\tAccount Number: {ac.accountsId}, Type: {ac.accounts.accountType}, Status: {ac.AccountStuats}");
                        }
                    }
                    else
                    {
                        Console.WriteLine("\tNo accounts linked to this customer.");
                    }



                }
            }




        }
    }
}



