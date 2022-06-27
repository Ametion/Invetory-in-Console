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
        var amountToAdd = item.Amount;
        
        foreach (var slot in _inventory)
        {
            if (slot.Item == null)
            {
                var newItem = new Item(item);
                slot.Item = newItem;
                break;
            }

            if (slot.Item != null && !slot.IsFull && slot.Item.Id == item.Id && slot.Amount + item.Amount <= slot.Capacity)
            {
                slot.Item.Amount += item.Amount;
                break;
            }
            
            if (slot.Item != null && !slot.IsFull && slot.Item.Id == item.Id)
            {
                while (!slot.IsFull)
                {
                    slot.Item.Amount++;
                    amountToAdd--;
                }

                var remainingItems = new Item(item.Id, item.MaxAmountInSlot, amountToAdd);
                AddToInventory(remainingItems);

                break;
            }
        }
    }

    public void RemoveAllItemsWithId(string id)
    {
        var slots = _inventory.FindAll(_slot =>  _slot.Item != null && _slot.Item.Id == id);

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
            if (slot.Item.Amount - amountToRemove <= 0)
                slot.Item = null;
            else slot.Item.Amount -= amountToRemove;
        }
        else throw new Exception("Slot is empty");
    }


    public void MoveToSlot(int fromSlotId, int toSlotId)
    {
        if (fromSlotId == toSlotId) throw new Exception("You trying move item to same slot is it in");

        var slotFrom = _inventory.Find(_slot => _slot.SlotId == fromSlotId);
        var slotTo = _inventory.Find(_slot => _slot.SlotId == toSlotId);

        IItem slotFromItem;
        IItem slotToItem;

        if (slotFrom.Item == null) throw new Exception("You trying to move item in empty slot");
            
        slotFromItem = slotFrom.Item;

        if (slotTo.Item != null)
        {
            slotToItem = slotTo.Item;
            
            if (slotTo.Item.Id == slotFrom.Item.Id && slotTo.Amount + slotFrom.Amount <= slotTo.Item.MaxAmountInSlot)
            {
                slotTo.Item.Amount += slotFrom.Amount;
                slotFrom.Clear();
                return;
            }
            
            if (slotTo.Item.Id != slotFrom.Item.Id)
            {
                slotTo.Item = slotFromItem;
                slotFrom.Item = slotToItem;
                return;
            }
        }

        if (slotTo.Item == null)
        {
            slotTo.Item = slotFromItem;
            slotFrom.Clear();
        }
    }
}