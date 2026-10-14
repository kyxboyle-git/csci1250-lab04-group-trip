/*
    *Name: Kyland Boyle
    *Course: CSCI 1250, Section 001
    *Assignment: Lab 04, Group Trip
    *Date: October 14, 2026
    *Description: Rebuilds the trip calculator with methods and arrays so it
* reports on a whole group instead of one person.
*/


using System.Data;
using System.Xml;

//Road trip calculation
double pricePerGallon;
double milesPerGallon;
double miles;
double pizzaTotal;
double pizzaPrice;
const int slicesPerPizza = 8;
double totalSlices;
double pizzaTotalPrice;


Console.Write("Round trip miles: ");
miles = Convert.ToDouble(Console.ReadLine());

Console.Write("Miles per gallon: ");
milesPerGallon = Convert.ToDouble(Console.ReadLine());

Console.Write("Price per gallon: ");
pricePerGallon = Convert.ToDouble(Console.ReadLine());

Console.Write("How many pizzas: ");
pizzaTotal = Convert.ToDouble(Console.ReadLine());

Console.Write("Price per pizza: ");
pizzaPrice = Convert.ToDouble(Console.ReadLine());
System.Console.WriteLine();

//------------------------------------------------------------

Console.WriteLine("=== Part 1: The Trip ===");

double fuel = FuelCost(miles, milesPerGallon, pricePerGallon);
Console.WriteLine("Fuel cost: " + fuel.ToString("C"));

totalSlices = pizzaTotal * slicesPerPizza;
pizzaTotalPrice = pizzaTotal * pizzaPrice;

Console.WriteLine("Pizza cost: " + pizzaTotalPrice.ToString("C"));

double tripTotal = pizzaTotalPrice + fuel;

System.Console.WriteLine("Trip total: " + Math.Round(tripTotal, 2));
System.Console.WriteLine();
//------------------------------------------------------------------------------------


 System.Console.WriteLine("=== Part 2: The Group ===");
string[] names = { "Ada", "Grace", "Alan", "Katherine" };
double[] hoursWorked = { 22, 15, 30, 18 };
double[] hourlyRates = { 13.50, 16.00, 11.20, 14.80 };

double peopleGoing = names.Length;
System.Console.WriteLine("People Going: " + peopleGoing);

double slicesEach = (pizzaTotal * slicesPerPizza) / names.Length;
System.Console.WriteLine("Slices each: " + Math.Round(slicesEach, 1));

double costPerPerson = tripTotal / names.Length;
System.Console.WriteLine("Cost per person: " + costPerPerson.ToString("C"));




//Paycheck calculation
const double taxRate = 0.18;

Console.WriteLine("=== Part 3: Who Works How Long ===");
double totalHours = 0;
double totalTakeHomePay = 0;
double longest = 0;

for (int i = 0; i < names.Length; i++)
{
    totalHours += hoursWorked[i];
   double homePay = TakeHomePay(hoursWorked[i], hourlyRates[i], taxRate);
   double takeHomePerHour =     homePay / hoursWorked[i];
   double hoursToCover = HoursToCover(costPerPerson, takeHomePerHour);
   totalTakeHomePay += homePay;
Console.WriteLine(names[i] + ": takes home " + homePay.ToString("C") + " for " + hoursWorked[i] + " hours, " + takeHomePerHour.ToString("C") + " per hour, must work " + Math.Round(hoursToCover, 2) + " hours ");
   longest = Math.Max(longest, hoursToCover);
}

System.Console.WriteLine();

System.Console.WriteLine("Total hours worked: " + totalHours);
System.Console.WriteLine("Total take home pay: " + totalTakeHomePay.ToString("C"));
System.Console.WriteLine("Longest anyone must work: " + Math.Round(longest, 2));


//---------------------------------------------------------------------------------------


static double FuelCost(double miles, double milesPerGallon, double pricePerGallon)
{
    double gallonsNeeded = miles / milesPerGallon;
return  gallonsNeeded * pricePerGallon;
}
static double TakeHomePay(double hoursWorked, double hourlyRate, double taxRate)
{

    double grossPay = hoursWorked * hourlyRate;
    double taxWithheld = grossPay * taxRate;
    return  grossPay - taxWithheld;
}
static double HoursToCover(double costPerPerson, double takeHomePerHour)
{
    return costPerPerson / takeHomePerHour;
}