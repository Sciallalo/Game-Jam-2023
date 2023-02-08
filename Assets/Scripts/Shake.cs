using System;
using UnityEngine;
using System.Collections;
using Random = UnityEngine.Random;

public class Shake : MonoBehaviour
{
    [Header("Info")]
    private Vector3 _startPos;
    private float _timer;
    private Vector3 _randomPos;
    private Transform cam;
 
    [Header("Settings")]
    [Range(0f, 2f)]
    public float _time = 0.2f;
    [Range(0f, 2f)]
    public float _distance = 0.1f;
    [Range(0f, 0.1f)]
    public float _delayBetweenShakes = 0f;

    private void Awake()
    {
        cam = FindObjectOfType<Camera>().gameObject.transform;
        _startPos = cam.localPosition;
    }
 
    private void OnValidate()
    {
        if (_delayBetweenShakes > _time)
            _delayBetweenShakes = _time;
    }
    
    private void OnEnable()
    {
        StopAllCoroutines();
        StartCoroutine(StartShake());
    }

    private IEnumerator StartShake()
    {
        _timer = 0f;
 
        while (_timer < _time)
        {
            _timer += Time.deltaTime;
 
            _randomPos = _startPos + (Random.insideUnitSphere * _distance * (1-_timer/_time));
 
            cam.localPosition = _randomPos;
 
            if (_delayBetweenShakes > 0f)
            {
                yield return new WaitForSeconds(_delayBetweenShakes);
            }
            else
            {
                yield return null;
            }
        }
 
        cam.localPosition = _startPos;
        enabled = false;
    }
 
}