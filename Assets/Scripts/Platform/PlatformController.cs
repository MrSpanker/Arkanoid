using UnityEngine;

public class PlatformController : MonoBehaviour
{
    [SerializeField] private float _speed = 15f;
    [SerializeField] private Transform _leftWall;
    [SerializeField] private Transform _rightWall;

    private Rigidbody2D _rigidbody2D;
    private Vector2 _moveDirection;

    private float _minX;
    private float _maxX;

    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();

        // Определяем границы движения по X на основе стен
        if (_leftWall != null && _rightWall != null)
        {
            _minX = _leftWall.position.x + _leftWall.GetComponent<Collider2D>().bounds.extents.x;
            _maxX = _rightWall.position.x - _rightWall.GetComponent<Collider2D>().bounds.extents.x;
        }
    }

    void Update()
    {
        // Управление с помощью мыши
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        _moveDirection = new Vector2(mousePosition.x, transform.position.y);

        // Ограничение движения по X
        _moveDirection.x = Mathf.Clamp(_moveDirection.x, _minX, _maxX);

        // Перемещение платформы
        _rigidbody2D.velocity = new Vector2((_moveDirection.x - transform.position.x) * _speed, _rigidbody2D.velocity.y);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Остановка движения при столкновении со стенкой
        if (collision.gameObject.CompareTag("Wall"))
        {
            Debug.Log("Платформа упёрлась в стенку");
            Vector2 collisionNormal = collision.contacts[0].normal;

            if (Mathf.Abs(collisionNormal.x) > Mathf.Abs(collisionNormal.y))
            {
                _rigidbody2D.velocity = new Vector2(0, _rigidbody2D.velocity.y);
            }
            else
            {
                _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, 0);
            }
        }
    }
}
