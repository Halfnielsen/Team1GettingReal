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
        var item = new Book(1234, "Dune", Condition.Brugt, NeedsApproval.Ja, InWarehouse.Hjemme, "Frank Herbert", "1st");


        // Act
        repo.AddItem(item);
        var result = repo.GetById(item.ItemId);
        var result2 = repo.GetById("9999");

        // Assert
        Assert.IsNotNull(result);
        Assert.AreEqual(item.ItemId, result.ItemId);
        Assert.AreEqual(item.Name, result.Name);
    }
    [TestMethod]
    public void EditItem_ShouldEditExistingItem()
    {
        // Arrange
        var repo = new MemoryItemRepo();
        var item = new Book(1234, "Dune", Condition.Brugt, NeedsApproval.Ja, InWarehouse.Hjemme, "Frank Herbert", "1st");
        repo.AddItem(item);

        // Act
        item.Name = "New Title";
        repo.EditItem(item);
        var result = repo.GetById(item.ItemId);

        // Assert
        Assert.AreEqual("New Title", result.Name);
    }
}