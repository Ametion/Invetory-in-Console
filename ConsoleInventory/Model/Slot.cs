using ConsoleInventory.Model.Abstract;

namespace ConsoleInventory.Model;

public class Slot : ISlot
{
    public IItem Item { get; set; }

    public int Amount
    {
        get
        {
            if (Item != null) return Item.Amount;
            
            return 0;
        }
    }

    public int Capacity
    {
        get
        {
            if (Item != null) return Item.MaxAmountInSlot;
            
            return 1;
        }
    }

    public bool IsFull => Capacity <= Amount;
    public int SlotId { get; set; }

    public Slot(int slotId) => SlotId = slotId;

    public void Clear() => Item = null;
}