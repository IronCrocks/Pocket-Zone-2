using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Transform player;
    public float speed = 2f;
    public float rangeAlarm = 5;

    private Rigidbody2D _rigidbody;
    private Vector2 _movement;
    private GameObject _skeletonRoot;
    private Weapon _weapon;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _skeletonRoot = transform.Find("Skeleton Root").gameObject;
        _weapon = GetComponent<Weapon>();
    }

    void Update()
    {
        if (player == null)
        {
            return;
        }

        _movement = player.position - transform.position;

        Flip();
        _weapon.TryAttack();
    }

    private void FixedUpdate()
    {
        float distance = Vector3.Distance(transform.position, player.position);

        if (distance > rangeAlarm)
        {
            return;
        }

        Move();
    }

    private void Flip()
    {
        if (_movement.x >= 0)
        {
            _skeletonRoot.transform.localScale = new Vector3(1, 1, 1);
        }
        else
        {
            _skeletonRoot.transform.localScale = new Vector3(-1, 1, 1);
        }
    }

    private void Move()
    {
        _rigidbody.MovePosition((Vector2)transform.position + speed * Time.deltaTime * _movement.normalized);
    }
}
