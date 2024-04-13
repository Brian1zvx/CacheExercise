// See https://aka.ms/new-console-template for more information
using CacheExercise;

Console.WriteLine("Hello, World!");
var test = new GenericCache(10);
for (int i = 0; i < 10; i++)
{
    var objectRemoved = test.Add(i, "Value at: " + i);
    if (objectRemoved != null)
    {
        Console.WriteLine(objectRemoved.ToString());
    }
}
var newObjectRemoved = test.Add(10, "Value at: 10");
Console.WriteLine(newObjectRemoved.ToString());
