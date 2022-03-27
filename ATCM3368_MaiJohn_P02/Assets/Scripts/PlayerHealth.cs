using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    //[SerializeField] GameStateManager gameStateManager = null;
    [SerializeField] UIManager uIManager = null;

    [SerializeField] int StartingHealth = 5;
    [SerializeField] int MaximumHealth = 5;
    [SerializeField] int CurrentHealth; // Serialization just for visualization purposes; remove later

    void Awake()
    {
        CurrentHealth = StartingHealth;
        uIManager.SetHealthBarMin(0);
        uIManager.SetHealthBarMax(MaximumHealth);
    }

    private void Update()
    {
        if (CurrentHealth <= 0)
        {
            CurrentHealth = 0;
            uIManager.UpdateHealthBar();
            //gameStateManager.LoseGame();
            Debug.Log("Health reached zero...");
        }
    }

    public int GetCurrentHealth()
    {
        return CurrentHealth;
    }

    public void DecreaseHealth(int damageAmount)
    {
        if (CurrentHealth >= damageAmount)
        {
            CurrentHealth -= damageAmount;
            uIManager.UpdateHealthBar();
            Debug.Log("Health decreased to " + CurrentHealth.ToString());
        }
    }

    public void IncreaseHealth(int healAmount)
    {
        if ((CurrentHealth + healAmount) > MaximumHealth)
        {
            CurrentHealth = MaximumHealth;
            uIManager.UpdateHealthBar();
        }

        else
        {
            CurrentHealth += healAmount;
            uIManager.UpdateHealthBar();
        }

        Debug.Log("Health increased to " + CurrentHealth.ToString());
    }
}
