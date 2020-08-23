using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameUi : MonoBehaviour
{
  [SerializeField] Image[] hearts = default;
  [SerializeField] Text scoreText = default;
  [SerializeField] Text highscoreText = default;
  public static GameUi self;

  // Start before the object create
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

  public void UpdateLifes(int life)
  {
    switch (life)
    {
      case 3:
        hearts[0].color = new Color(1, 1, 1, 1);
        hearts[1].color = new Color(1, 1, 1, 1);
        hearts[2].color = new Color(1, 1, 1, 1);
        break;
      case 2:
        hearts[0].color = new Color(1, 1, 1, 0.2f);
        hearts[1].color = new Color(1, 1, 1, 1);
        hearts[2].color = new Color(1, 1, 1, 1);
        break;
      case 1:
        hearts[0].color = new Color(1, 1, 1, 0.2f);
        hearts[1].color = new Color(1, 1, 1, 0.2f);
        hearts[2].color = new Color(1, 1, 1, 1);
        break;
      case 0:
        hearts[0].color = new Color(1, 1, 1, 0.2f);
        hearts[1].color = new Color(1, 1, 1, 0.2f);
        hearts[2].color = new Color(1, 1, 1, 0.2f);
        break;
    }
  }

  public void UpdateScore()
  {
    scoreText.text = "Score: " + (int)GameManager.self.getScore();
    highscoreText.text = "Highscore: " + (int)GameManager.self.highscore;
  }
}
