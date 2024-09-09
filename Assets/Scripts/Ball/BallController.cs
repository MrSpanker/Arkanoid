using UnityEngine;

public class BallController : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _audioClip;
    [SerializeField] private float _initialSpeed = 8f;
    [SerializeField] private float _directionVariance = 0.5f;
    [SerializeField] private float _minReflectionAngle = 170f; // ƒиапазон угла при отскоке шарика 
    [SerializeField] private float _maxReflectionAngle = 190f; //

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
        GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        float randomDirection = Random.Range(-_directionVariance, _directionVariance);
        Vector2 direction = new Vector2(randomDirection, 1).normalized;
        _rigidbody2D.velocity = direction * _initialSpeed;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 normal = collision.contacts[0].normal;

        float angle = Mathf.Atan2(normal.y, normal.x) * Mathf.Rad2Deg;
        float randomAngle = Random.Range(_minReflectionAngle, _maxReflectionAngle);

        Vector2 reflectionDirection = Quaternion.Euler(0, 0, randomAngle) * -normal;
        _rigidbody2D.velocity = reflectionDirection.normalized * _initialSpeed;

        _audioSource.PlayOneShot(_audioClip);
    }
}