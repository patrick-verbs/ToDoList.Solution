using System;
using ToDoList.Models;
using System.Collections.Generic;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace ToDoList
{
  public class Program
  {
    public static void Main(string[] args)
    {
      var host = new WebHostBuilder()
        .UseKestrel()
        .UseContentRoot(Directory.GetCurrentDirectory())
        .UseIISIntegration()
        .UseStartup<Startup>()
        .Build();

      host.Run();

      Console.WriteLine("Welcome to the To-Do List.");
      string lastAdded = "";
      Start:
      Console.BackgroundColor = ConsoleColor.Black;  
      Console.ForegroundColor = ConsoleColor.White; 
      List<Item> items = Item.GetAll();
      Console.Write("\n" + lastAdded + "Would you like to add an item to your list or view your list? (");
      Console.ForegroundColor = ConsoleColor.Yellow; 
      Console.Write("Add");
      Console.ForegroundColor = ConsoleColor.White; 
      Console.Write("/");
      Console.ForegroundColor = ConsoleColor.Green; 
      Console.Write("View");
      Console.ForegroundColor = ConsoleColor.White; 
      Console.Write("/");
      Console.ForegroundColor = ConsoleColor.Red; 
      Console.Write("Exit");
      Console.ForegroundColor = ConsoleColor.White; 
      Console.Write(") ");
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
          Console.ForegroundColor = ConsoleColor.White;
          Console.Write("(OK, fine...)");
          Console.ReadLine();
          goto Start;
        }
        Console.WriteLine("\n" + "Your To-Do List:" + "\n----------------");
        int count = 1;
        string spacing = "  ";
        foreach (Item thisItem in items)
        {
          if (count > 99)
          {
            spacing = "";
          }
          if (count > 9)
          {
            spacing = " ";
          }
          Console.BackgroundColor = ConsoleColor.White;
          Console.ForegroundColor = ConsoleColor.Magenta;
          Console.WriteLine("{0}", spacing + count + ". " + thisItem.Description);
          Console.BackgroundColor = ConsoleColor.Black;
          count++;
        }
        lastAdded = "";
        goto Start;
        }
        else if (userInput.ToLower() == "exit" || userInput.ToLower() == "e")
        {
          Console.BackgroundColor = ConsoleColor.DarkBlue;
          Console.Write("\n" + "Thanks for trying out the To-Do List! :)");
          Console.BackgroundColor = ConsoleColor.Black;
          Console.WriteLine("\n");
        }
        else
        {
          Console.WriteLine("\n" + "Not a recognized input.");
          lastAdded = "";
          goto Start;
        }
    }
  }
}