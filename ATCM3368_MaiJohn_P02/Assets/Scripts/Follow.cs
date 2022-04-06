using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    [SerializeField] Transform target = null;
    [SerializeField] float followSpeed = .05f;
    [SerializeField] float distanceApart = 2f;

    private bool follow = false;

    void Update()
    {
        if (follow)
        {
            Following();
        }
    }

    public void StartFollowing()
    {
        follow = true;
    }

    private void Following()
    {
        Collider[] colliders = Physics.OverlapSphere(this.gameObject.transform.position, distanceApart);

        foreach (Collider c in colliders)
        {
            if (c.GetComponent<Follow>())
            {
                this.gameObject.transform.position = (this.gameObject.transform.position - c.gameObject.transform.position).normalized * distanceApart + c.gameObject.transform.position;
            }
        }

        transform.position = Vector3.MoveTowards(transform.position, target.position, followSpeed * Time.deltaTime);
        transform.LookAt(target.transform);
    }
}
