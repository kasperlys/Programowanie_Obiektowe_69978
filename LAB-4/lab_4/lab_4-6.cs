Queue<int> queue = new Queue<int>();
queue.Enqueue(10);
queue.Enqueue(20);
Console.WriteLine(queue.Dequeue()); // 10

Stack<int> stack = new Stack<int>();
stack.Push(10);
stack.Push(20);
Console.WriteLine(stack.Pop()); // 20
