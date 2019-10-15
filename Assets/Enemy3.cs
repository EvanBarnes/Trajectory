using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy3 : MonoBehaviour
{
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
          
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
    transform.Translate(Vector2.up * Time.deltaTime * 1);
  }
}
