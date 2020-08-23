using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
  private void OnTriggerEnter2D(Collider2D collision)
  {
    if (collision.tag == "Asteroid")
    {
      Destroy(collision.gameObject);
      Destroy(gameObject);
    }
  }
}
