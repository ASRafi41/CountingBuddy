using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class WelcomeManager : MonoBehaviour {
    public TextMeshProUGUI output;
    public TMP_InputField userName;

    void Start() {
        // If a name is already saved, skip to Counter
        if (PlayerPrefs.HasKey("Username"))
            SceneManager.LoadScene("CounterScene");

        output.text = ""; // hide error
    }

    public void ContinueButton() {
        // output.text = userName.text;
        string name = userName.text.Trim();

        if (string.IsNullOrEmpty(name)) {
            output.text = "Name cannot be empty!";
            return;
        }
        output.text = "";

        // Save and proceed
        PlayerPrefs.SetString("Username", name);
        PlayerPrefs.Save();

        SceneManager.LoadScene("CounterScene");
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
