using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScreen : MonoBehaviour
{
    public void StartGame()
    {
        GlobalState.PLAYER_LOAD = false;
        SceneManager.LoadScene("StartGame");
    }
    public void LoadGame()
    {
        GlobalState.PLAYER_LOAD = true;
        SceneManager.LoadScene("StartGame");
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