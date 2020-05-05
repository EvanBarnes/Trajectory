using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Character : MonoBehaviour  
{
    public Object prefab;
  public Object prefab1;
  public Object prefab2;
  public Object prefab3;

  float lockPos;
  public int health;
  public int cbc = 0;
    Vector2 up;
    Vector2 down;
    Vector2 left;
    Vector2 right;
  int nhealth = 3;
  int ttime = 0;
  public int rat = 0;
  bool cont = false;
    // Start is called before the first frame update
    void Start()
    {
    
  }

    // Update is called once per frame
    void Update()
    {
        
        rotate();
        
    }
  void rotate()
  {
    if (!cont)
    {
      int width = Screen.width;
      int height = Screen.height;
      float mousex = Input.mousePosition.x;
      float mousey = Input.mousePosition.y;

      float relmousex = ((width / 2 - Input.mousePosition.x));
      float relmousey = ((height / 2 - Input.mousePosition.y));
      float thetarad = (Mathf.Atan((relmousex / relmousey)));
      float thetadeg = (thetarad * (180 / Mathf.PI));
      float offset = 54f;

      if (relmousey > 0)
      {
        if (relmousex > 0)
        {
          //tbd quad 3
          lockPos = 180 - thetadeg;
          transform.rotation = Quaternion.Euler(new Vector3(0, 0, lockPos));
        }
        else
        {
          //quadrent 4
          lockPos = 180 - thetadeg;
          transform.rotation = Quaternion.Euler(new Vector3(0, 0, lockPos));
        }
      }
      else
      {
        if (relmousex > 0)
        {
          //quadrent 2
          lockPos = 0 - thetadeg;
          transform.rotation = Quaternion.Euler(new Vector3(0, 0, lockPos));
        }
        else
        {
          //quadrent 1
          lockPos = 0 - thetadeg;
          transform.rotation = Quaternion.Euler(new Vector3(0, 0, lockPos));
        }
      }
      if (Input.GetMouseButtonDown(0))
      {
        if (cbc < 3)
        {
          GameObject bullet = Instantiate(prefab, transform.position, transform.rotation) as GameObject;

          cbc += 1;
        }
      }

      if (Input.GetKey(KeyCode.W))
      {
        transform.position += new Vector3(0, .12f, 0);


      }
      if (Input.GetKey(KeyCode.S))
      {
        transform.position += new Vector3(0, -.12f, 0);

      }
      if (Input.GetKey(KeyCode.A))
      {
        transform.position += new Vector3(-.12f, 0, 0);
      }
      if (Input.GetKey(KeyCode.D))
      {
        transform.position += new Vector3(.12f, 0, 0);
      }
      if (Input.GetKey(KeyCode.R)&& rat == 0)
      {
        rat += 1;
      }else if (Input.GetKey(KeyCode.A) && rat == 1)
      {
        rat += 1;
      }else if (Input.GetKey(KeyCode.T) && rat == 2)
      {
        rat += 1;
        Sprite myFruit = Resources.Load("rat", typeof(Sprite)) as Sprite;
        transform.GetComponent<SpriteRenderer>().sprite = myFruit;
        transform.localScale += new Vector3(.9f, .9f, .9f);
      }
      
    }
    else
    {

      if (Input.GetAxis("Trigger1")>.9 && ttime<0)
      {

      
        if (cbc < 3)
        {
          GameObject bullet = Instantiate(prefab, transform.position, transform.rotation) as GameObject;
          ttime = 10;
          cbc += 1;
        }
      }
      transform.position += new Vector3(Input.GetAxis("Joy0X") * .12f, -Input.GetAxis("Joy0Y") * .12f, 0);
      int width = Screen.width;
      int height = Screen.height;
      float mousex = Input.mousePosition.x;
      float mousey = Input.mousePosition.y;

      float relmousex = ((Input.GetAxis("Joy1X")));
      float relmousey = ((Input.GetAxis("Joy1Y")));
      float thetarad = (-Mathf.Atan((relmousex / relmousey)));
      float thetadeg = (thetarad * (180 / Mathf.PI));
      float offset = 54f;
      if (relmousex != 0 && relmousey != 0)
      {
        print(thetadeg + 90);
        if (relmousey > 0)
        {
          if (relmousex > 0)
          {
            //tbd quad 3
            lockPos = 180 - thetadeg;
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, lockPos));
          }
          else
          {
            //quadrent 4
            lockPos = 180 - thetadeg;
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, lockPos));
          }
        }
        else
        {
          if (relmousex > 0)
          {
            //quadrent 2
            lockPos = 0 - thetadeg;
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, lockPos));
          }
          else
          {
            //quadrent 1
            lockPos = 0 - thetadeg;
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, lockPos));
          }
        }
        
      }
      ttime--;
    }
  }
  private void OnCollisionEnter2D(Collision2D collision)
  {
    if (collision.collider.tag == "Speed")
    {
      prefab = prefab1;
      Destroy(collision.collider.gameObject);
      Sprite myFruit = Resources.Load("Speed", typeof(Sprite)) as Sprite;
      transform.GetComponent<SpriteRenderer>().sprite = myFruit;
    }
    if (collision.collider.tag == "Shot")
    {
      prefab = prefab2;
      Destroy(collision.collider.gameObject);
      Sprite myFruit = Resources.Load("Shot", typeof(Sprite)) as Sprite;
      transform.GetComponent<SpriteRenderer>().sprite = myFruit;
    }
    if (collision.collider.tag == "Snip")
    {
      prefab = prefab3;
      Destroy(collision.collider.gameObject);
      Sprite myFruit = Resources.Load("Snip", typeof(Sprite)) as Sprite;
      transform.GetComponent<SpriteRenderer>().sprite = myFruit;
    }
    
    if (collision.collider.CompareTag("EBullet") || (collision.collider.CompareTag("Enemy") && collision.collider.name != "PI"))
    {
      nhealth -= 1;
      
      if (nhealth == 0)
      {
        SceneManager.LoadScene("Suck");

      }
      GameObject[] lst = GameObject.FindGameObjectsWithTag("Health");
      int numbChild = lst[0].transform.childCount;
      Destroy(collision.collider.gameObject);
      Destroy(lst[0].transform.GetChild(numbChild - 1).gameObject);
    }
  }
}
