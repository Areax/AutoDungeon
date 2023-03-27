using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScreen : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("CreateCharacter");
    }
    public void LoadGame()
    {
        SceneManager.LoadScene("LoadGame");
    }

    public void LoadSettings()
    {
        SceneManager.LoadScene("Settings");
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}