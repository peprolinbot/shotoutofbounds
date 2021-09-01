using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public Animator transitionAnimator;
    public float transitionTime = 1f;

    public void LoadScene(string sceneName)
    {
      StartCoroutine(LoadSceneWithTransition(sceneName));
    }

    public void Quit()
    {
        Application.Quit();
    }

    IEnumerator LoadSceneWithTransition(string sceneName) {
      transitionAnimator.SetTrigger("Start");
      yield return new WaitForSeconds(transitionTime);
      SceneManager.LoadScene(sceneName);
    }
}
