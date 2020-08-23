using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerUI : MonoBehaviour
{

  [HideInInspector]
  public float spawnDelayDecreaseSpeed;
  public static SceneManagerUI self;

  private void Awake()
  {
    DontDestroyOnLoad(gameObject);
    if (self == null)
    {
      self = this;
    }
    else
    {
      Destroy(self.gameObject);
    }
  }
  public void CallDifficuty(int level)
  {
    switch (level)
    {
      case 0:
        spawnDelayDecreaseSpeed = 0.005f;
        break;
      case 1:
        spawnDelayDecreaseSpeed = 0.01f;
        break;
      case 2:
        spawnDelayDecreaseSpeed = 0.15f;
        break;
    }

    SceneManager.LoadScene("LevelScene");
  }
}
