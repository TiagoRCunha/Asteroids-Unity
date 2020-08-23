using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleMove : MonoBehaviour
{
  [SerializeField] float speed = default;
  [SerializeField] float ylimit = default;
  [SerializeField] bool deleteOnLimit = default;
  [SerializeField] bool isMissile = default;
  // Start is called before the first frame update
  void Start()
  {

  }

  // Update is called once per frame
  void Update()
  {
    // transform.position += new Vector3 (0, transform.position.y + speed * Time.deltaTime, 0);
    // or
    transform.Translate(new Vector3(0, speed * Time.deltaTime, 0), Space.World);

    if (transform.position.y < -ylimit)
    {
      if (deleteOnLimit)
      {
        Destroy(gameObject);
      }
      else
      {
        transform.position = new Vector3(transform.position.x, ylimit, transform.position.z);
        transform.rotation = Quaternion.Euler(0, 0, Random.Range(0f, 360f));

      }
    }
    if (transform.position.y > ylimit && isMissile)
    {
      if (deleteOnLimit)
      {
        Destroy(gameObject);
      }
      else
      {
        transform.position = new Vector3(transform.position.x, -ylimit, transform.position.z);
        transform.rotation = Quaternion.Euler(0, 0, Random.Range(0f, 360f));

      }
    }
  }
}