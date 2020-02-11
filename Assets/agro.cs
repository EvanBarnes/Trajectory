using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class agro : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    GameObject[] lst = GameObject.FindGameObjectsWithTag("Player");


    GameObject player = lst[0];
    
    float distance = Mathf.Sqrt(Mathf.Pow(Mathf.Abs(player.transform.position.x - transform.position.x), 2)+ Mathf.Pow(Mathf.Abs(player.transform.position.y - transform.position.y),2));
    if(distance <= 4)
    {
      transform.GetComponent<Enemy1>().enabled = true;
    }
  }






}
