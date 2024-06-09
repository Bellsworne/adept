namespace ADEPT_Engine;

public class Node
{
    public string Name = String.Empty;
    
    public List<Node> Children => _children;


    private Node? _parent;
    private List<Node> _children = new();


    public Node(){}
    
    public virtual void Start(){}
    
    public virtual void Update()
    {
        foreach(var child in _children)
        {
            child.Update();
        }
    }

    public Node? GetParent()
    {
        return _parent;
    }

    public void SetParent(Node newParent)
    {
        _parent?.RemoveChild(this);
    }

    public void AddChild(Node child)
    {
        if (_children.Contains(child)) return;
        _children.Add(child);
        child._parent = this;
    }

    public void RemoveChild(Node child)
    {
        if (_children.Contains(child))
        {
            _children.Remove(child);
            child._parent = null;
        }
    }

    public Node? GetChild(string name)
    {
        return _children.FirstOrDefault(child => child.Name == name);
    }

    public void Destroy()
    {
        if (_parent is not null)
        {
            _parent.RemoveChild(this);
        }

        foreach (var child in _children.ToList())
        {
            child.Destroy();
        }

        _children.Clear();
    }
}
