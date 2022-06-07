using ConsoleInventory.Model.Abstract;

namespace ConsoleInventory.Model;

public class Item : IItem
{
    public string id { get; private set; }
    public int amount { get; set; }
    public int maxAmountInSlot { get; set; }

    public Item(IItem item)
    {
        id = item.id;
        amount = item.amount;
        maxAmountInSlot = item.maxAmountInSlot;
    }

    public Item(string Id, int MaxAmountInSlot, int Amount = 1)
    {
        id = Id;
        maxAmountInSlot = MaxAmountInSlot;
        amount = Amount;
    }
}