namespace Cookos;

using System.Collections.Generic;
using Godot;

public static class Vector3Extensions
{
    public static Vector3 Barycenter(this ICollection<Vector3> points)
    {
        var sum = Vector3.Zero;

        foreach (var point in points)
        {
            sum += point;
        }

        var barycenter = sum / points.Count;

        return barycenter;
    }
}
