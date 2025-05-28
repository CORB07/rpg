using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 12;
    public int currentHealth = 12;
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
    public void Heal(int amount)
    {
        currentHealth += amount;
        currentHealth = Mathf.Min(currentHealth, maxHealth); // Cap at max

        if (healthUI != null)
        {
            healthUI.UpdateHearts(currentHealth);
        }
    }
}

