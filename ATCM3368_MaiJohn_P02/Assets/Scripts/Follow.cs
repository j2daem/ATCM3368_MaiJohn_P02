using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    [SerializeField] GameObject target = null;
    [SerializeField] float followSpeed = .05f;


    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, followSpeed * Time.deltaTime);

        transform.LookAt(target.transform);
    }
}
