using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(SpriteRenderer))]
public class BreakableBlockComponent : MonoBehaviour
{
    public event UnityAction<GameObject> OnDestroyed;

    [SerializeField] private int _hitPoints = 1;

    private Color[] _blockColors = { Color.red, Color.yellow, Color.green };
    private SpriteRenderer _spriteRenderer;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();

        UpdateBlockColor();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            _hitPoints--;

            if (_hitPoints <= 0)
            {
                OnDestroyed?.Invoke(gameObject);
                Destroy(gameObject, 0.1f);
            }
            else
            {
                UpdateBlockColor();
            }
        }
    }

    private void UpdateBlockColor()
    {
        _spriteRenderer.color = _blockColors[_hitPoints - 1];
    }
}