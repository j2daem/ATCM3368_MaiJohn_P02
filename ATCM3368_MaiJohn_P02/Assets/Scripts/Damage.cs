using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    [SerializeField] int DamageAmount = 1;
    [SerializeField] int ScoreDecrease = 5;

    [SerializeField] GameObject visualsToDeactivate;
    [SerializeField] Collider colliderToDeactivate;
    [SerializeField] ScoreController scoreController = null;

    private void Awake()
    {
        colliderToDeactivate = GetComponent<Collider>();

        EnableObject();
    }

    private void OnTriggerEnter(Collider other)
    {
        PlayerHealth playerHealth = other.gameObject.transform.GetComponent<PlayerHealth>();
        CameraShake cameraShake = other.gameObject.transform.GetComponentInChildren<CameraShake>();

        if (playerHealth != null)
        {
            playerHealth.DecreaseHealth(DamageAmount);
            scoreController.DecreaseScore(ScoreDecrease);

            cameraShake.StartShake();

            DisableObject();
        }
    }

    private void DisableObject()
    {
        colliderToDeactivate.enabled = false;
        visualsToDeactivate.SetActive(false);
    }

    private void EnableObject()
    {
        colliderToDeactivate.enabled = true;
        visualsToDeactivate.SetActive(true);
    }
}
