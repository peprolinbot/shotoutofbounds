using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadGameplay : MonoBehaviour
{
  public string historyScene;
  public string gameplayScene;

  SceneLoader sceneLoader;

  void Start() {
    sceneLoader = GetComponent<SceneLoader>();
  }

  public void Load()
  {
    if (PlayerPrefs.GetInt("AlreadyPlayed", 0) == 1) { // 0 = False; 1 = True
      sceneLoader.LoadScene(gameplayScene);
    } else {
      sceneLoader.LoadScene(historyScene);
    }
  }
}
