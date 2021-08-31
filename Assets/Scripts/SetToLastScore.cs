using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetToLastScore : MonoBehaviour
{
  public string textBefore;
  public string textAfter;

  int lastScore;

  void Start()
  {
    lastScore = PlayerPrefs.GetInt("LastScore", 0);
    gameObject.GetComponent<Text>().text = textBefore + lastScore.ToString() + textAfter;
  }
}
