namespace ConsoleInventory.Model.Abstract;

public interface IInventory
{
    int Capacity { get; }
    bool IsFull { get; }
    
    void AddToInventory(IItem item);
    void RemoveAllItemsWithId(string id);
    void RemoveItemInSlot(int slotId);
    void RemoveCertainAmountInSlot(int slotId, int amountToRemove);
    void MoveToSlot(int fromSlotId, int toSlotId);
}