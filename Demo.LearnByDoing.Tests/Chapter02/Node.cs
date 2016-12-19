namespace Demo.LearnByDoing.Tests.Chapter02
{
    public class Node<T>
    {
        public Node<T> Next { get; set; }
        public T Data { get; set; }

        public Node(T data)
        {
            Data = data;
        }

        public void AddLast<T>(T data)
        {
            Node<T> currentNode = this as Node<T>;
            while (currentNode.Next != null)
            {
                currentNode = currentNode.Next;
            }

            Node<T> newNode = new Node<T>(data);
            currentNode.Next = newNode;
        }
    }
}