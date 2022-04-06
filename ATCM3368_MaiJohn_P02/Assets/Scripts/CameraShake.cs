using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    [Header("Camera Shake Settings")]
    [SerializeField] float _duration = 1.5f;
    [SerializeField] float _magnitude = .4f;

    float _elapsed = 0.0f;

    public void StartShake()
    {
        StartCoroutine(Shake());
        Debug.Log("Shake camera.");
    }

    IEnumerator Shake()
    {
        Vector3 originalPosition = transform.localPosition;

        while (_elapsed < _duration)
        {
            float x = Random.Range(-1f, 1f) * _magnitude;
            float z = Random.Range(-1f, 1f) * _magnitude;

            transform.localPosition = new Vector3(x, .75f, z);

            _elapsed += Time.deltaTime;

            yield return null;
        }

        _elapsed = 0;
        transform.localPosition = originalPosition;
    }
}
