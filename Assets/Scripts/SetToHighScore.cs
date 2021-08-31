using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetToHighScore : MonoBehaviour
{
    public string textBefore;
    public string textAfter;

    int highScore;

    void Start()
    {
      highScore = PlayerPrefs.GetInt("HighScore", 0);
      gameObject.GetComponent<Text>().text = textBefore + highScore.ToString() + textAfter;
    }
}
