using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy4 : MonoBehaviour
{
    public GameObject prefab;
  private GameObject player;
    private float timer;
  bool act = false;
  // Start is called before the first frame update
  void Start()
    {
    player = gameObject;
    GameObject[] lst = GameObject.FindGameObjectsWithTag("Player");

    foreach (GameObject it in lst)
    {
      if (it.tag == "Player")
      {
        player = it;
      }

    }
  }

  // Update is called once per frame
  void Update()
  {
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
    GameObject[] lst = GameObject.FindGameObjectsWithTag("Player");


    player = lst[0];

    float distance = Mathf.Sqrt(Mathf.Pow(Mathf.Abs(player.transform.position.x - transform.position.x), 2) + Mathf.Pow(Mathf.Abs(player.transform.position.y - transform.position.y), 2));
    if (distance <= 10) { act = true; }
    if (act)
    {
      transform.Translate(Vector2.up * Time.deltaTime * .75f);

      if (timer > 2)
      {
        GameObject bullet = Instantiate(prefab, transform.position, transform.rotation) as GameObject;

        Physics2D.IgnoreCollision(bullet.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        timer = 0;

      }
      timer += Time.deltaTime;
    }
  }
  public void damage()
  {

  }
}
