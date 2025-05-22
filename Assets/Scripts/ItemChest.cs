using UnityEngine;

public class ItemChest : MonoBehaviour
{
    public string itemName = "Sword";
    public Sprite openedChestSprite;
    public GameObject itemEffectPrefab;

    private bool opened = false;
    private bool playerInRange = false;
    private GameObject player;

    void Update()
    {
        // Only allow interaction if player is nearby and hasn't opened chest yet
        if (playerInRange && !opened && Input.GetKeyDown(KeyCode.E))
        {
            OpenChest(player);
        }
    }

    void OpenChest(GameObject playerObj)
    {
        opened = true;

        // Change chest sprite to open
        if (openedChestSprite != null)
            GetComponent<SpriteRenderer>().sprite = openedChestSprite;

        // Give the item (in this case: sword)
        if (itemName.ToLower() == "lightsaber")
        {
            PlayerAttack attack = playerObj.GetComponent<PlayerAttack>();
            if (attack != null)
                attack.hasSword = true;
        }

        // Show dialogue popup
        if (DialogueManager.instance != null)
            DialogueManager.instance.ShowMessage($"You got the {itemName}!");

        // Optional effect
        if (itemEffectPrefab != null)
            Instantiate(itemEffectPrefab, transform.position, Quaternion.identity);

        // Destroy chest shortly after opening
        Destroy(gameObject, 0.5f);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
            player = other.gameObject;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            player = null;
        }
    }
}
