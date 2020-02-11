using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snip : Bullet
{
  // Start is called before the first frame update
  public bool e = false;
  string tager = "Enemy";
  public void Start()
  {
    if (e) { tager = "Player"; }
  }

  void home(GameObject[] lst)
  {
    GameObject player;
    float dist;

    lst = GameObject.FindGameObjectsWithTag(tager);


    player = lst[0];
    dist = Mathf.Sqrt((Mathf.Pow((transform.position.x - player.transform.position.x), 2)) + (Mathf.Pow((transform.position.y - player.transform.position.y), 2)));
    foreach(GameObject it in lst)
    {
      float t = Mathf.Sqrt((Mathf.Pow((transform.position.x - it.transform.position.x), 2)) + (Mathf.Pow((transform.position.y - it.transform.position.y), 2)));
      if(t > dist)
      {
        dist = t;
        player = it;
      }
    }
    float relmousey = player.transform.position.y;
    float relmousex = player.transform.position.x;
    float selfx = transform.position.x;
    float selfy = transform.position.y;
    float thetadeg = (Mathf.Atan((player.transform.position.y - transform.position.y) / (player.transform.position.x - transform.position.x)));
    thetadeg = thetadeg * 180 / Mathf.PI;

    float lockPos = 0;
    if (relmousey > selfy)
    {
      if (relmousex > selfx)
      {
        //tbd quad 3
        thetadeg = (Mathf.Atan((player.transform.position.y - transform.position.y) / (player.transform.position.x - transform.position.x)));
        thetadeg = thetadeg * 180 / Mathf.PI;

        transform.rotation = Quaternion.Euler(new Vector3(0, 0, thetadeg - 90));

      }
      else
      {
        //quadrent 4
        thetadeg = (Mathf.Atan((player.transform.position.y - transform.position.y) / (player.transform.position.x - transform.position.x)));
        thetadeg = thetadeg * 180 / Mathf.PI;

        transform.rotation = Quaternion.Euler(new Vector3(0, 0, thetadeg + 90));

      }
    }
    else
    {
      if (relmousex > selfx)
      {
        //quadrent 2
        thetadeg = (Mathf.Atan((player.transform.position.y - transform.position.y) / (player.transform.position.x - transform.position.x)));
        thetadeg = thetadeg * 180 / Mathf.PI;

        transform.rotation = Quaternion.Euler(new Vector3(0, 0, thetadeg - 90));

      }
      else
      {
        //quadrent 1
        thetadeg = (Mathf.Atan((player.transform.position.y - transform.position.y) / (player.transform.position.x - transform.position.x)));
        thetadeg = thetadeg * 180 / Mathf.PI;

        transform.rotation = Quaternion.Euler(new Vector3(0, 0, thetadeg + 90));

      }
    }
  }
  void OnCollisionEnter2D(Collision2D collision)
  {
    if (collision.collider.tag == "Enemy" && collision.collider.name != "PI")
    {
      if (damagable == true)
      {
        
        Destroy(collision.collider.gameObject);
      }
      menCBC();
    }
    else if (collision.collider.tag == "Bullet" || collision.collider.tag == "EBullet" || collision.collider.tag == "Snip" || collision.collider.tag == "Shot" || collision.collider.tag == "Speed")
    {
    }
    else { 
      GameObject[] lst = GameObject.FindGameObjectsWithTag(tager);
    if (lst.Length > 0)
    {

      home(lst);
      deathcount++;
    }
    else
    {
      collisioner(collision);
    }
      damagable = true;
     }
  }
}
