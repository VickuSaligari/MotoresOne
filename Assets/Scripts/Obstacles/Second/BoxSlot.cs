using UnityEngine;

public class BoxSlot : MonoBehaviour
{
    public Color requiredColor;
    public BoxSize requiredSize;
    public bool isOccupied = false;
}

public enum BoxSize
{
    Small,
    Medium,
    Large,
    ExtraLarge
}