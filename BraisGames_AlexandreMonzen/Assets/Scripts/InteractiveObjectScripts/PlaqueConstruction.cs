using System.Collections;
using System.Collections.Generic;
using PlayerCharacter;
using UnityEngine;

public class PlaqueConstruction : StaticInteractiveObjectPlayer
{
    [Header("Construction Setup")]
    [SerializeField] private ConstructionUI _constructionUI;
    [SerializeField] private ConstructionRecord _constructionRecord;

    [Header("Construction GameObject")]
    [SerializeField] private Transform _constructionSpawn;
    [SerializeField] private GameObject _constructionPrefab;

    [Header("Gameobject Visual")]
    [SerializeField] private Material _normalMaterial;
    [SerializeField] private Material _transparentMaterial;
    [SerializeField] private ParticleSystem _particleConstruction;
    private MeshRenderer _constructionPrefabMeshRenderer;

    public ConstructionRecord ConstructionRecord { get => _constructionRecord; }
    private PlayerInventory _actualPlayerInventory;
    private MoveToTargetPoint _moveToTargetPoint;
    private bool _canConstruct;

    protected override void Awake()
    {
        _canConstruct = false;
        _moveToTargetPoint = GetComponent<MoveToTargetPoint>();
    }

    private void Start()
    {
        _constructionPrefab = Instantiate(_constructionRecord.PrefabConstruction, _constructionSpawn.transform.position, new Quaternion(0, 180, 0, 0));
        _constructionPrefabMeshRenderer = _constructionPrefab.transform.GetChild(1).GetComponent<MeshRenderer>();
        _constructionPrefabMeshRenderer.material = _transparentMaterial;
        _constructionPrefab.SetActive(false);
    }

    public override void Interact(PlayerInteraction playerInteraction)
    {
        if (CanBeInteracted)
        {
            if (!Interacted)
            {
                UsePlaque(playerInteraction.PlayerInventory);
                _constructionPrefab.SetActive(false);
            }
        }
    }

    private void UsePlaque(PlayerInventory playerInventory)
    {
        _actualPlayerInventory = playerInventory;
        _constructionUI.OpenUI(this);
    }

    private bool CheckIfCanConstruct(PlayerInventory playerInventory)
    {
        return _canConstruct = playerInventory.CompareAmountOnInventory(ItemID.Wood, _constructionRecord.WoodAmount) &&
                               playerInventory.CompareAmountOnInventory(ItemID.Stone, _constructionRecord.StoneAmount) &&
                               playerInventory.CompareAmountOnInventory(ItemID.Leaf, _constructionRecord.LeafAmount);

    }

    public void ConstructObject()
    {
        if (_actualPlayerInventory)
        {
            if (CheckIfCanConstruct(_actualPlayerInventory))
            {
                _actualPlayerInventory.ChangeItemAmountOnInventory(ItemID.Wood, -_constructionRecord.WoodAmount);
                _actualPlayerInventory.ChangeItemAmountOnInventory(ItemID.Stone, -_constructionRecord.StoneAmount);
                _actualPlayerInventory.ChangeItemAmountOnInventory(ItemID.Leaf, -_constructionRecord.LeafAmount);
                _actualPlayerInventory.InvokeUpdateUIAction();

                _constructionPrefab.SetActive(true);
                _constructionUI.CloseUI(false);
                _constructionPrefabMeshRenderer.material = _normalMaterial;
                _particleConstruction.Play();

                _moveToTargetPoint.MoveToTargetPositionMethod();
                CanBeInteracted = false;
            }
            else
            {
                _constructionUI.PopUpErrorMessage();
            }
        }
    }

    public void PreviewConstruction(bool state)
    {
        _constructionPrefab.SetActive(state);
        _constructionPrefabMeshRenderer.material = _transparentMaterial;
    }
}
