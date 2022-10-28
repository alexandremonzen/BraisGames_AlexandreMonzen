using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToTargetPoint : MonoBehaviour
{
    [Header("General Setup")]
    [SerializeField] private bool _worldPosition;
    [SerializeField] private Vector3 _initialPosition;
    [SerializeField] private Vector3 _targetPosition;
    
    [Tooltip("Total Time that the object will reach the target, in seconds")]
    [SerializeField] private float _timeToReachTarget;

    [Header("Use actual position inspector as Inital Position?")]
    [SerializeField] private bool _useActualPositionInspector;

    [Header("Disable Object when reach target?")]
    [SerializeField] private bool _desactiveObject;

    private float _timeElapsed;
    private float _averageSpeed;

    [Space(10)]
    [SerializeField] private bool _autoStart;

    private void Awake()
    {
        Setup();
    }

    private void Start()
    {
        if (_autoStart)
        {
            StartCoroutine(MoveToTargetPosition());
        }
    }

    public void Setup()
    {
        if (_worldPosition)
        {
            if (_useActualPositionInspector)
            {
                _initialPosition = transform.position;
            }

            transform.position = _initialPosition;
        }
        else
        {
            if (_useActualPositionInspector)
            {
                _initialPosition = transform.localPosition;
            }

            transform.localPosition = _initialPosition;
        }

        _timeElapsed = 0;
        _averageSpeed = CalculateAverageSpeed();
    }

    private float CalculateAverageSpeed()
    {
        return (Vector3.Distance(_targetPosition, _initialPosition)) / _timeToReachTarget;
    }

    private IEnumerator MoveToTargetPosition()
    {
        if (_worldPosition)
        {
            while (_timeElapsed < _timeToReachTarget)
            {
                transform.position = Vector3.MoveTowards(transform.position, _targetPosition, _averageSpeed * Time.deltaTime);
                _timeElapsed += 1 * Time.deltaTime;
                yield return null;
            }

            transform.position = _targetPosition;
            yield return null;
        }
        else
        {
            while (_timeElapsed < _timeToReachTarget)
            {
                transform.localPosition = Vector3.MoveTowards(transform.localPosition, _targetPosition, _averageSpeed * Time.deltaTime);
                _timeElapsed += 1 * Time.deltaTime;
                yield return null;
            }

            transform.localPosition = _targetPosition;
            yield return null;
        }

        if (_desactiveObject) this.gameObject.SetActive(true);
        yield return null;
    }

    public void MoveToTargetPositionMethod()
    {
        StartCoroutine(MoveToTargetPosition());
    }
}
