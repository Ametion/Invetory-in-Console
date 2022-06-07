namespace ConsoleInventory.Model.Abstract;

public interface ISlot
{
    public IItem Item { get; set; }
    public int Amount { get; }
    public int Capacity { get; }
    public bool IsFull { get; }
    public int SlotId { get; set; }
    
    void Clear();
}