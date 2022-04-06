using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartAttack : MonoBehaviour
{
    [SerializeField] ParticleSystem heartExplosion = null;

    public void Explode()
    {
        Instantiate(heartExplosion, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
