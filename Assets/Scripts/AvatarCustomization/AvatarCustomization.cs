using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AvatarCustomization : MonoBehaviour
{
    [SerializeField] private ColorSync colorSync;
    [SerializeField] private Slider rSlider, gSlider, bSlider;
    [SerializeField] private TMP_InputField nameInputField;

    private void Start()
    {
        
        string playerName = PlayerPrefs.GetString("PlayerName", "Player");
        nameInputField.text = playerName;

        
        rSlider.onValueChanged.AddListener(UpdateColor);
        gSlider.onValueChanged.AddListener(UpdateColor);
        bSlider.onValueChanged.AddListener(UpdateColor);

        
        rSlider.value = PlayerPrefs.GetFloat("PlayerColorR", 1);
        gSlider.value = PlayerPrefs.GetFloat("PlayerColorG", 1);
        bSlider.value = PlayerPrefs.GetFloat("PlayerColorB", 1);

        UpdateColor(0); 
    }

    private void UpdateColor(float value)
    {
        Color newColor = new Color(rSlider.value, gSlider.value, bSlider.value);
        colorSync.SetColor(newColor);
    }

    public void SaveCustomization()
    {
        // Save customization to PlayerPrefs
        PlayerPrefs.SetFloat("PlayerColorR", rSlider.value);
        PlayerPrefs.SetFloat("PlayerColorG", gSlider.value);
        PlayerPrefs.SetFloat("PlayerColorB", bSlider.value);
    }

    public void LoadNextScene(string sceneName)
    {
        SaveCustomization();
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
    }
}
