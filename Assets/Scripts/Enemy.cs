using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public AudioSource gotHitAudioSource;
    public AudioSource diedAudioSource;
    public float timeToKill;

    bool alreadyKilled = false;
    Text scoreText;
    int score;
    SceneLoader sceneLoader;

    void Start() {
      sceneLoader = FindObjectOfType<SceneLoader>();
      scoreText = GameObject.Find("Canvas/Text Score").GetComponent<Text>();
      StartCoroutine(GameOverCountdown());
    }

    void OnTriggerEnter(Collider collider) {
      gotHitAudioSource.Play();
    }

    void OnTriggerStay(Collider collider) {
      if (Input.GetMouseButton(0) && !alreadyKilled && Movement.bulletsLeft > 0) {
        alreadyKilled = true;
        int.TryParse(scoreText.text, out score);
        score+=1;
        scoreText.text = score.ToString();
        diedAudioSource.Play();
        StartCoroutine(SelfDestroyAfterSound());
      }
    }

    IEnumerator GameOverCountdown()
    {
        yield return new WaitForSeconds(timeToKill);
        int.TryParse(scoreText.text, out score);
        PlayerPrefs.SetInt("LastScore", score);
        if (score > PlayerPrefs.GetInt("HighScore")) {
          PlayerPrefs.SetInt("HighScore", score);
        }
        sceneLoader.LoadScene("GameOver");

    }


    IEnumerator SelfDestroyAfterSound()
     {
         while (diedAudioSource.isPlaying)
         {
             yield return null;
         }

         Destroy(gameObject);
     }
}
