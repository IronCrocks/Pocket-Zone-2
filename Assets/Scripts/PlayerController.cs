using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float _moveSpeed = 5f;
    [SerializeField]
    private Joystick _joystick;
    [SerializeField]
    private float _targetLockRange = 50;

    private Vector2 _movement;
    private Rigidbody2D _rigidbody;
    private Weapon _weapon;
    private GameObject _skeletonRoot;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _weapon = GetComponentInChildren<Weapon>();
        _skeletonRoot = transform.Find("Skeleton Root").gameObject;
    }

    private void Update()
    {
        _movement = new Vector2(_joystick.Horizontal, _joystick.Vertical);
        _weapon.target = GetClosestEnemyInRange();

        Vector2 direction;

        if (_weapon.target == null)
        {
            direction = _movement;
        }
        else
        {
            direction = GetLookDirection(_weapon.target.transform.position);
        }

        Flip(direction);
    }

    private void FixedUpdate()
    {
        _rigidbody.velocity = _movement.normalized * _moveSpeed;
    }

    public void Attack()
    {
        _weapon.TryAttack();
    }

    private GameObject GetClosestEnemyInRange()
    {
        var enemies = GetEnemiesInRange().ToList();

        if (!enemies.Any())
        {
            return null;
        }

        float minDistance = enemies.Min(p => Vector3.Distance(transform.position, p.transform.position));
        var closestEnemy = enemies.FirstOrDefault(p => Vector3.Distance(transform.position, p.transform.position) == minDistance);

        return closestEnemy;
    }

    private Vector3 GetLookDirection(Vector3 targetPosition) => targetPosition - transform.position;

    private void Flip(Vector2 direction)
    {
        if (direction.x >= 0)
        {
            _skeletonRoot.transform.localScale = new Vector3(1, 1, 1);
        }
        else
        {
            _skeletonRoot.transform.localScale = new Vector3(-1, 1, 1);
        }
    }

    private IEnumerable<GameObject> GetEnemiesInRange() => GameObject.FindGameObjectsWithTag("Enemy").
        Where(p => Vector3.Distance(transform.position, p.transform.position) <= _targetLockRange);
}
