using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : MonoBehaviour
{
    public Transform other;
    public GameObject bullet;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float rotation = Quaternion.LookRotation(other.position - transform.rotation);
        transfrom.rotation = Quaternion.Euler(new Vector3(0, 0, rotation));
        yield WaitForSeconds(1);
        Instantiate(bullet, transform.position, transform.rotation);
    }
}
