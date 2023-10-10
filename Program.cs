//////////////////////////////////////////////////////////////////////////
///
/// <summary>
/// This example illustrates how to use the C# dynamic object to implement
/// a shopping Cart
/// 
/// advantages: 
///  - simple, no classes
///  - easy to extend, by adding new properties and methods
///  - uses functional programming style (lambda expressions)
///  
/// disadvantages:
///  - no intellisense
///  - no compile time checking
/// </summary>
/// 
/// 
//////////////////////////////////////////////////////////////////////////


using System.Dynamic;


// create the shopping cart like a js object
dynamic cart = new ExpandoObject();
cart.Items = new Dictionary<string, string>();

// what would we like to do with the shopping cart?

// sc is a collection of key value pairs
// so we would like to add item to it
cart.AddItem = new Action<string, string>((string itemName, string itemValue) =>
{
    // add the item to the cart
    itemName = itemName.ToLower();
    cart.Items[itemName] = itemValue;
});

cart.Print = new Action(() =>
{
    // add the item to the cart
    foreach (var item in cart.Items)
    {
        Console.WriteLine($"{item.Key} : {item.Value}");
    }
});


static bool IsItemInCart(dynamic cart, string itemName)
{
    itemName = itemName.ToLower();
    return cart.Items.ContainsKey(itemName);
}

cart.AddItem("Milk", "2.99");

// simulate js mixing in a new method
cart.IsBreadInCart = new Func<bool>(() => IsItemInCart(cart, "bread"));
cart.IsMilkInCart = new Func<bool>(() => IsItemInCart(cart, "milk"));

Console.WriteLine($"Is bread in cart? {cart.IsBreadInCart()}");
Console.WriteLine($"Is milk in cart? {cart.IsMilkInCart()}");



