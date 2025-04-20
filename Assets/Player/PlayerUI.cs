using TMPro;
using UnityEngine;

public class PlayerUI : MonoBehaviour
{
    public GameObject player;
    private CharacterBase playerCharacter;

    public GameObject healthTextObject;
    public TextMeshProUGUI healthText;
    void Start()
    {
        playerCharacter = player.GetComponent<CharacterBase>();

        healthText = healthTextObject.GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        healthText.text = playerCharacter.currentHealth.ToString();
    }
}
