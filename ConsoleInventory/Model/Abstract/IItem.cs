namespace ConsoleInventory.Model.Abstract;

public interface IItem
{
    public string id { get; }
    public int amount { get; set; }
    public int maxAmountInSlot { get; set; }

}