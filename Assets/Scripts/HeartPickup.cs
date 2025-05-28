using UnityEngine;

public class HeartPickup : MonoBehaviour
{
    public int healAmount = 1; // 1 = 1/4 heart

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerHealth playerHealth = collision.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.Heal(healAmount);
            }

            Destroy(gameObject); // Remove the heart
        }
    }
}
