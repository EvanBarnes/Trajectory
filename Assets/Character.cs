using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour  
{
    public Object prefab;
    float lockPos;
    Vector2 up;
    Vector2 down;
    Vector2 left;
    Vector2 right;
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
            GameObject bullet = Instantiate(prefab, transform.position, transform.rotation) as GameObject;
            Physics2D.IgnoreCollision(bullet.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        }
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += new Vector3(0, .04f, 0);
            

        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position += new Vector3(0, -.04f, 0);
            
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += new Vector3(-.04f, 0, 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += new Vector3(.04f, 0, 0);
        }

    }
   void onCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "Enemy")
        {
            print("hit");
        }
    }
}
