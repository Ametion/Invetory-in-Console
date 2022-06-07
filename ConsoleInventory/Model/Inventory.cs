using ConsoleInventory.Model.Abstract;

namespace ConsoleInventory.Model;

public class Inventory : IInventory
{
    private List<Slot> _inventory;

    public int Capacity { get; }
    public bool IsFull { get; }

    public Inventory(int capacity)
    {
        Capacity = capacity;
        _inventory = new List<Slot>();

        for (int i = 0; i < capacity; i++)
        {
            var newSlot = new Slot(i + 1);
            _inventory.Add(newSlot);
        }
    }
    
    public void AddToInventory(IItem item)
    {
        var amountToAdd = item.amount;
        
        foreach (var slot in _inventory)
        {
            if (slot.Item == null)
            {
                var newItem = new Item(item);
                slot.Item = newItem;
                break;
            }

            if (slot.Item != null && slot.Item.id == item.id && !slot.IsFull && slot.Amount + item.amount <= slot.Capacity)
            {
                slot.Item.amount += item.amount;
                break;
            }
            
            if (slot.Item != null && !slot.IsFull && slot.Item.id == item.id)
            {
                while (!slot.IsFull)
                {
                    slot.Item.amount++;
                    amountToAdd--;
                }

                var remainingItems = new Item(item.id, item.maxAmountInSlot, amountToAdd);
                AddToInventory(remainingItems);

                break;
            }
        }
    }

    public void RemoveAllItemsWithId(string id)
    {
        var slots = _inventory.FindAll(_slot =>  _slot.Item != null && _slot.Item.id == id);

        foreach (var slot in slots)
            slot.Clear();
    }

    public void RemoveItemInSlot(int slotId)
    {
        var slot = _inventory.Find(_slot => _slot.SlotId == slotId);

        if (slot.Item != null) slot.Clear();
        else throw new Exception("Slot is already Empty");
    }

    public void RemoveCertainAmountInSlot(int slotId, int amountToRemove)
    {
        var slot = _inventory.Find(_slot => _slot.SlotId == slotId);

        if (slot.Item != null)
        {
            if (slot.Item.amount - amountToRemove <= 0)
                slot.Item = null;
            else slot.Item.amount -= amountToRemove;
        }
        else throw new Exception("Slot is empty");
    }


    public void MoveToSlot(int fromSlotId, int toSlotId)
    {
        var slotFrom = _inventory.Find(_slot => _slot.SlotId == fromSlotId);
        var slotTo = _inventory.Find(_slot => _slot.SlotId == toSlotId);

        if (slotFrom == slotTo) return;
        if (slotFrom == null) return;

        if (slotTo.Item != null)
        {
            if (slotFrom.Item.id == slotTo.Item.id && slotFrom.Amount + slotTo.Amount <= slotTo.Capacity)
            {
                slotTo.Item.amount += slotFrom.Amount;
                slotFrom.Clear();
            }
        }
        else if (slotTo.Item == null)
        {
            var newItem = new Item(slotFrom.Item);
            slotTo.Item = newItem;
            slotFrom.Clear();
        }
        else if (slotFrom.Item.id != slotTo.Item.id)
        {
            Console.WriteLine("You trying to move item to another with another id than item you moving");
        }
    }
}