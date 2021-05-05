using System;
using ToDoList.Models;
using System.Collections.Generic;
public class Program
{
  static void Main()
  {
    Console.WriteLine("Welcome to the To Do List.");
    Start:
    Console.WriteLine("Would you like to add an item to your list or view your list? (Add/View)");
    string userInput = Console.ReadLine();
    if (userInput.ToLower() == "add") 
    {
      Console.WriteLine("Please enter the description for the new item.");
      string description = Console.ReadLine();
      Item newItem = new Item(description);
      List<Item> items = Item.GetAll();
      Console.WriteLine("{0} has been added to your list.", items[items.Count - 1].Description);
      goto Start;
    }
    else 
    {
      Console.WriteLine("Here is your to-do list");
      foreach (Item thisItem in Item.GetAll())
      {
        Console.WriteLine("{0}", thisItem.Description);
      }
    }
  }
}