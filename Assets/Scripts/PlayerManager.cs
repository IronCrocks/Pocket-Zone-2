using UnityEngine;

public class PlayerManager : MonoBehaviour, IDataHandler
{
    [SerializeField]
    private Transform _player;

    public object GetData()
    {
        return new PlayerData(_player.transform);
    }

    public void LoadData(object data)
    {
        if(data is not PlayerData)
        {
            return;
        }

        var playerData = (PlayerData)data;

        SetHealth(playerData);
    }

    private void SetHealth(PlayerData playerData)
    {
        var healthComponent = _player.GetComponent<Health>();
        healthComponent.health = playerData.Health;
        healthComponent.maxHealth = playerData.MaxHealth;
    }
}
