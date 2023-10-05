using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject target;
    public float attackRange;
    public float attackRate;
    public int attackPower;

    private float _lastAttackTime;

    // Update is called once per frame
    public void TryAttack()
    {
        if (target == null)
        {
            return;
        }

        if (!IsReadyToAttack())
        {
            return;
        }

        Attack();

        _lastAttackTime = Time.time;
    }

    private bool IsReadyToAttack()
    {
        return Vector3.Distance(transform.position, target.transform.position) <= attackRange && Time.time >= _lastAttackTime + attackRate;
    }

    private void Attack()
    {
        var targetHealth = target.GetComponent<Health>();
        targetHealth.DealDamage(attackPower);
    }
}
