using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Player;

public class CharactersSelectManager : MonoBehaviour
{
    [Header("Character Settings")]
    public GameObject[] skins;
    public Character[] characters;

    [Header("UI Elements")]
    public Button changeNext;
    public Button changePrev;
    public Button unlockButton;
    public TextMeshProUGUI coinsText;

    private int selectedCharacter;

    private void Awake()
    {
        InitializeSelectedCharacter();
        InitializeUI();
        AddButtonListeners();
    }

    private void InitializeSelectedCharacter()
    {
        selectedCharacter = PlayerPrefs.GetInt("SelectedCharacter", 0);
        foreach (GameObject player in skins)
            player.SetActive(false);
        ActivateCharacter(selectedCharacter);

        foreach (Character character in characters)
            character.isUnlocked = character.price == 0 || PlayerPrefs.GetInt(character.name, 0) == 1;
    }

    private void InitializeUI()
    {
        UpdateUI();
    }

    private void AddButtonListeners()
    {
        changeNext.onClick.AddListener(ChangeToNext);
        changePrev.onClick.AddListener(ChangeToPrevious);
        unlockButton.onClick.AddListener(UnlockCharacter);
    }

    private void ChangeToNext()
    {
        ChangeCharacter(1);
    }

    private void ChangeToPrevious()
    {
        ChangeCharacter(-1);
    }

    private void ChangeCharacter(int direction)
    {
        skins[selectedCharacter].SetActive(false);
        selectedCharacter = (selectedCharacter + direction + skins.Length) % skins.Length;
        ActivateCharacter(selectedCharacter);

        if (characters[selectedCharacter].isUnlocked)
            PlayerPrefs.SetInt("SelectedCharacter", selectedCharacter);

        UpdateUI();
    }

    private void ActivateCharacter(int index)
    {
        skins[index].SetActive(true);
    }

    private void UpdateUI()
    {
        int coins = PlayerPrefs.GetInt("NumberOfCoins", 0);
        coinsText.text = "Coins: " + coins;

        if (characters[selectedCharacter].isUnlocked)
            unlockButton.gameObject.SetActive(false);
        else
        {
            unlockButton.gameObject.SetActive(true);
            unlockButton.interactable = coins >= characters[selectedCharacter].price;
            unlockButton.GetComponentInChildren<TextMeshProUGUI>().text = "Price: " + characters[selectedCharacter].price;
        }
    }

    private void UnlockCharacter()
    {
        int coins = PlayerPrefs.GetInt("NumberOfCoins", 0);
        int price = characters[selectedCharacter].price;

        PlayerPrefs.SetInt("NumberOfCoins", coins - price);
        PlayerPrefs.SetInt(characters[selectedCharacter].name, 1);
        PlayerPrefs.SetInt("SelectedCharacter", selectedCharacter);

        characters[selectedCharacter].isUnlocked = true;

        UpdateUI();
    }
    public void ResetCharacterLock()
    {
        int resetIndex = 1;
        if (resetIndex >= 0 && resetIndex < characters.Length)
        {
            characters[resetIndex].isUnlocked = false;
            PlayerPrefs.SetInt(characters[resetIndex].name, 0);

            if (selectedCharacter == resetIndex)
            {
                selectedCharacter = 0;
                PlayerPrefs.SetInt("SelectedCharacter", selectedCharacter);
            }

            UpdateUI();
        }
    }
}
