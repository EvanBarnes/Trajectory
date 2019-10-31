using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shotty : Bullet
{
  public GameObject prefab;
  // Start is called before the first frame update

  // Update is called once per frame
  void OnCollisionEnter2D(Collision2D collision)
  {
    char col = collisioner(collision);
    if(col == 'U')
    {
      GameObject bullet = Instantiate(prefab, transform.position, transform.rotation) as GameObject;
      bullet.transform.Rotate(0, 0, transform.rotation.z+45);
      bullet.transform.GetComponent<shotty>().deathcount = 3;
      Physics2D.IgnoreCollision(bullet.GetComponent<Collider2D>(), GetComponent<Collider2D>());
      GameObject bullet2 = Instantiate(prefab, transform.position, transform.rotation) as GameObject;
      bullet2.transform.Rotate(0, 0, transform.rotation.z - 45);
      Physics2D.IgnoreCollision(bullet2.GetComponent<Collider2D>(), GetComponent<Collider2D>());
      Physics2D.IgnoreCollision(bullet2.GetComponent<Collider2D>(), bullet.GetComponent<Collider2D>());
    }
    if (col == 'D')
    {
      GameObject bullet = Instantiate(prefab, transform.position, transform.rotation) as GameObject;
      bullet.transform.Rotate(0, 0, transform.rotation.z + 45);
      bullet.transform.GetComponent<shotty>().deathcount = 3;
      Physics2D.IgnoreCollision(bullet.GetComponent<Collider2D>(), GetComponent<Collider2D>());
      GameObject bullet2 = Instantiate(prefab, transform.position, transform.rotation) as GameObject;
      bullet2.transform.Rotate(0, 0, transform.rotation.z - 45);
      Physics2D.IgnoreCollision(bullet2.GetComponent<Collider2D>(), GetComponent<Collider2D>());
      Physics2D.IgnoreCollision(bullet2.GetComponent<Collider2D>(), bullet.GetComponent<Collider2D>());
    }
    if (col == 'R')
    {
      GameObject bullet = Instantiate(prefab, transform.position, transform.rotation) as GameObject;
      bullet.transform.Rotate(0, 0, transform.rotation.z + 45);
      bullet.transform.GetComponent<shotty>().deathcount = 3;
      Physics2D.IgnoreCollision(bullet.GetComponent<Collider2D>(), GetComponent<Collider2D>());
      GameObject bullet2 = Instantiate(prefab, transform.position, transform.rotation) as GameObject;
      bullet2.transform.Rotate(0, 0, transform.rotation.z - 45);
      Physics2D.IgnoreCollision(bullet2.GetComponent<Collider2D>(), GetComponent<Collider2D>());
      Physics2D.IgnoreCollision(bullet2.GetComponent<Collider2D>(), bullet.GetComponent<Collider2D>());
    }
    if (col == 'L')
    {
      GameObject bullet = Instantiate(prefab, transform.position, transform.rotation) as GameObject;
      bullet.transform.Rotate(0, 0, transform.rotation.z + 45);
      bullet.transform.GetComponent<shotty>().deathcount = 3;
      Physics2D.IgnoreCollision(bullet.GetComponent<Collider2D>(), GetComponent<Collider2D>());
      GameObject bullet2 = Instantiate(prefab, transform.position, transform.rotation) as GameObject;
      bullet2.transform.Rotate(0, 0, transform.rotation.z - 45);
      Physics2D.IgnoreCollision(bullet2.GetComponent<Collider2D>(), GetComponent<Collider2D>());
      Physics2D.IgnoreCollision(bullet2.GetComponent<Collider2D>(), bullet.GetComponent<Collider2D>());
    }
  }
}
