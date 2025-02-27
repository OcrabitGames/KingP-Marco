using UnityEngine;

[CreateAssetMenu(fileName = "Pins", menuName = "Scriptable Objects/Pins")]
public class Pins : ScriptableObject
{
    public static int selection;
    public Pin[] pins;

    public int GetCount()
    {
        return pins.Length;
    }

    public Pin GetPin(int index)
    {
        return pins[index];
    }
}
