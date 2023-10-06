using TMPro;
using UnityEngine;

public class ShootingPanelController : MonoBehaviour
{
    [SerializeField]
    private Weapon _weapon;
    [SerializeField]
    private TMP_Text _bulletsCount;

    private void Update()
    {
        _bulletsCount.text = _weapon.AttacksBeforeReload.ToString() + "/" + _weapon.MaxAttacksBeforeReload.ToString();
    }
}
