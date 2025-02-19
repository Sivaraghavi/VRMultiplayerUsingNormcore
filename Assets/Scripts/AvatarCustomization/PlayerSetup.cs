using UnityEngine;
using Normal.Realtime;
using Name;

public class PlayerSetup : MonoBehaviour
{
    private void Start()
    {
        string playerName = PlayerPrefs.GetString("PlayerName", "Player");
        float colorR = PlayerPrefs.GetFloat("PlayerColorR", 1);
        float colorG = PlayerPrefs.GetFloat("PlayerColorG", 1);
        float colorB = PlayerPrefs.GetFloat("PlayerColorB", 1);

        // Apply player name and color
        GetComponentInChildren<NameSync>().SetText(playerName);
        GetComponentInChildren<ColorSync>().SetColor(new Color(colorR, colorG, colorB));
    }
}
