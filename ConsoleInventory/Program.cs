using ConsoleInventory.Model;

class Program
{
    static void Main()
    {
        Inventory inventory = new Inventory(10);

        var apple = new Item("Apple", 10, 10);
        var apple2 = new Item("Apple", 10, 7);
        var burger = new Item("Burger", 10, 6);

        inventory.AddToInventory(apple);
        inventory.AddToInventory(apple2);
        inventory.AddToInventory(burger);
        
        //inventory.RemoveAllItemsWithId("Apple");

        //inventory.AddToInventory(apple);
        //inventory.AddToInventory(apple2);
        
        //inventory.RemoveItemInSlot(3);

        //inventory.AddToInventory(burger);
        
        inventory.RemoveCertainAmountInSlot(1, 3);
        
        //inventory.MoveToSlot(1, 2);
        
        Console.ReadLine();
    }
}