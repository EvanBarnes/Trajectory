using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy3 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float rotation = Quaternion.LookRotation(other.position - transform.rotation);
        transfrom.rotation = Quaternion.Euler(new Vector3(0, 0, rotation));
        transform.position = new Vector3(2 * Vector2.Up * time.deltaTime);
    }
}
