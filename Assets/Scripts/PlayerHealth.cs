using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int currentHealth = 3;
    public GameOverManager gameOverManager; // Assign in Inspector
    public PlayerHealthUI healthUI;
    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        healthUI.UpdateHearts(currentHealth);
        Debug.Log("Player took damage! Current health: " + currentHealth);

        if (currentHealth <= 0)
        {
            Debug.Log("Player died!");
            gameOverManager.TriggerGameOver();
            // You can expand this later (death, respawn, etc.)
        }
    }
}

