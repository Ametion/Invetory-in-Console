using ConsoleInventory.Model;

class Program
{
    static void Main()
    {
        Inventory inventory = new Inventory(10);

        var Apple = new Item("Apple", 10, 5);
        var Apple2 = new Item("Apple", 10, 6);
        var Burger = new Item("Burger", 10, 6);

        inventory.AddToInventory(Apple);
        inventory.AddToInventory(Apple2);
        inventory.AddToInventory(Burger);
        inventory.AddToInventory(Apple);
        
        //inventory.RemoveAllItemsWithId("Apple");
        
        //inventory.RemoveItemInSlot(2);
        
        //inventory.RemoveCertainAmountInSlot(2, 8);
        
        inventory.MoveToSlot(1, 3);

        Console.ReadLine();
    }
}