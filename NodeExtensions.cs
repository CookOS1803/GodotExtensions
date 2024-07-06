namespace Cookos;

using Godot;

public static class NodeExtensions
{
    public static T GetChildOfType<T>(this Node node) where T : class
    {
        var children = node.GetChildren();

        foreach (var child in children)
        {
            if (child is T typedChild)
                return typedChild;
        }

        return null;
    }

    public static T GetParentRecursively<T>(this Node node) where T : class
    {
        var parent = node.GetParent();

        while (parent != null)
        {
            if (parent is T typedParent)
                return typedParent;

            parent = parent.GetParent();
        }

        return null;
    }

    public static void SetParent(this Node node, Node parent)
    {
        var oldParent = node.GetParent();
        oldParent.RemoveChild(node);
        parent.AddChild(node);
    }
}
