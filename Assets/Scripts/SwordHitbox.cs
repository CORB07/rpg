
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
        // Later: detect enemies and deal damage
        if (other.CompareTag("Enemy"))
        {
            Debug.Log("Hit Enemy for " + damage + " damage!");
            // other.GetComponent<Enemy>().TakeDamage(damage);
        }
    }
}
