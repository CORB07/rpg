using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int health = 3;

    public void TakeDamage(int amount)
    {
        health -= amount;
        Debug.Log("Player took damage! Current health: " + health);

        if (health <= 0)
        {
            Debug.Log("Player died!");
            // You can expand this later (death, respawn, etc.)
        }
    }
}
