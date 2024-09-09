using UnityEngine;

public class BallController : MonoBehaviour
{
    [SerializeField] private float _initialSpeed = 8f;
    [SerializeField] private float _directionVariance = 0.5f;

    private Rigidbody2D _rigidbody2D;
    private bool _hasLaunched = false; // ‘лаг, чтобы отслеживать, был ли м€ч запущен

    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (!_hasLaunched)
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
            {
                LaunchBall();
                _hasLaunched = true;
            }
        }
    }

    void LaunchBall()
    {
        transform.SetParent(null);

        float randomDirection = Random.Range(-_directionVariance, _directionVariance);
        Vector2 direction = new Vector2(randomDirection, 1).normalized;
        _rigidbody2D.velocity = direction * _initialSpeed;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        _rigidbody2D.velocity = _rigidbody2D.velocity.normalized * _initialSpeed;
    }
}
