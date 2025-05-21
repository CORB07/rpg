using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public GameObject swordPrefab;
    public float jabDistance = 0.75f;
    public Vector2 jabSize = new Vector2(0.5f, 0.5f);
    public KeyCode attackKey = KeyCode.J;
    public bool hasSword = false;

    private Vector2 lastFacing = Vector2.down; // Default facing direction

    private void Update()
    {
        TrackMovementDirection();

        if (hasSword && Input.GetKeyDown(attackKey))
        {
            Jab();
        }
    }

    void TrackMovementDirection()
    {
        Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        if (input != Vector2.zero)
        {
            // Prioritize cardinal directions if both are pressed
            if (Mathf.Abs(input.x) > Mathf.Abs(input.y))
                lastFacing = new Vector2(Mathf.Sign(input.x), 0);
            else
                lastFacing = new Vector2(0, Mathf.Sign(input.y));
        }
    }

    void Jab()
    {
        // Correctly spawn in the direction we're facing
        Vector3 spawnPosition = transform.position + (Vector3)(lastFacing * jabDistance);
        GameObject hitbox = Instantiate(swordPrefab, spawnPosition, Quaternion.identity);

        // Match size based on jab direction
        Vector3 scale = jabSize;
        if (lastFacing.x != 0)
        {
            scale.y = jabSize.x;
            scale.x = jabSize.y;
        }
        hitbox.transform.localScale = scale;

        // Fix angle offset for Unity's coordinate system (rotate 90 degrees)
        float angle = Mathf.Atan2(lastFacing.y, lastFacing.x) * Mathf.Rad2Deg;
        hitbox.transform.rotation = Quaternion.Euler(0, 0, angle - 90f); //  this is key
    }

}
