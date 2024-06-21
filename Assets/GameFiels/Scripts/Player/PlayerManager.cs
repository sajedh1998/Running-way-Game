using UnityEngine;
using Cinemachine;
using TMPro;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager instance;
    public TextMeshProUGUI coinsCounterText;
    public int coins = 0;
    int characterIndex;
    public Vector2 pointCheckPos = new(-3, 0);
    public GameObject player;
    public GameObject[] playerCharcters;

    public CinemachineVirtualCamera VCam;

    void Awake()
    {
        if (instance == null)
            instance = this;

        coins = PlayerPrefs.GetInt("NumberOfCoins", 0);
        characterIndex = PlayerPrefs.GetInt("SelectedCharacter", 0);
        player = Instantiate(playerCharcters[characterIndex], pointCheckPos, Quaternion.identity);
        VCam.m_Follow = player.transform;
    }

    private void Update()
    {
        coinsCounterText.text = "Coins: " + coins.ToString();
    }
}
