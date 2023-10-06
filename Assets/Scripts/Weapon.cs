using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject target;
    [SerializeField]
    private float _attackRange;
    [SerializeField]
    private float _attackRate;
    [SerializeField]
    private int _attackPower;
    [SerializeField]
    private int _attacksBeforeReload;
    [SerializeField]
    private int _maxAttacksBeforeReload;
    [SerializeField]
    private float _reloadTime;

    private float _reloadStartTime;
    private bool _isReloadStarted;
    private float _lastAttackTime;

    public int AttacksBeforeReload { get => _attacksBeforeReload; }
    public int MaxAttacksBeforeReload { get => _maxAttacksBeforeReload; }

    private void Update()
    {
        if (_isReloadStarted)
        {
            Reload();
        }
    }

    public void TryAttack()
    {
        if (target == null)
        {
            return;
        }

        if (_isReloadStarted)
        {
            return;
        }

        if (!IsReadyToAttack())
        {
            return;
        }

        Attack();

        if (_attacksBeforeReload <= 0)
        {
            StartReload();
        }
    }

    private void Reload()
    {
        if (_reloadStartTime + _reloadTime > Time.time)
        {
            return;
        }

        FinishReload();
    }

    private void StartReload()
    {
        _reloadStartTime = Time.time;
        _isReloadStarted = true;

        Debug.Log("Start Reload");
    }

    private void FinishReload()
    {
        _attacksBeforeReload = _maxAttacksBeforeReload;
        _isReloadStarted = false;

        Debug.Log("Finish Reload");
    }

    private bool IsReadyToAttack()
    {
        return Vector3.Distance(transform.position, target.transform.position) <= _attackRange && Time.time >= _lastAttackTime + _attackRate;
    }

    private void Attack()
    {
        var targetHealth = target.GetComponent<Health>();
        targetHealth.DealDamage(_attackPower);
        _lastAttackTime = Time.time;
        _attacksBeforeReload--;
    }
}
