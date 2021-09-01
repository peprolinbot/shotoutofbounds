using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoBack : MonoBehaviour
{
  SceneLoader sceneLoader;

  void Start() {
    sceneLoader = GetComponent<SceneLoader>();
  }

  void Update()
  {
    if (Input.GetKeyDown(KeyCode.Escape))
    {
      if (SceneManager.GetActiveScene().buildIndex == 0)
      {
        Application.Quit();
      }
      else
      {
        sceneLoader.LoadScene("MainMenu");
      }
    }
  }
}
