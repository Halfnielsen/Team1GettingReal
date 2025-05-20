using Microsoft.VisualStudio.TestTools.UnitTesting;
using GettingReal.Model.Repositories;
using GettingReal.Model;
using System.Security.Cryptography.X509Certificates;

namespace GettingRealTests;

[TestClass]
public class ItemTests
{
    [TestMethod]
    public void AddItem_ShouldAddItemInMemory()
    {
        // Arrange
        var repo = new MemoryItemRepo();
        var item = new Book(10, "Test", Condition.Ny, NeedsApproval.Nej, InWarehouse.Hjemme, "Author", "1st");
        repo.AddItem(item);
        // Act
        var result = repo.GetById(10);
        // Assert
        Assert.IsNotNull(result);
        Assert.AreEqual("Test", result.Name);
    }
    [TestMethod]
    public void EditItem_ShouldEditExistingItem()
    {
        // Arrange
        var repo = new MemoryItemRepo();
        var item = new Book(1234, "Dune", Condition.Brugt, NeedsApproval.Ja, InWarehouse.Hjemme, "Frank Herbert", "1st");
        repo.AddItem(item);
        // Act
        item.Name = "Updated";
        repo.EditItem(item);
        var result = repo.GetById(item.ItemId);
        // Assert
        Assert.AreEqual("Updated", result.Name);
    }

    [TestMethod]
    public void AddItem_ShouldNotAllowDuplicateIds()
    {
        // Arrange
        var repo = new MemoryItemRepo();
        var item1 = new Book(1, "Book1", Condition.Ny, NeedsApproval.Nej, InWarehouse.Hjemme, "Author", "1st");
        var item2 = new Book(1, "Book2", Condition.Brugt, NeedsApproval.Nej, InWarehouse.Hjemme, "Author", "2nd");
        // Act
        repo.AddItem(item1);
        // Assert
        Assert.ThrowsException<ArgumentException>(() => repo.AddItem(item2));
    }
    [TestMethod]
    public void DeleteItem_ShouldRemoveItem()
    {
        // Arrange
        var repo = new MemoryItemRepo();
        var item = new Book(30, "ToDelete", Condition.Ny, NeedsApproval.Nej, InWarehouse.Hjemme, "Author", "1st");
        // Act
        repo.AddItem(item);
        repo.DeleteItem(item);
        // Assert
        Assert.ThrowsException<Exception>(() => repo.GetById(30));
    }
    [TestMethod]
    public void GetAllItems_ShouldReturnAllAddedItems()
    {
        // Arrange
        var repo = new MemoryItemRepo();
        repo.AddItem(new Book(1, "A", Condition.Ny, NeedsApproval.Nej, InWarehouse.Hjemme, "Author", "1st"));
        repo.AddItem(new Book(2, "B", Condition.Brugt, NeedsApproval.Ja, InWarehouse.Hjemme, "Author", "2nd"));
        // Act
        var all = repo.GetAllItems().ToList();
        // Assert
        Assert.AreEqual(2, all.Count);
        Assert.IsTrue(all.Any(i => i.ItemId == 1));
        Assert.IsTrue(all.Any(i => i.ItemId == 2));
    }
    [TestMethod]
    public void GetAllItems_ShouldReturnEmpty_WhenNoItemsAdded()
    {
        // Arrange
        var repo = new MemoryItemRepo();
        // Act
        var allItems = repo.GetAllItems();
        // Assert
        Assert.AreEqual(0, allItems.Count());
    }
    [TestMethod]
    public void GetById_ShouldThrowException_WhenItemNotFound()
    {
        var repo = new MemoryItemRepo();
        Assert.ThrowsException<Exception>(() => repo.GetById(999));
    }
}