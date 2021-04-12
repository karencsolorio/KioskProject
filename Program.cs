using System;
using System.IO;

namespace Kiosk_Project
{
    class Program
    {
        struct Bank
        {
            public int pennies;
            public int nickels;
            public int dimes;
            public int quarters;
            public int fiftyCent;
            public int dollarCoin;
            public int dollar;
            public int twoDollar;
            public int fiveDollar;
            public int tenDollar;
            public int twentyDollar;
            public int fiftyDollar;
            public int hundredDollar;

        }//End of structure



        //Global variable
        static Bank till = new Bank();
        static void Main(string[] args)
        {
            //Call Initialized Till
            InitializedTill();

            //Call Item Cost
            decimal totalPrice = Item_Cost();

            //Call PaymentAccept
            decimal change = PaymentAccept(totalPrice);


            //call DispenseChange
            DispenseChange(change);


        }//End of Main
        static string Prompt(string text)
        {
            Console.Write(text + "");
            return Console.ReadLine();
        }//End function
        static decimal Item_Cost()
        {
            int itemNumber = 1; //Item number counter
            string item = Prompt($"Item {itemNumber}: $".ToString());
            decimal itemCost = 0.0m;
            decimal itemTotal = 0.0m;
            
                //Get Items
                while (item != "")
            {
                //Validate item
                itemCost = decimal.Parse(item);

                if (itemCost < 0.0m || itemCost == 0 || itemCost == 0.0m)
                {

                    while (itemCost < 0.0m)
                    {
                        Console.WriteLine("Your item cannot have a negative price. Enter the correct price.");
                        Console.Write("$ ");
                        itemCost = decimal.Parse(Console.ReadLine());
                    }

                    while (itemCost == 0.0m || itemCost == 0)
                    {
                        Console.WriteLine("Enter in a value that is greater than $0.");
                        Console.Write("$ ");
                        itemCost = decimal.Parse(Console.ReadLine());
                    }
                }

                //Running Total
                itemTotal += itemCost;
                
                //Increment Item
                itemNumber += 1;
                
                //Prompt for next item.
                item = Prompt($"Item {itemNumber}: $".ToString());

            }//End of While Loop

            //Display Total
            Console.WriteLine($"\nThe total is ${itemTotal:N}.\n");

            //Return Total
            return itemTotal;

        }//End of Item Cost
        static void InitializedTill()
            {
                till.pennies = 25;
                till.nickels = 25;
                till.dimes = 25;
                till.quarters = 25;
                till.fiftyCent = 25;
                till.dollarCoin = 25;
                till.dollar = 25;
                till.twoDollar = 25;
                till.fiveDollar = 25;
                till.tenDollar = 25;
                till.twentyDollar = 25;
                till.fiftyDollar = 25;
                till.hundredDollar = 25;
            }//end InitializedTill
        static decimal PaymentAccept(decimal itemInput)
            {
                //variable declarations
                decimal moneyInput = 0.0m;
                decimal totalMoney = 0.0m;
                decimal change = 0;

                while (totalMoney < itemInput)
                {
                    //ACCEPT A VALID COIN OR BILL
                    Console.Write("Insert Money: $");
                    moneyInput = decimal.Parse(Console.ReadLine());
                    
                    if(moneyInput == 0 || moneyInput == 0.0m || moneyInput < 0.0m || moneyInput < 0)
                {
                    while (moneyInput < 0.0m)
                    {
                        Console.WriteLine("Your item cannot have a negative price. Enter the correct price.");
                        Console.Write("$ ");
                        moneyInput = decimal.Parse(Console.ReadLine());
                    }

                    while (moneyInput == 0.0m || moneyInput == 0)
                    {
                        Console.WriteLine("Enter in a value that is greater than $0.");
                        Console.Write("$ ");
                        moneyInput = decimal.Parse(Console.ReadLine());
                    }
                }

                    //VALIDATE ITEM TO MAKE CERTAIN PARSABLE AS A NUMBER AND THE PRICE IS VALID 
                    if (moneyInput == .01m)
                    {
                        till.pennies += 1;
                    }
                    else if (moneyInput == .05m)
                    {
                        till.nickels += 1;
                    }
                    else if (moneyInput == .10m)
                    {
                        till.dimes += 1;
                    }
                    else if (moneyInput == .25m)
                    {
                        till.quarters += 1;
                    }
                    else if (moneyInput == .50m)
                    {
                        till.fiftyCent += 1;
                    }
                    else if (moneyInput == 1.00m)
                    {
                        till.dollarCoin += 1;
                    }
                    else if (moneyInput == 1.00m)
                    {
                        till.dollar += 1;
                    }
                    else if (moneyInput == 2.00m)
                    {
                        till.twoDollar += 1;
                    }
                    else if (moneyInput == 5.00m)
                    {
                        till.fiveDollar += 1;
                    }
                    else if (moneyInput == 10.00m)
                    {
                        till.tenDollar += 1;
                    }
                    else if (moneyInput == 20.00m)
                    {
                        till.twentyDollar += 1;
                    }
                    else if (moneyInput == 50.00m)
                    {
                        till.fiftyDollar += 1;
                    }
                    else if (moneyInput == 100.00m)
                    {
                        till.hundredDollar += 1;
                    }// end else ifs

                    //running total
                    totalMoney += moneyInput;

                    if (totalMoney >= itemInput)
                    {
                        change = totalMoney - itemInput;
                        Console.WriteLine($"\nYour change is ${change:N}.");
                    }
                    else if (totalMoney < itemInput)
                    {
                        change = itemInput - totalMoney;
                        Console.WriteLine($"Please, insert at least ${change:N}.");
                    }

                }//while loop ends

                return change;
            }//end function
        static void DispenseChange(decimal change)
            {
            while (change > 0)
                {
                if (change >= 100.00m && till.hundredDollar > 0)
                {
                    till.hundredDollar -= 1;
                    change -= 100.00m;
                    Console.WriteLine($"$100.00 dispensed.");
                }
                else if (change >= 50.00m && till.fiftyDollar > 0)
                {
                    till.fiftyDollar -= 1;
                    change -= 50.00m;
                    Console.WriteLine($"$50.00 dispensed.");
                }
                else if (change >= 20.00m && till.twentyDollar > 0)
                {
                    till.twentyDollar -= 1;
                    change -= 20.00m;
                    Console.WriteLine($"$20.00 dispensed.");
                }
                else if (change >= 10.00m && till.tenDollar > 0)
                {
                    till.tenDollar -= 1;
                    change -= 10.00m;
                    Console.WriteLine($"$10.00 dispensed.");
                }
                else if (change >= 5.00m && till.fiftyDollar > 0)
                {
                    till.fiveDollar -= 1;
                    change -= 5.00m;
                    Console.WriteLine($"$5.00 dispensed.");
                }
                else if (change >= 2.00m && till.twoDollar > 0)
                {
                    till.twoDollar -= 1;
                    change -= 2.00m;
                    Console.WriteLine($"$2.00 is dispensed.");
                }
                else if (change >= 1.00m && till.dollar > 0)
                {
                    till.dollar -= 1;
                    change -= 1.00m;
                    Console.WriteLine($"$1.00 dispensed.");
                }
                else if (change >= 1.00m && till.dollarCoin > 0)
                {
                    till.dollarCoin -= 1;
                    change -= 1.00m;
                    Console.WriteLine($"$1.00 dispensed.");
                }
                else if (change >= .50m && till.fiftyCent > 0)
                {
                    till.fiftyCent -= 1;
                    change -= .50m;
                    Console.WriteLine($"$0.50 dispensed.");
                }
                else if (change >= .25m && till.quarters > 0)
                {
                    till.quarters -= 1;
                    change -= .25m;
                    Console.WriteLine($"$0.25 dispensed.");
                }
                else if (change >= .10m && till.dimes > 0)
                {
                    till.dimes -= 1;
                    change -= .10m;
                    Console.WriteLine($"$0.10 is dispensed.");
                }
                else if (change >= .05m && till.nickels > 0)
                {
                    till.nickels -= 1;
                    change -= .05m;
                    Console.WriteLine($"$0.05 is dispensed.");
                }
                else if (change >= .01m && till.pennies > 0)
                {
                    till.pennies -= 1;
                    change -= .01m;
                    Console.WriteLine($"$0.01 is dispensed.");
                }
                else 
                {
                    Console.WriteLine($"\nThere is a remaining balance of ${change:N}. " +
                        "We do not have enough money to give you your exact change. Please, cancel this order.");
                    change = 0;
                }//end ifs 
            }// end while
            Console.ReadKey();
        }// end function
    }//end class
}// end namespace