internal class SimpleStack<T>
{
    private readonly T[] _item;

    public SimpleStack() =>  _item =new T[10];
    
  
    private int _CurrentIndex = -1;
    public int Count =>_CurrentIndex + 1;
    public  void Push(T item) => _item[++_CurrentIndex] = item;
    
    public T Pop() => _item[_CurrentIndex--];
}