namespace Project_T
{
    public class Node<T>
    {
        public T Data;
        public Node<T> Next;
        

        public Node(T d)
        {
            Data = d;
            Next = null;
        }

    }
}