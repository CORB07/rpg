
using UnityEngine;

public class SwordHitbox : MonoBehaviour
{
    public int damage = 1;
    public float lifetime =  0.2f;
    void Start()
    {
        Destroy(gameObject, lifetime);
    }

    private void OnTriggerEnter2D(Collider2D other)
 

    {
        Debug.Log("Sword hit something: " + other.name);
        // Later: detect enemies and deal damage
        EnemyAI enemy = other.GetComponent<EnemyAI>();
        if (enemy != null)
        {
            Debug.Log("Hit an enemy! Dealing damage...");
            enemy.TakeDamage(1); // or whatever damage value you want
        }
    }
}
