using System;// for IDisposable
using System.Collections.Generic;// for List
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ToDoList.Models;

namespace ToDoList.Tests
{
  [TestClass]
  public class ItemTests : IDisposable// " : IDisposable" allows for teardown between tests
  {

    public void Dispose()
    {
      // Automatically runs after every test
      Item.ClearAll();// "ClearAll()" needs to be defined in Item.cs
    }

    // Test methods
    [TestMethod]
    public void ItemConstructor_CreatesInstanceOfItem_Item()
    {
      Item newItem = new Item("test");
      Assert.AreEqual(typeof(Item), newItem.GetType());
    }

    [TestMethod]
    public void GetDescription_ReturnsDescription_String()
    {
      // Arrange
      string description = "Walk the dog.";
      Item newItem = new Item(description);

      // Act
      string result = newItem.Description;

      // Assert
      Assert.AreEqual(description, result);
    }

    [TestMethod]
    public void SetDescription_SetDescription_String()
    {
      // Arrange
      string description = "Walk the dog.";
      Item newItem = new Item(description);

      // Act
      string updatedDescription = "Do the dishes";
      newItem.Description = updatedDescription;
      string result = newItem.Description;

      // Assert
      Assert.AreEqual(updatedDescription, result);
    }

    [TestMethod]
    public void GetAll_ReturnsEmptyList_ItemList()
    {
      // Arrange
      List<Item> newList = new List<Item> { };

      // Act
      List<Item> result = Item.GetAll();

      // Assert
      CollectionAssert.AreEqual(newList, result);
    }

    [TestMethod]
    public void GetAll_ReturnsItems_ItemList()
    {
      // Arrange
      string description01 = "Walk the dog";
      string description02 = "Wash the dishes";
      Item newItem1 = new Item(description01);
      Item newItem2 = new Item(description02);
      List<Item> newList = new List<Item> { newItem1, newItem2 };

      // Act
      List<Item> result = Item.GetAll();

      // Assert
      CollectionAssert.AreEqual(newList, result);
    }

  }
}