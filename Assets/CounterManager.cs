using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class CounterManager : MonoBehaviour {
    public TextMeshProUGUI CounterText;

    // Assign in Inspector: the +1 and –1 buttons
    public Button IncBtn;
    public Button DecBtn;

    private int count = 0;

    void Start() {
        // Initialize counter from PlayerPrefs (or 0 if none)
        if (PlayerPrefs.HasKey("Username")) count = PlayerPrefs.GetInt("CounterValue");
        UpdateUI();
    }

    public void Increment() {
        count += 1;
        PlayerPrefs.SetInt("CounterValue", count);
        PlayerPrefs.Save();

        UpdateUI();
    }

    public void Decrement() {
        count -= 1;
        PlayerPrefs.SetInt("CounterValue", count);
        PlayerPrefs.Save();

        UpdateUI();
    }

    void UpdateUI() {
        CounterText.text = "Current score = " + count.ToString();
        if (count >= 10) {
            SceneManager.LoadScene("CongratulationsScene");
        }
    }

    public void ExitGame() {
        // If running in the Unity Editor, stop play mode
        #if UNITY_EDITOR
        EditorApplication.isPlaying = false;
        #else
        // If in a built executable, quit the application
        Application.Quit();
        #endif
    }
}
