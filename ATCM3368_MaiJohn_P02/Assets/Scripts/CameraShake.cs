using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    [SerializeField] float _duration = 1.5f;
    [SerializeField] float _magnitude = .4f;

    float _elapsed = 0.0f;

    public void StartShake()
    {
        StartCoroutine(Shake());
    }

    IEnumerator Shake()
    {

        Vector3 originalPosition = transform.position;

        while (_elapsed < _duration)
        {
            float x = Random.Range(-1f, 1f) * _magnitude;
            float z = Random.Range(-1f, 1f) * _magnitude;

            transform.position = new Vector3(originalPosition.x + x, originalPosition.y, originalPosition.z + z);

            _elapsed += Time.deltaTime;

            yield return null;
        }

        transform.position = originalPosition;
    }
}
