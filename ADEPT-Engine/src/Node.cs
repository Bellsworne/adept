namespace ADEPT_Engine;

public class Node
{
    public string Name = String.Empty;


    private List<Node> _children;
    
    public Node(){}
    
    public virtual void Start(){}
    public virtual void Update(){}
}