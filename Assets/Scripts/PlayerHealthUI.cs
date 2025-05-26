using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class PlayerHealthUI : MonoBehaviour
{
    public Sprite heartEmpty;
    public Sprite heartQuarter;
    public Sprite heartHalf;
    public Sprite heartThreeQuarters;
    public Sprite heartFull;

    public GameObject heartPrefab; // Reference to the UI Image prefab
    public int maxHearts = 3; // Each heart = 4 health units (so 3 hearts = 12 HP)

    private List<Image> heartImages = new List<Image>();

    private void Start()
    {
        for (int i = 0; i < maxHearts; i++)
        {
            GameObject heartGO = Instantiate(heartPrefab, transform);
            Image heartImage = heartGO.GetComponent<Image>();
            heartImages.Add(heartImage);
        }

        UpdateHearts(currentHealth: 12); // Start full
    }

    public void UpdateHearts(int currentHealth)
    {
        for (int i = 0; i < heartImages.Count; i++)
        {
            int heartHealth = Mathf.Clamp(currentHealth - i * 4, 0, 4);
            heartImages[i].sprite = GetHeartSprite(heartHealth);
        }
    }

    private Sprite GetHeartSprite(int heartHealth)
    {
        return heartHealth switch
        {
            4 => heartFull,
            3 => heartThreeQuarters,
            2 => heartHalf,
            1 => heartQuarter,
            _ => heartEmpty,
        };
    }
}
