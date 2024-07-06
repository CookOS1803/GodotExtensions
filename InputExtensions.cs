namespace Cookos;

using Godot;

public static class InputExtensions
{
    public static Vector2 GetVector(string negativeX, string positiveX, string negativeY, string positiveY, float deadzone = 0.5f)
    {
        var strength = new Vector2(
            Input.GetActionStrength(positiveX) - Input.GetActionStrength(negativeX),
            Input.GetActionStrength(positiveY) - Input.GetActionStrength(negativeY)
        ).Normalized();
        
        return strength.Length() > deadzone ? strength : Vector2.Zero;
    }
}
