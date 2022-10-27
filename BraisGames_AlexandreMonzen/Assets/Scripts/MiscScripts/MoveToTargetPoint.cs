using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToTargetPoint : MonoBehaviour
{
    [Header("General Setup")]
    [SerializeField] private bool _worldPosition;
    [SerializeField] private Vector3 _initalPosition;
    [SerializeField] private Vector3 _targetPosition;

    [Tooltip("Total Time that the object will reach the target, in seconds")]
    [SerializeField] private float _timeToReachTarget;

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
            transform.position = _initalPosition;
        }
        else
        {
            transform.localPosition = _initalPosition;
        }

        _timeElapsed = 0;
        _averageSpeed = CalculateAverageSpeed();
    }

    private float CalculateAverageSpeed()
    {
        return (Vector3.Distance(_targetPosition, _initalPosition)) / _timeToReachTarget;
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

        yield return null;
    }

    public void MoveToTargetPositionMethod()
    {
        StartCoroutine(MoveToTargetPosition());
    }
}
