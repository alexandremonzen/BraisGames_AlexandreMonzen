using UnityEngine;

public sealed class FeedbackIcon : MonoBehaviour
{
    [SerializeField] private Sprite _iconToShow;

    public Sprite IconToShow { get => _iconToShow; }
}
