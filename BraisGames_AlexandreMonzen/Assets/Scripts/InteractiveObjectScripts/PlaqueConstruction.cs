using UnityEngine;
using PlayerCharacter;
using FMODUnity;

public sealed class PlaqueConstruction : StaticInteractiveObjectPlayer
{
    [Header("Construction Setup")]
    [SerializeField] private ConstructionUI _constructionUI;
    [SerializeField] private ConstructionRecord _constructionRecord;

    [Header("Construction GameObject")]
    [SerializeField] private Transform _constructionSpawn;
    [SerializeField] private Quaternion _constructionRotation;
    private GameObject _constructionPrefab;

    [Header("Gameobject Visual")]
    [SerializeField] private Material _normalMaterial;
    [SerializeField] private Material _transparentMaterial;
    private MeshRenderer _constructionPrefabMeshRenderer;

    [Header("Particles")]
    [SerializeField] private ParticleSystem _particleConstruction;
    [SerializeField] private ParticleSystem _particlePlaque;

    public ConstructionRecord ConstructionRecord { get => _constructionRecord; }
    private PlayerInventory _actualPlayerInventory;
    private MoveToTargetPoint _moveToTargetPoint;
    private bool _canConstruct;

    [Header("Audio FMOD")]
    [SerializeField] private EventReference _constructionReference;
    private PlayAudioFMOD _playAudioFMOD;

    protected override void Awake()
    {
        _canConstruct = false;
        _moveToTargetPoint = GetComponent<MoveToTargetPoint>();
        _playAudioFMOD = GetComponent<PlayAudioFMOD>();

        if(!_constructionUI)
        {
            _constructionUI = FindObjectOfType<ConstructionUI>();
        }
    }

    private void Start()
    {
        _constructionPrefab = Instantiate(_constructionRecord.PrefabConstruction, _constructionSpawn.transform.position, _constructionRotation);
        _constructionPrefabMeshRenderer = _constructionPrefab.transform.GetChild(1).GetComponent<MeshRenderer>();
        _constructionPrefabMeshRenderer.material = _transparentMaterial;
        _constructionPrefab.SetActive(false);
    }

    private void OnTriggerEnter(Collider col)
    {
        PlayerMovement playerMovement = col.GetComponent<PlayerMovement>();
        if (playerMovement)
        {
            PreviewConstruction(true);
        }
    }

    private void OnTriggerExit(Collider col)
    {
        if (CanBeInteracted)
        {
            PlayerMovement playerMovement = col.GetComponent<PlayerMovement>();
            if (playerMovement)
            {
                PreviewConstruction(false);
            }
        }
    }

    public override void Interact(PlayerInteraction playerInteraction)
    {
        if (CanBeInteracted)
        {
            if (!Interacted)
            {
                UsePlaque(playerInteraction.PlayerInventory);
            }
            else
            {
                FinishPlaqueInteraction();
            }
        }
    }

    private void UsePlaque(PlayerInventory playerInventory)
    {
        Interacted = true;
        _actualPlayerInventory = playerInventory;
        _constructionUI.OpenUI(this);
    }

    private void FinishPlaqueInteraction()
    {
        Interacted = false;
        _constructionUI.CloseUI();
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

                ConstructBehaviour();
            }
            else
            {
                _constructionUI.PopUpErrorMessage();
            }
        }
    }

    private void ConstructBehaviour()
    {
        _constructionPrefab.SetActive(false);
        _constructionPrefab.SetActive(true);
        _constructionUI.CloseUI();
        _constructionPrefabMeshRenderer.material = _normalMaterial;

        _particleConstruction.Play();
        _particlePlaque.Play();

        _moveToTargetPoint.MoveToTargetPositionMethod();
        CanBeInteracted = false;

        _constructionUI.UpdateConstructionProgress();
        _playAudioFMOD.PlaySound3D(_constructionReference, this.transform.position);
    }

    public void PreviewConstruction(bool state)
    {
        _constructionPrefab.SetActive(state);
        _constructionPrefabMeshRenderer.material = _transparentMaterial;
    }
}
