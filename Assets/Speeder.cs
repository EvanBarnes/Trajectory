using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speeder : Bullet
{
  // Start is called before the first frame update
    int speed = 4;
    // Update is called once per frame
    void Update()
    {
    transform.Translate(Vector2.up * Time.deltaTime * speed);

    }
  void OnCollisionEnter2D(Collision2D collision)
  {
    collisioner(collision);
    if (collisioner(collision) != 'X')
    {
      speed = speed * 2;
    }
  }
}
