using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] GameStateManager gameStateManager = null;
    [SerializeField] UIManager uIManager = null;

    [SerializeField] int maximumHealth = 5;
    [SerializeField] int currentHealth; //Serialization ust for visualization purposes; remove later

    void Start()
    {
        currentHealth = maximumHealth;
        uIManager.SetHealthBarMin(0);
        uIManager.SetHealthBarMax(maximumHealth);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            DecreaseHealth(1);
        }
    }

    public int GetCurrentHealth()
    {
        return currentHealth;
    }

    public void DecreaseHealth(int damageAmount)
    {
        if (currentHealth >= damageAmount)
        {
            currentHealth -= damageAmount;
            uIManager.UpdateHealthBar();
            Debug.Log("Health decreased to " + currentHealth.ToString());
        }

        else
        {
            currentHealth = 0;
            uIManager.UpdateHealthBar();
            gameStateManager.LoseGame();
            Debug.Log("Health reached zero...");
        }
    }

    public void IncreaseHealth(int healAmount)
    {
        if ((currentHealth + healAmount) > maximumHealth)
        {
            currentHealth = maximumHealth;
            uIManager.UpdateHealthBar();
        }

        else
        {
            currentHealth += healAmount;
            uIManager.UpdateHealthBar();
        }

        Debug.Log("Health increased to " + currentHealth.ToString());
    }
}
