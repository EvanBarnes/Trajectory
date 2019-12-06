using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Bullet : MonoBehaviour
{
    public GameObject otherObj;
    public int deathcount = 0;
  public bool damagable = false;
  

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        transform.Translate(Vector2.up * Time.deltaTime * 4);
    }
  void rightCol()
  {
    Vector3 temp = transform.rotation.eulerAngles;


    transform.Rotate(0, 0, -1 * (2 * (temp[2] - 180)));
  }
  void leftCol()
  {
    Vector3 temp = transform.rotation.eulerAngles;


    transform.Rotate(0, 0, -1 * (2 * (temp[2] - 180)));
  }
  void upCol()
  {
    Vector3 temp = transform.rotation.eulerAngles;


    transform.Rotate(0, 0, ((2 * (90 - temp[2]))));
  }
  void downCol()
  {
    Vector3 temp = transform.rotation.eulerAngles;


    transform.Rotate(0, 0, (2 * (270 - temp[2])));
  }
    protected char collisioner(Collision2D collision)
    {
    ContactPoint2D colpoints = collision.GetContact(0);
    Tilemap tm = collision.collider.transform.GetComponent<Tilemap>();
    Grid gd = tm.layoutGrid;
    
    TileBase t = tm.GetTile(gd.WorldToCell(colpoints.point));
    Vector3Int t1 = gd.WorldToCell(transform.position);
    Vector3Int t2 =gd.WorldToCell(colpoints.point);
    char returner = 'N';
    if (collision.collider.tag == "RWall")
    {


      rightCol();
      deathcount++;
      damagable = true;
      returner= 'R';
    }
    if (collision.collider.tag == "LWall")
    {

      leftCol();

      deathcount++;
      damagable = true;
      returner = 'L';
    }
    if (collision.collider.tag == "UWall")
    {



      upCol();
      deathcount++;
      damagable = true;
      returner = 'U';
    }
    if (collision.collider.tag == "DWall")
    {



      downCol();
      deathcount++;
      damagable = true;
      returner = 'D';
    }
    if(collision.collider.tag == "URWall")
    {
      
      if((t1.y < t2.y))
      {
        upCol();
        deathcount++;
        damagable = true;
        
      }
      else 
      {
        rightCol();
        deathcount++;
        damagable = true;
      }
      
    }
    if (collision.collider.tag == "ULWall")
    {

      if ((t1.y < t2.y))
      {
        upCol();
        deathcount++;
        damagable = true;
      }
      else
      {
        rightCol();
        deathcount++;
        damagable = true;
      }

    }
    if (collision.collider.tag == "DLWall")
    {

      if ((t1.y > t2.y))
      {
        upCol();
        deathcount++;
        damagable = true;
      }
      else
      {
        rightCol();
        deathcount++;
        damagable = true;
      }

    }
    if (collision.collider.tag == "DRWall")
    {

      if ((t1.y > t2.y))
      {
        upCol();
        deathcount++;
        damagable = true;
      }
      else
      {
        rightCol();
        deathcount++;
        damagable = true;
      }

    }
    if (deathcount == 4)
    {
      menCBC();
      returner = 'X';

    }
    return returner;






  }
    public void menCBC()
  {
    Destroy(gameObject);
    GameObject[] lst = GameObject.FindGameObjectsWithTag("Player");
    lst[0].transform.GetComponent<Character>().cbc -= 1;
  }
    void OnCollisionEnter2D(Collision2D collision)
    {
      collisioner(collision);
      
    }
}
