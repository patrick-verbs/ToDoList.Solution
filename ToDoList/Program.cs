using System;
using ToDoList.Models;
using System.Collections.Generic;
public class Program
{
  static void Main()
  {
    Console.WriteLine("Welcome to the To-Do List.");
    string lastAdded = "";
    Start:
    Console.BackgroundColor = ConsoleColor.Black;  
    Console.ForegroundColor = ConsoleColor.White; 
    List<Item> items = Item.GetAll();
    Console.Write("\n" + lastAdded + "Would you like to add an item to your list or view your list? (Add/View) ");
    string userInput = Console.ReadLine();
    if (userInput.ToLower() == "add" || userInput.ToLower() == "a") 
    {
      Console.WriteLine("\n" + "Please enter the description for the new item.");
      string description = Console.ReadLine();
      Item newItem = new Item(description);
      lastAdded = ("\n" + items[items.Count - 1].Description) + " has been added to your list. " + "\n";
      // Console.WriteLine("{0} has been added to your list.", items[items.Count - 1].Description);
      goto Start;
    }
    else if (userInput.ToLower() == "view" || userInput.ToLower() == "v")
    {
      if (items.Count == 0)
      {
        Console.ForegroundColor = ConsoleColor.Red; 
        Console.WriteLine("\n" + "Your To-Do List is currently empty. Please add some items.");
        goto Start;
      }
      Console.WriteLine("\n" + "Your To-Do List:" + "\n----------------");
      int count = 1;
     
      foreach (Item thisItem in items)
      {
        Console.BackgroundColor = ConsoleColor.White;  
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.Write("{0}", count + ". " + thisItem.Description + "\n");
        count++;
      }
      lastAdded = "";
      goto Start;
    }
    else
    {
      Console.WriteLine("\n" + "Not a recognized input.");
      goto Start;
    }
  }
}