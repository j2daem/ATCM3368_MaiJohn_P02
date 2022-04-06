using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireWeapon : MonoBehaviour
{
    [SerializeField] Camera cameraController = null;
    [SerializeField] Transform rayOrigin = null;
    [SerializeField] ParticleSystem impact = null;
    [SerializeField] ParticleSystem impactStars = null;
    //[SerializeField] ParticleSystem impactSparkles = null;
    [SerializeField] TrailRenderer trail = null;

    [SerializeField] float shootDistance = 10;
    [SerializeField] bool addBulletSpread = true;
    [SerializeField] Vector3 bulletSpreadVariance = new Vector3(.1f, .1f, .1f);
    [SerializeField] float shootDelay = .5f;
    //[SerializeField] LayerMask mask;

    private float lastShootTime;

    RaycastHit objectHit;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Shoot();
        }
    }

    // Fire weapon using raycast
    private void Shoot()
    {   if (lastShootTime + shootDelay < Time.time)
        { 
            // Calculate direction to shoot ray
            Vector3 rayDirection = GetDirection();

            // Cast a debug ray
            Debug.DrawRay(rayOrigin.position, rayDirection * shootDistance, Color.red, 1f);

            // Shoot the raycast
            if (Physics.Raycast(rayOrigin.position, rayDirection, out objectHit, shootDistance))
            {
                //Originally placed to put the particle impact in front of the HeartAttack explosion particle effect
                //Vector3 direction = (this.gameObject.transform.position - objectHit.point).normalized;

                TrailRenderer trailInstance = Instantiate(trail, rayOrigin.position, Quaternion.identity);
                StartCoroutine(SpawnTrail(trailInstance, objectHit));

                lastShootTime = Time.time;

                HeartAttack heartAttack = objectHit.transform.gameObject.GetComponent<HeartAttack>();
                if (heartAttack != null)
                {
                    heartAttack.Explode();
                }

            
            }
        }
    }

    private Vector3 GetDirection()
    {
        Vector3 direction = cameraController.transform.forward;

        if (addBulletSpread)
        {
            direction += new Vector3(
                Random.Range(-bulletSpreadVariance.x, bulletSpreadVariance.x),
                Random.Range(-bulletSpreadVariance.y, bulletSpreadVariance.y),
                Random.Range(-bulletSpreadVariance.z, bulletSpreadVariance.z)
                );

            direction.Normalize();
        }

        return direction;
    }

    IEnumerator SpawnTrail(TrailRenderer _trail, RaycastHit _hit)
    {
        float time = 0;
        Vector3 startPosition = _trail.transform.position;

        while (time < 1)
        {
            _trail.transform.position = Vector3.Lerp(startPosition, _hit.point, time);
            // Really short duration
            time += Time.deltaTime / _trail.time;
            yield return null;
        }

        _trail.transform.position = _hit.point;
        Instantiate(impact, objectHit.point, Quaternion.LookRotation(_hit.normal));
        Instantiate(impactStars, objectHit.point, Quaternion.LookRotation(_hit.normal));
        //Instantiate(impactSparkles, objectHit.point, Quaternion.LookRotation(_hit.normal));

        //Destroy(_trail.gameObject, _trail.time);
    }
}
