using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class LootComponent : MonoBehaviour
{
    private Upgrade _upgrade;
    private SpriteRenderer _spriteRenderer;

    public void Initialize(Upgrade upgrade)
    {
        _upgrade = upgrade;
        _spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        _spriteRenderer.sprite = upgrade.View;
    }

    public Upgrade GetUpgrade()
    {
        return _upgrade;
    }
}