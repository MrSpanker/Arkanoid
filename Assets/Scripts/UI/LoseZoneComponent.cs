using UnityEngine;

public class LoseZoneComponent : MonoBehaviour
{
    [SerializeField] private GameObject _loseMenu;

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Ball")) 
        {
            Debug.Log("����� ���� �� �����");
            _loseMenu.SetActive(true);
        }
    }
}