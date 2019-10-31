﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigB : MonoBehaviour
{
  string health = (Mathf.PI).ToString();
  public GameObject shotty;
  public GameObject snip;
  public GameObject speed;
  private float timer;

  public void damage()
  {
    int length = health.Length - 1;
    health = health.Remove(length, length);


  }
  public int getCurrentEnd()
  {
    int length = health.Length - 1;
    char x = health[length];
    int y = x - '0';
    return y;


    

  }
  public void SchoolShooter()
  {
    print(health);
    int curint = getCurrentEnd();
    if((curint % 3) == 0)
    {
      GameObject bullet = Instantiate(speed, transform.position, transform.rotation);
      print("sp");
   
    }
    else if ((curint % 2) == 0)
    {
      GameObject bullet = Instantiate(shotty, transform.position, transform.rotation);
      print("sh");
    }
    else
    {
      GameObject bullet = Instantiate(snip, transform.position, transform.rotation);
      print("sn");


    }
    
  }
  // Start is called before the first frame update
  void Start()
    {
    health = health.Remove(1, 1);
    print(health);
    damage();
    print(health);
    damage();
    print(health);
    damage();
  }

    // Update is called once per frame
    void Update()
    {
    GameObject player;
    player = gameObject;
    GameObject[] lst = GameObject.FindGameObjectsWithTag("Player");
    
    foreach (GameObject it in lst)
    {
      if(it.tag == "Player")
      {
        player = it;
      }
      
    }
    float relmousey = player.transform.position.y;
    float relmousex = player.transform.position.x;
    float selfx = transform.position.x;
    float selfy = transform.position.y;
    float thetadeg = (Mathf.Atan((player.transform.position.y - transform.position.y) / (player.transform.position.x - transform.position.x)));
    thetadeg = thetadeg * 180 / Mathf.PI;

    
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
    transform.Translate(Vector2.up * Time.deltaTime * 1);
    if (timer > 50)
    {

      SchoolShooter();  
      timer = 0;

    }
    timer += 1;
    
  }
}