using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
  [SerializeField] int Life = 3;
  [SerializeField] float speed = default;
  [SerializeField] Vector2 screenLimit = default;
  [SerializeField] float invulnerableTime = default;
  [SerializeField] GameObject missile = default;
  [SerializeField] Transform missleLauncher = default;
  bool invulnerable = false;
  float targetAlpha = 1;
  SpriteRenderer sprtRend;
  // Start is called before the first frame update
  void Start()
  {
    sprtRend = GetComponent<SpriteRenderer>();
  }

  // Update is called once per frame
  void Update()
  {
    Movement();

    float diff = targetAlpha - sprtRend.color.a;
    sprtRend.color = new Color(sprtRend.color.r, sprtRend.color.g, sprtRend.color.b, sprtRend.color.a + diff * Time.deltaTime);
    if (Input.GetKeyDown(KeyCode.Space))
    {
      Instantiate(missile, missleLauncher.position, Quaternion.identity);
    }
  }

  private void OnTriggerEnter2D(Collider2D collision)
  {
    if (collision.tag == "Asteroid")
    {
      if (!invulnerable)
      {
        Life--;
        if (Life < 0)
        {
          GameManager.self.Died();
        }
        GameUi.self.UpdateLifes(Life);
        Destroy(collision.gameObject);
        StartCoroutine(Invulnerable());
      }
    }
  }
  IEnumerator Invulnerable()
  {
    targetAlpha = 0.2f;
    invulnerable = true;
    yield return new WaitForSeconds(invulnerableTime);
    invulnerable = false;
    targetAlpha = 1;
  }
  void Movement()
  {
    if (Input.GetKey(KeyCode.A))
    {
      transform.Translate(new Vector3(-speed * Time.deltaTime, 0, 0), Space.World);
    }
    if (Input.GetKey(KeyCode.D))
    {
      transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0), Space.World);
    }
    if (Input.GetKey(KeyCode.W))
    {
      transform.Translate(new Vector3(0, speed * Time.deltaTime, 0), Space.World);
    }
    if (Input.GetKey(KeyCode.S))
    {
      transform.Translate(new Vector3(0, -speed * Time.deltaTime, 0), Space.World);
    }
    if (transform.position.x > screenLimit.x)
    {
      transform.position = new Vector3(screenLimit.x, transform.position.y, transform.position.z);
    }
    if (transform.position.x < -screenLimit.x)
    {
      transform.position = new Vector3(-screenLimit.x, transform.position.y, transform.position.z);
    }
    if (transform.position.y > screenLimit.y)
    {
      transform.position = new Vector3(transform.position.x, screenLimit.y, transform.position.z);
    }
    if (transform.position.y < -screenLimit.y)
    {
      transform.position = new Vector3(transform.position.x, -screenLimit.y, transform.position.z);
    }
  }

}