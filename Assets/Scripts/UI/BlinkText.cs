using TMPro;
using UnityEngine;

public class BlinkText : MonoBehaviour
{
    public TextMeshProUGUI text;
    public float blinkrate = 0.5f;
    void Start()
    {
        InvokeRepeating("ToggleText", blinkrate, blinkrate);
    }

    // Update is called once per frame
    void ToggleText()
    {
        text.enabled = !text.enabled;
    }
}
