using UnityEngine;
using UnityEngine.UI;

public sealed class FeedbackInteraction : MonoBehaviour
{
    [SerializeField] private Image _actualImageIcon;

    private void Awake()
    {
        _actualImageIcon.gameObject.SetActive(false);
    }

    private void OnTriggerStay(Collider col)
    {
        FeedbackIcon feedbackIcon = col.GetComponent<FeedbackIcon>();
        if (feedbackIcon)
        {
            UpdateActualImageIcon(feedbackIcon.IconToShow);
            _actualImageIcon.gameObject.SetActive(true);
        }
        else
        {
            UpdateActualImageIcon(null);
            _actualImageIcon.gameObject.SetActive(false);
        }
    }

    private void OnTriggerExit(Collider col)
    {
        FeedbackIcon feedbackIcon = col.GetComponent<FeedbackIcon>();
        if (feedbackIcon)
        {
            UpdateActualImageIcon(null);
            _actualImageIcon.gameObject.SetActive(false);
        }
    }

    public void UpdateActualImageIcon(Sprite sprite)
    {
        _actualImageIcon.sprite = sprite;
    }
}
