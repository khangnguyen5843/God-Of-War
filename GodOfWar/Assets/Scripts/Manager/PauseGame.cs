using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseGame : MonoBehaviour
{
    public AudioSource audio;
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUi;

    public void Resume()
    {
        pauseMenuUi.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    public void Pause()
    {
        pauseMenuUi.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public async  void Home()
    {
        var operation = SceneManager.LoadSceneAsync("TotalScence 1");
        while (operation != null && ! operation.isDone)
        {
            await Task.Delay(50);
        }
        InventoryManager.Instance.LoadItemStatus();
        Time.timeScale = 1f;
    }

    public void Volume()
    {

    }
}
