using System;

class animal_node
{
    public int id;
    public string name;
    public animal_node? left;
    public animal_node? right;

    public animal_node(int id, string name)
    {
        this.id = id;
        this.name = name;
        left = null;
        right = null;
    }
}

class animal_tree
{
    public animal_node? head;

    public void add(int id, string name)
    {
        animal_node new_node = new animal_node(id, name);

        if (head == null)
        {
            head = new_node;
            return;
        }

        animal_node current = head;
        while (true)
        {
            if (id < current.id)
            {
                if (current.left == null)
                {
                    current.left = new_node;
                    return;
                }
                current = current.left;
            }
            else
            {
                if (current.right == null)
                {
                    current.right = new_node;
                    return;
                }
                current = current.right;
            }
        }
    }

    public void print(animal_node? node)
    {
        if (node == null)
            return;

        print(node.left);
        Console.WriteLine($"{node.id} {node.name}");
        print(node.right);
    }
}

class Program
{
    static void Main()
    {
        animal_tree tree = new animal_tree();

        tree.add(8, "Лемур");
        tree.add(3, "Манул");
        tree.add(10, "Капибара");
        tree.add(1, "Фенек");
        tree.add(6, "Оцелот");
        tree.add(4, "Пума");
        tree.add(7, "Барсук");

        tree.print(tree.head);
    }
}
