class Program
{
    static void Main(string[] args)
    {
        Random rnd = new Random();
        int sizeTab = 26;
        int[] TabOfChisla = new int[sizeTab];



        for (int i = 0; i < sizeTab; i++)
        {
            int tmp = rnd.Next(10, 99);
            for (int j = 0; j <= i; ++j)
            {

                if (TabOfChisla[j] == tmp)
                {
                    tmp = rnd.Next(10, 99);
                }

            }
            TabOfChisla[i] = tmp;

        }
        for (int i = 0; i < sizeTab; i++)
        {
            Console.Write(TabOfChisla[i]);
            Console.Write(" ");

        }

        Console.WriteLine(' ');
        GoodBalancedTree tree = new GoodBalancedTree();
        for (int i = 0; i < sizeTab; i++) {
            tree.Add(TabOfChisla[i]);
        }

        tree.Print(tree.root, 0);
        tree.DisplayTree();
    }
}
class GoodBalancedTree
{
    public class Node
    {
        public int Value;
        public Node left;
        public Node right;
        public Node(int Value)
        {
            this.Value = Value;
        }
    }
    public Node root;
    public GoodBalancedTree()
    {

    }
    public void Add(int Value)
    {
        Node newItem = new Node(Value);
        if (root == null)
        {
            root = newItem;
        }
        else
        {
            root = Recurs(root, newItem);
        }
    }
    private Node Recurs(Node current, Node n)
    {
        if (current == null)
        {
            current = n;
            return current;
        }
        else if (n.Value < current.Value)
        {
            current.left = Recurs(current.left, n);
            current = balance_tree(current);
        }
        else if (n.Value > current.Value)
        {
            current.right = Recurs(current.right, n);
            current = balance_tree(current);
        }
        return current;
    }
    private Node balance_tree(Node current)
    {
        int DifferentOfTree = balance_factor(current);
        if (DifferentOfTree > 1)
        {
            if (balance_factor(current.left) > 0)
            {
                current = RotateLL(current);
            }
            else
            {
                current = RotateLR(current);
            }
        }
        else if (DifferentOfTree < -1)
        {
            if (balance_factor(current.right) > 0)
            {
                current = RotateRL(current);
            }
            else
            {
                current = RotateRR(current);
            }
        }
        return current;
    }
    

    public void Print(Node node,int lvl)
    {
        if(node!=null)
        {
            Print(node.right, ++lvl);
            for (int i = 0; i < lvl; ++i)
                Console.Write("    ");
            Console.WriteLine(node.Value);
            lvl--;
            Print(node.left, ++lvl);


        }


    }
    
    public void DisplayTree()
    {
        if (root == null)
        {
            Console.WriteLine("Tree is empty");
            return;
        }
        InOrderDisplayTree(root);
        Console.WriteLine(" ");
    }
    private void InOrderDisplayTree(Node current)
    {
        if (current != null)
        {
            Console.Write(current.Value);
            Console.Write(' ');
            InOrderDisplayTree(current.left);

            InOrderDisplayTree(current.right);
            
            //InOrderDisplayTree(current.left);
            //InOrderDisplayTree(current.right);
            //Console.Write(current.Value);
            //Console.Write(' ');

        }
    }
    private int max(int l, int r)
    {
        return l > r ? l : r;
    }
    private int getHeight(Node current)
    {
        int height = 0;
        if (current != null)
        {
            int l = getHeight(current.left);
            int r = getHeight(current.right);
            int m = max(l, r);
            height = m + 1;
        }
        return height;
    }
    private int balance_factor(Node current)
    {
        int l = getHeight(current.left);
        int r = getHeight(current.right);
        int DifferentOfTree = l - r;
        return DifferentOfTree;
    }

    private Node RotateRR(Node parent)
    {
        Node rotaion = parent.right;
        parent.right = rotaion.left;
        rotaion.left = parent;
        return rotaion;
    }
    private Node RotateLL(Node parent)
    {
        Node rotaion = parent.left;
        parent.left = rotaion.right;
        rotaion.right = parent;
        return rotaion;
    }
    private Node RotateLR(Node parent)
    {
        Node rotaion = parent.left;
        parent.left = RotateRR(rotaion);
        return RotateLL(parent);
    }
    private Node RotateRL(Node parent)
    {
        Node rotaion = parent.right;
        parent.right = RotateLL(rotaion);
        return RotateRR(parent);
    }
}