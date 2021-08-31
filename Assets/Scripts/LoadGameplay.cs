using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadGameplay : MonoBehaviour
{
  public string historyScene;
  public string gameplayScene;

    public void Load()
    {
      if (PlayerPrefs.GetInt("AlreadyPlayed", 0) == 1) { // 0 = False; 1 = True
        SceneManager.LoadScene(gameplayScene);
      } else {
        SceneManager.LoadScene(historyScene);
      }
    }

    public void Quit()
    {
        Application.Quit();
    }
}
