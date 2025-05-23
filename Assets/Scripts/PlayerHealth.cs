using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float health = 3;
    public GameOverManager gameOverManager; // Assign in Inspector
    public void TakeDamage(float amount)
    {
        health -= amount;
        Debug.Log("Player took damage! Current health: " + health);

        if (health <= 0)
        {
            Debug.Log("Player died!");
            gameOverManager.TriggerGameOver();
            // You can expand this later (death, respawn, etc.)
        }
    }
}
