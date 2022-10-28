using System.Collections;
using UnityEngine;

[RequireComponent(typeof(HealthStructure))]
public class ResourceDesctructibleObject : MonoBehaviour, IDestructible
{
    [Header("Resource Setup")]
    [SerializeField] private GameObject _objectToSpawnOnDestroy;
    [SerializeField] private int _minAmountToSpawn;
    [SerializeField] private int _maxAmountToSpawn;
    [SerializeField][Range(0.1f, 60)] private float _timeToRespawn = 0.1f;
    private int _totalDropAmount;

    [Header("Spawn Objects Position")]
    [SerializeField] private float _offsetSpawnY;
    private Vector3 _spawnVectorOffset;
    private Vector3 _randomSpawnVector;

    protected HealthStructure _healthStructure;
    private GameObject _meshObject;
    private Collider _collider;

    protected virtual void Awake()
    {
        _healthStructure = GetComponent<HealthStructure>();
        _meshObject = transform.GetChild(0).gameObject;
        _collider = GetComponent<Collider>();

        _spawnVectorOffset = this.transform.position;
        _spawnVectorOffset += Vector3.up * _offsetSpawnY;
    }

    protected virtual void Start()
    {
        _healthStructure.OnDie += DestroyObject;
    }

    public virtual void DestroyObject()
    {
        SetMeshAndColliderStatus(false);
        SpawnDrops();
        StartCoroutine(RespawnProcess());
    }

    private void SpawnDrops()
    {
        _totalDropAmount = Random.Range(_minAmountToSpawn, _maxAmountToSpawn);

        for (int i = 0; i < _totalDropAmount; i++)
        {
            _randomSpawnVector = new Vector3(Random.Range(-1f, 1f), Random.Range(0f, 2f), Random.Range(-1f, 1f));
            GameObject itemDrop = Instantiate(_objectToSpawnOnDestroy, _spawnVectorOffset + _randomSpawnVector, Quaternion.identity);
        }
    }

    private void SetMeshAndColliderStatus(bool enabled)
    {
        _meshObject.SetActive(enabled);
        _collider.enabled = enabled;
    }

    private IEnumerator RespawnProcess()
    {
        yield return new WaitForSeconds(_timeToRespawn);

        _healthStructure.RestoureTotalHealth();
        SetMeshAndColliderStatus(true);

        yield return null;
    }
}
