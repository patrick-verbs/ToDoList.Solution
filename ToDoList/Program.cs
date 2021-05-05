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
    Console.WriteLine(lastAdded + "Would you like to add an item to your list or view your list? (Add/View)");
    string userInput = Console.ReadLine();
    if (userInput.ToLower() == "add" || userInput.ToLower() == "a") 
    {
      Console.WriteLine("\n" + "Please enter the description for the new item.");
      string description = Console.ReadLine();
      Item newItem = new Item(description);
      List<Item> items = Item.GetAll();
      lastAdded = ("\n" + items[items.Count - 1].Description) + " has been added to your list. ";
      // Console.WriteLine("{0} has been added to your list.", items[items.Count - 1].Description);
      goto Start;
    }
    else if (userInput.ToLower() == "view" || userInput.ToLower() == "v")
    {
      Console.WriteLine("\n" + "Your To-Do List:" + "\n----------------");
      int count = 1;
      foreach (Item thisItem in Item.GetAll())
      {
        Console.WriteLine("{0}", count + ". " + thisItem.Description);
        count++;
      }
    }
    else
    {
      Console.WriteLine("\n" + "Not a recognized input.");
    }
  }
}