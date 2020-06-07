using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    // Configuration Parameters
    [SerializeField] float baseHealth = 4;
    float playerHealth;

    // Cached References
    Text healthText;

    void Start()
    {
        // Reduce player health based on the difficulty chosen
        playerHealth = baseHealth - PlayerPrefsController.GetDifficultyLevel();
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

    public float CurrentPlayerHealth()
    {
        return playerHealth;
    }
}
