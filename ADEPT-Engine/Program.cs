using System.Security.Cryptography;
using ADEPT_Engine;
using Raylib_cs;
using static Raylib_cs.Raylib;
using ImGuiNET;
using rlImGui_cs;

class Program
{
    private static int _screenWidth = 900;
    private static int _screenHeight = 900;
    private static string _windowTitle = "ADEPT";

    private static string _treeText = "";

    private static Scene _scene;
    
    static void Main()
    {
        SetConfigFlags(ConfigFlags.Msaa4xHint | ConfigFlags.VSyncHint | ConfigFlags.ResizableWindow);
        InitWindow(_screenWidth, _screenHeight, _windowTitle);
        SetTargetFPS(60);

        _scene = new();

        Node node1 = new() { Name = "Node1" };
        Node node2 = new() { Name = "Node2" };
        Node node3 = new() { Name = "Node3" };
        Node node4 = new() { Name = "Node4" };
        Node node5 = new() { Name = "Node5" };
        Node node6 = new() { Name = "Node6" };
        Node node7 = new() { Name = "Node7" };
        
        node1.AddChild(node2);
        node2.AddChild(node3);
        _scene.Root.AddChild(node4);
        node4.AddChild(node5);
        node5.AddChild(node6);
        _scene.Root.AddChild(node7);
        
        _scene.Root.AddChild(node1);
        
        rlImGui.Setup(true);
        while (!WindowShouldClose())
        {
            if (IsWindowResized())
            {
                _screenHeight = GetScreenHeight();
                _screenWidth = GetScreenWidth();
            }
            
            _treeText = "";
            UpdateTreeText(_scene.Root);
            
            Update();
            Draw();
        }
        
        Cleanup();
    }
    
    
    
    static void UpdateTreeText(Node node, string indentation = "")
    {
        _treeText += indentation + node.Name + "\n";

        foreach (var child in node.Children)
        {
            UpdateTreeText(child, indentation + "- ");
        }
    }

    static void Update()
    {
        _scene.Update();

        if (IsKeyPressed(KeyboardKey.K))
        {
            if (_scene.Root.GetChild("Node1") is { } node)
            {
                _scene.Root.RemoveChild(node);    
            }
        }
    }

    static void Draw()
    {
        BeginDrawing();
        ClearBackground(Color.DarkGray);
        
        rlImGui.Begin();
        if (ImGui.Begin("Debug window"))
        {
            ImGui.TextUnformatted(GetFPS().ToString());
            ImGui.TextWrapped(_treeText);
        }
        rlImGui.End();
        
        EndDrawing();
    }

    static void Cleanup()
    {
        rlImGui.Shutdown();
        CloseWindow();
    }
}