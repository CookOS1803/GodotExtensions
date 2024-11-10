using Godot;

namespace Cookos;

public static class MeshExtensions
{
    public static Vector3? VerticesBarycenter(this Mesh mesh)
    {
        var arrays = mesh.SurfaceGetArrays(0);
        var vertices = arrays[(int)Mesh.ArrayType.Vertex] as Vector3[];

        return vertices?.Barycenter();
    }
}
