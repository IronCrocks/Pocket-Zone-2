using System;
using UnityEngine;

[Serializable]
public class PlayerData
{
    public int MaxHealth { get; private set; }
    public int Health { get; private set; }

    public PlayerData(Transform player)
    {
        var healthComponent = player.GetComponent<Health>();
        MaxHealth = healthComponent.health;
        Health = healthComponent.health;
    }
}
