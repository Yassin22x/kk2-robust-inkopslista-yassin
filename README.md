# Robust inköpslista

## Del 1 - Felrapport

### Fel 1 - Tomma rader
Programmet kraschade när det faanns tomma rader i 'items.txt' eftersom koden försökte läsa de som varor.
Jag rättade till det med hjälp av 'IsNullOrWhiteSpace' och 'continue' i ShoppingList.cs

### Fel 2 – Felaktig inmatning
Programmet kraschade om man skrev bokstäver istället för siffror i menyn eller priset. Jag bytte från `int.Parse` till `int.TryParse` i `Program.cs`.

### Fel 3 – Ta bort en vara som inte finns
Programmet kraschade när man försökte ta bort en vara med ett nummer som inte fanns. Jag lade till en kontroll i `RemoveAt` i `ShoppingList.cs`.

### Fel 4 – Filen saknas
Programmet kunde krascha om `items.txt` saknades. Jag lade till `File.Exists` i `Load` så att programmet kan starta ändå.



### Fel 5 – Fel totalsumma
Programmet räknade inte med första varan eftersom loopen började på `1`. Jag ändrade den till `0` i `Total` i `ShoppingList.cs`.



### Fel 6 – Fel vid sparning
Programmet kunde dölja att sparningen misslyckades. Jag ändrade felhanteringen i `Save` i `ShoppingList.cs` så att ett felmeddelande visas.



## Del 2 – Designval

Jag valde att använda `true` och `false` i `Add` för att kontrollera budgeten på 100 kr.

Om varan är för dyr returneras `false` och ett meddelande visas. Jag valde detta eftersom det är enkelt och programmet slipper krascha.

Jag har också gjort så att man inte kan lägga till en vara med tomt namn eller negativt pris.


## Klassdiagram

```mermaid
classDiagram
    Program --> ShoppingList : använder
    ShoppingList --> Item : innehåller

    class Program {
        +Main()
    }

    class ShoppingList {
        -List~Item~ items
        -string path
        -int budget
        +Add(Item item) bool
        +RemoveAt(int number)
        +Total() int
        +Find(string name)
        +Save()
        +Load()
    }

    class Item {
        +string Name
        +int Price
        +Item(string name, int price)
    }
```