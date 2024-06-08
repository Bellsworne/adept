namespace ADEPT_Engine;

public class Scene
{
    public Node Root => _rootNode;
    
    
    private Node _rootNode = new() { Name = "Root" };
    
    
    public void Update()
    {
        Root.Update();
    }
}