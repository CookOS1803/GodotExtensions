namespace Cookos;

using System.Collections.Generic;
using System.Linq;
using Godot;
using NodeArray = Godot.Collections.Array<Godot.Node>;

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

    public static IEnumerable<T> GetChildrenOfType<T>(this Node node) where T : class
    {
        var children = new NodeArray(node.GetChildren());

        return children.OfType<T>();
    }

    public static IEnumerable<T> GetChildrenOfTypeRecursively<T>(this Node node) where T : class
    {
        var result = new HashSet<T>();

        recurse(node);

        void recurse(Node currentNode)
        {
            result.UnionWith(currentNode.GetChildrenOfType<T>());

            var children = new NodeArray(currentNode.GetChildren());

            foreach (var c in children)
            {
                recurse(c);
            }
        }

        return result;
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
