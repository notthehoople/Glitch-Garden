using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    // Configuration Parameters
    [SerializeField] int playerHealth = 100;

    // Cached References
    Text healthText;

    void Start()
    {
        healthText = GetComponent<Text>();
        UpdateDisplay();
    }

    private void UpdateDisplay()
    {
        healthText.text = playerHealth.ToString();
    }

    public void LoseHealth(int damage)
    {
        playerHealth -= damage;
        UpdateDisplay();

        if (playerHealth <= 0)
        {
            FindObjectOfType<LevelController>().HandleLoseCondition();
        }
    }

    public int CurrentPlayerHealth()
    {
        return playerHealth;
    }
}
