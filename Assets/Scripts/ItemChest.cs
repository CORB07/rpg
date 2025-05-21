using UnityEngine;

public class ItemChest : MonoBehaviour
{
    public string itemName = "Sword";
    public Sprite openedChestSprite;
    public GameObject itemEffectPrefab; // optional sparkle/shine effect

    private bool opened = false;

    private void OnTriggerStay2D(Collider2D other)
    {
        if (!opened && other.CompareTag("Player") && Input.GetKeyDown(KeyCode.E))
        {
            OpenChest(other.gameObject);
        }
    }

    void OpenChest(GameObject player)
    {
        opened = true;

        // Change chest sprite
        if (openedChestSprite != null)
            GetComponent<SpriteRenderer>().sprite = openedChestSprite;

        // Grant the item (you can expand this)
        if (itemName.ToLower() == "sword")
        {
            PlayerAttack attack = player.GetComponent<PlayerAttack>();
            if (attack != null)
            {
                attack.hasSword = true;
            }
        }

        // Show popup dialogue
        if (DialogueManager.instance != null)
            DialogueManager.instance.ShowMessage($"You got the {itemName}!");

        // Play sparkle effect if assigned
        if (itemEffectPrefab != null)
            Instantiate(itemEffectPrefab, transform.position, Quaternion.identity);

        // Destroy chest after short delay
        Destroy(gameObject, 0.5f);
    }
}
