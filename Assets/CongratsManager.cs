using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class CongratsManager : MonoBehaviour {
    public TextMeshProUGUI CongratsText;

    void Start() {
        string name = PlayerPrefs.GetString("Username", "Player");
        CongratsText.text = $"Congratulations, {name}! You reached 10!";
    }

    public void Reset() {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene("WelcomeScene");
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
