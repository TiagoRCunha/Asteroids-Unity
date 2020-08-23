using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
  float score;
  public float highscore { get; private set; }
  [SerializeField] GameObject deathScreen;
  [SerializeField] GameObject player;
  [SerializeField] AsteroidCreator asteroidCreator;

  bool died = false;
  public float getScore()
  {
    return score;
  }

  public void setScore(float value)
  {
    score = value;
    GameUi.self.UpdateScore();
    if (PlayerPrefs.GetFloat("Highscore", 0) < score)
    {
      PlayerPrefs.SetFloat("Highscore", score);
      highscore = score;
    }
  }
  public static GameManager self;
  // Start is called before the first frame update
  private void Awake()
  {
    if (self == null)
    {
      self = this;
    }
    else
    {
      Destroy(this);
    }
  }

  private void Start()
  {
    highscore = PlayerPrefs.GetFloat("Highscore", 0);
    GameUi.self.UpdateScore();
  }

  // Update is called once per frame
  void Update()
  {
    if (!died)
    {
      setScore(Time.timeSinceLevelLoad);
    }
  }

  public void Died()
  {
    died = true;
    deathScreen.SetActive(true);
    asteroidCreator.spawning = false;
    Destroy(player.gameObject);
  }

  public void CallNewScene(string newSceneName)
  {
    UnityEngine.SceneManagement.SceneManager.LoadScene(newSceneName);
  }

}
