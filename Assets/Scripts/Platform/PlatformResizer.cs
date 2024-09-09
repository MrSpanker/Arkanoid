using UnityEngine;
using DG.Tweening;

public class PlatformResizer : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _audioClip;
    [SerializeField] private float _timeToResize;

    private Vector3 _initialScale;

    void Start()
    {
        _initialScale = transform.localScale;
    }

    public void ResizePlatformX(float multiplier)
    {
        transform.DOScaleX(transform.localScale.x * multiplier, _timeToResize);
        _audioSource.PlayOneShot(_audioClip);
    }

    public void ResetToInitialScale()
    {
        transform.DOScale(_initialScale, _timeToResize);
        _audioSource.PlayOneShot(_audioClip);
    }
}