using UnityEngine;

[CreateAssetMenu(fileName ="New Item", menuName ="Items/New Item")]
public class Item : ScriptableObject
{
    public int id;
    public int count;
    public Sprite icon;
}
