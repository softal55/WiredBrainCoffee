using System.Threading.Channels;

StackDoubles();
stackStrings();

static void StackDoubles()
{
    var stack = new SimpleStack<double>();
    stack.Push(6.5);
    stack.Push(4.3);
    stack.Push(3.2);
    var sum = 0.0;
    while (stack.Count > 0)
    {
        double item = stack.Pop();
        Console.WriteLine($"Item: {item}");
        sum += item;
    }
    Console.WriteLine($"Sum: {sum}");
}

void stackStrings()
{
    var stack = new SimpleStack<string>();
    stack.Push("FaceBook");
    stack.Push("Instagram");
    while(stack.Count > 0)
    {
        Console.WriteLine(stack.Pop());
    }
}
