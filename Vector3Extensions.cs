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

    public static void Add(this IList<Vector3> points, Vector3 delta)
    {
        for (int i = 0; i < points.Count; i++)
        {
            points[i] += delta;
        }
    }

    public static bool IsEqualApprox(this Vector3 self, Vector3 other, float tolerance)
    {
        return Mathf.IsEqualApprox(self.x, other.x, tolerance) &&
               Mathf.IsEqualApprox(self.y, other.y, tolerance) &&
               Mathf.IsEqualApprox(self.z, other.z, tolerance);
    }
}
