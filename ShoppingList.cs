// Holds the items and takes care of loading and saving them.
class ShoppingList
{
    private List<Item> items = new List<Item>();
    private string path;
    private int budget = 100;  // Maxbelopp för inköpslistan

    public ShoppingList(string path)
    {
        this.path = path;
    }
public bool Add(Item item)
{
   
    if (Total() + item.Price > budget)   // Kontrollerar om varan gör att budgeten överskrids
    {
        return false;
    }

    items.Add(item);
    return true;
}

    // Removes the item the user sees as number 1, 2, 3 ...
    public void RemoveAt(int number)
    {
     if (number < 1 || number > items.Count)  // Kontrollerar att numret finns i listan
        {
            Console.WriteLine("Ogiltigt nummer. Försök igen.");
            return;
        }
     
        items.RemoveAt(number - 1);
    }

    // Adds up the price of every item on the list.
    public int Total()
    {
        int sum = 0;

        for (int i = 0; i < items.Count; i++)  //Räknar med alla varor från första varan
        {
            sum += items[i].Price;
        }

        return sum;
    }

    // Looks up an item by its name. Returns null if there is no such item.
    public Item Find(string name)
    {
        foreach (Item item in items)
        {
            if (item.Name == name)
            {
                return item;
            }
        }

        return null;
    }

    public void Print()
    {
        for (int i = 0; i < items.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {items[i]}");
        }

        Console.WriteLine($"Totalt: {Total()} kr");
    }

    // Writes one item per line, as "price;name".
    public void Save()
    {
        List<string> lines = new List<string>();

        foreach (Item item in items)
        {
            lines.Add($"{item.Price};{item.Name}");
        }

        try
        {
            File.WriteAllText(path, string.Join("\r\n", lines) + "\r\n");
        }
        catch (IOException)  // Hanterar fel vid sparning av filen
        {
            Console.WriteLine("Kunde inte spara filen.");
            return;
        }

        Console.WriteLine("Listan är sparad.");
    }

    // Reads the file back into the list.
    public void Load()
    {
        if (!File.Exists(path))  // Kontrollerar om filen finns
        {
            Console.WriteLine("Ingen sparad lista hittades.");
            return;
        }
        string text = File.ReadAllText(path);
        string[] lines = text.Split('\n');

        foreach (string line in lines)
        {
            if (string.IsNullOrWhiteSpace(line))
            {
                continue;  // Hoppar över tomma rader
            }
            string[] parts = line.Trim().Split(';');  // Tar bort osynliga tecken vid inläsning
            items.Add(new Item(parts[1], int.Parse(parts[0])));
        }
    }
}
