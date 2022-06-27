namespace ConsoleInventory.Model.Abstract;

public interface IItem
{
    public string Id { get; }
    public int Amount { get; set; }
    public int MaxAmountInSlot { get; set; }

}