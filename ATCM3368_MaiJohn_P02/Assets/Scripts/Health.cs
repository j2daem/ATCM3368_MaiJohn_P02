using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] int StartingHealth = 5;
    [SerializeField] int MinimumHealth = 0;
    [SerializeField] int MaximumHealth = 5;
    [SerializeField] int CurrentHealth;

    void Awake()
    {
        CurrentHealth = StartingHealth;
    }

    private void Update()
    {
        if (CurrentHealth <= 0)
        {
            CurrentHealth = 0;
            Debug.Log("Health reached zero...");
        }
    }

    public int GetCurrentHealth()
    {
        return CurrentHealth;
    }

    public void DecreaseHealth(int damageAmount)
    {
        CurrentHealth -= damageAmount;

        if (CurrentHealth <= MinimumHealth)
        {
            Debug.Log("Health reached" + MinimumHealth + "... You lose.");
        }

        else
        {
            Debug.Log("Health decreased to " + CurrentHealth.ToString());
        }
    }

    public void IncreaseHealth(int healAmount)
    {
        CurrentHealth += healAmount;

        if (CurrentHealth > MaximumHealth)
        {
            CurrentHealth = MaximumHealth;
        }

        Debug.Log("Health increased to " + CurrentHealth.ToString());
    }
}
