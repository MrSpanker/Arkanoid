using UnityEngine;

public class WallController : MonoBehaviour
{
    [SerializeField] private GameObject _topWall;
    [SerializeField] private GameObject _leftWall;
    [SerializeField] private GameObject _rightWall;

    void Start()
    {
        PositionWalls();
    }

    void PositionWalls()
    {
        Camera mainCamera = Camera.main;

        if (mainCamera == null)
        {
            Debug.LogError("Main camera not found!");
            return;
        }

        // �������� ������� ������ � ������� �����������
        float screenHeight = 2f * mainCamera.orthographicSize;
        float screenWidth = screenHeight * mainCamera.aspect;

        // ������������� ����� � ������ ������
        PositionWall(_leftWall, new Vector3(-screenWidth / 2f, 0f, 0f), new Vector2(1f, screenHeight));
        PositionWall(_rightWall, new Vector3(screenWidth / 2f, 0f, 0f), new Vector2(1f, screenHeight));

        // ������������� ������� ������
        PositionWall(_topWall, new Vector3(0f, screenHeight / 2f, 0f), new Vector2(screenWidth, 1f));
    }

    void PositionWall(GameObject wall, Vector3 position, Vector2 size)
    {
        wall.transform.position = position;
        BoxCollider2D collider = wall.GetComponent<BoxCollider2D>();
        if (collider != null)
        {
            collider.size = size;
        }

        // ��������� ������� ����� � ����������� �� Collider
        SpriteRenderer renderer = wall.GetComponent<SpriteRenderer>();
        if (renderer != null)
        {
            renderer.size = size;
        }
    }
}
