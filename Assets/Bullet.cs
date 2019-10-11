using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject otherObj;
    private int deathcount = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        transform.Translate(Vector2.up * Time.deltaTime * 4);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.collider.tag == "RWall")
        {

            Vector3 temp = transform.rotation.eulerAngles;
            print(temp[2]);
            print(Vector2.up);

            transform.Rotate(0, 0, -1 * (2 * (temp[2] - 180)));

            deathcount++;
        }
        if (collision.collider.tag == "LWall")
        {

            Vector3 temp = transform.rotation.eulerAngles;
            print(temp[2]);
            print(Vector2.up);

            transform.Rotate(0, 0, -1 * (2 * (temp[2]-180)));

            deathcount++;
        }
        if (collision.collider.tag == "UWall")
        {

            Vector3 temp = transform.rotation.eulerAngles;
            print(temp[2]);
            print(Vector2.up);
            
            transform.Rotate(0, 0, ((2 * (90-temp[2]))));
            

            deathcount++;
        }
        if (collision.collider.tag == "DWall")
        {

            Vector3 temp = transform.rotation.eulerAngles;
            print(temp[2]);
            print(Vector2.up);

            transform.Rotate(0, 0, (2*(270-temp[2])));
            print((0-(2*temp[2])));

            deathcount++;
        }
        if (deathcount == 4)
        {
            Destroy(gameObject);
                
        }
            
        
       
        


    }
}
