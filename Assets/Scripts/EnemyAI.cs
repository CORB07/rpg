using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class EnemyAI : MonoBehaviour

{
    public float flipInterval = 0.3f; // Time between flips

    private SpriteRenderer spriteRenderer;
    private float flipTimer;


    public float moveSpeed = 1.5f;
    public int maxHealth = 3;
    public int damage = 1;
    public float detectionRange = 4f; // In tile units

    private float currentHealth;
    private Rigidbody2D rb;
    private Transform player;
    private Vector2 wanderDirection;
    private float wanderTimer = 0f;
    private float wanderInterval = 2f;

    public GameObject heartPickupPrefab;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        flipTimer = flipInterval;

        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        currentHealth = maxHealth;
        PickNewDirection();
    }

    void Update()
    {
        flipTimer -= Time.deltaTime;
        if (flipTimer <= 0f)
        {
            spriteRenderer.flipX = !spriteRenderer.flipX;
            flipTimer = flipInterval;
        }



        float distToPlayer = Vector2.Distance(transform.position, player.position);

        if (distToPlayer < detectionRange)
        {
            // Chase player
            Vector2 direction = (player.position - transform.position).normalized;
            rb.velocity = direction * moveSpeed;
        }
        else
        {
            // Wander
            wanderTimer -= Time.deltaTime;
            if (wanderTimer <= 0)
            {
                PickNewDirection();
            }
            rb.velocity = wanderDirection * moveSpeed;
        }
    }

    void PickNewDirection()
    {
        float angle = Random.Range(0f, 2f * Mathf.PI);
        wanderDirection = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
        wanderTimer = wanderInterval;
    }

    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        Debug.Log($"{gameObject.name} took {amount} damage. Current health: {currentHealth}");

        if (currentHealth <= 0)
        {
            Debug.Log("Health is zero or less. Calling Die().");
            Die();
        }
    }

    void Die()
    {
        Debug.Log(gameObject.name + " died!");
        Destroy(gameObject); // Removes the enemy from the scene

        // Drop a heart
        if (heartPickupPrefab != null)
        {
            Instantiate(heartPickupPrefab, transform.position, Quaternion.identity);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            PlayerHealth playerHealth = collision.collider.GetComponent<PlayerHealth>();
            if (playerHealth != null)
                playerHealth.TakeDamage(damage);
        }
    }
}
