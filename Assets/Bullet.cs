using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject otherObj;
    public int deathcount = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        transform.Translate(Vector2.up * Time.deltaTime * 4);
    }
    protected char collisioner(Collision2D collision)
    {
    char returner = 'N';
    if (collision.collider.tag == "RWall")
    {

      Vector3 temp = transform.rotation.eulerAngles;


      transform.Rotate(0, 0, -1 * (2 * (temp[2] - 180)));

      deathcount++;
      returner= 'R';
    }
    if (collision.collider.tag == "LWall")
    {

      Vector3 temp = transform.rotation.eulerAngles;


      transform.Rotate(0, 0, -1 * (2 * (temp[2] - 180)));

      deathcount++;
      returner = 'L';
    }
    if (collision.collider.tag == "UWall")
    {

      Vector3 temp = transform.rotation.eulerAngles;


      transform.Rotate(0, 0, ((2 * (90 - temp[2]))));


      deathcount++;
      returner = 'U';
    }
    if (collision.collider.tag == "DWall")
    {

      Vector3 temp = transform.rotation.eulerAngles;


      transform.Rotate(0, 0, (2 * (270 - temp[2])));


      deathcount++;
      returner = 'D';
    }
    if (deathcount == 4)
    {
      Destroy(gameObject);
      returner = 'X';

    }
    return returner;






  }
    void OnCollisionEnter2D(Collision2D collision)
    {
      collisioner(collision);
        
    }
}
