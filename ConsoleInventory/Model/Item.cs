using ConsoleInventory.Model.Abstract;

namespace ConsoleInventory.Model;

public class Item : IItem
{
    public string Id { get; }
    public int Amount { get; set; }
    public int MaxAmountInSlot { get; set; }

    public Item(IItem item)
    {
        Id = item.Id;
        Amount = item.Amount;
        MaxAmountInSlot = item.MaxAmountInSlot;
    }

    public Item(string id, int maxAmountInSlot, int amount = 1)
    {
        Id = id;
        MaxAmountInSlot = maxAmountInSlot;
        Amount = amount;
    }
}