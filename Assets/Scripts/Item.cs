using UnityEngine;

[CreateAssetMenu(fileName ="New Item", menuName ="Inventory Items/New Item")]
public class Item : ScriptableObject
{
    public int id;
    public Sprite icon;
}
