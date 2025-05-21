using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager instance;

    public GameObject dialogueBox;
    public TMP_Text dialogueText;

    private void Awake()
    {
        if (instance == null) instance = this;
    }

    public void ShowMessage(string message, float duration = 2f)
    {
        dialogueBox.SetActive(true);
        dialogueText.text = message;
        CancelInvoke(nameof(HideMessage));
        Invoke(nameof(HideMessage), duration);
    }

    void HideMessage()
    {
        dialogueBox.SetActive(false);
    }
}
