﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snip : Bullet
{
    // Start is called before the first frame update
    
  void home()
  {
    GameObject player;
    float dist;
    GameObject[] lst = GameObject.FindGameObjectsWithTag("Enemy");
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
    home();

  }
}