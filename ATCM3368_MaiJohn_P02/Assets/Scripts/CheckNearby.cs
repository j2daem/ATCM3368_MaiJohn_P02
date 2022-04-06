using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckNearby : MonoBehaviour
{
    [SerializeField] Follow follow = null;

    [SerializeField] float distanceCheck = 10f;

    private void FixedUpdate()
    {
        Collider[] colliders = Physics.OverlapSphere(this.gameObject.transform.position, distanceCheck);

        foreach (Collider c in colliders)
        {
            if (c.GetComponent<PlayerMovement>())
            {
                follow.StartFollowing();
            }
        }
    }
}
