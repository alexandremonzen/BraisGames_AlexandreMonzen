using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using PlayerCharacter;

public class ConstructionUI : MonoBehaviour
{
    [Header("UI Setup")]
    [SerializeField] private GameObject _screenUI;
    [SerializeField] private GameObject _warningText;

    [Header("Resource costs")]
    [SerializeField] private Text _woodAmount;
    [SerializeField] private Text _stoneAmount;
    [SerializeField] private Text _leafAmount;

    [Header("General Info")]
    [SerializeField] private Text _constructionName;
    [SerializeField] private Image _constructionImage;

    private PlaqueConstruction _actualPlaqueConstruction;
    private bool _canConstruct;

    private void Awake()
    {
        if(!_screenUI)
        {
            _screenUI = transform.GetChild(0).gameObject;
        }

        _warningText.SetActive(false);
    }

    public void OpenUI(PlaqueConstruction newPlaqueConstruction)
    {
        _actualPlaqueConstruction = newPlaqueConstruction;
        _screenUI.SetActive(true);
        _warningText.SetActive(false);
        UpdateConstructionInfo();
    }

    private void UpdateConstructionInfo()
    {
        if (_actualPlaqueConstruction)
        {
            _woodAmount.text = _actualPlaqueConstruction.ConstructionRecord.WoodAmount.ToString();
            _stoneAmount.text = _actualPlaqueConstruction.ConstructionRecord.StoneAmount.ToString();
            _leafAmount.text = _actualPlaqueConstruction.ConstructionRecord.LeafAmount.ToString();

            _constructionName.text = _actualPlaqueConstruction.ConstructionRecord.NamePreview;
            _constructionImage.sprite = _actualPlaqueConstruction.ConstructionRecord.ImagePreview;
        }
    }

    public void ConstructObjectButton()
    {
        if(_actualPlaqueConstruction)
        {
            _actualPlaqueConstruction.ConstructObject();
        }
    }

    public void CloseUI(bool disableMesh)
    {
        _screenUI.SetActive(false);
        _actualPlaqueConstruction.PreviewConstruction(!disableMesh);
        _actualPlaqueConstruction = null;
    }
    public void PopUpErrorMessage()
    {
        _warningText.SetActive(false);
        _warningText.SetActive(true);
    }
}
