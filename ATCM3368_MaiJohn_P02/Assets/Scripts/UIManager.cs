using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] PlayerHealth playerHealth;
    [SerializeField] Slider playerHealthBar;

    public void UpdateHealthBar()
    {
        playerHealthBar.value = playerHealth.GetCurrentHealth();
    }

    public void SetHealthBarMin(int min)
    {
        playerHealthBar.minValue = min;
    }

    public void SetHealthBarMax(int max)
    {
        playerHealthBar.maxValue = max;
    }
}
