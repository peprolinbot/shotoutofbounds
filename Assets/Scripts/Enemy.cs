using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    public AudioSource gotHitAudioSource;
    public AudioSource diedAudioSource;
    public float timeToKill;

    void Start() {
      StartCoroutine(GameOverCountdown());
    }

    void OnTriggerEnter(Collider collider) {
      gotHitAudioSource.Play();
    }

    void OnTriggerStay(Collider collider) {
      if (Input.GetMouseButton(0)) {
        diedAudioSource.Play();
        StartCoroutine(SelfDestroyAfterSound());
      }
    }

    IEnumerator GameOverCountdown()
    {
        yield return new WaitForSeconds(timeToKill);
        SceneManager.LoadScene("GameOver");

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
