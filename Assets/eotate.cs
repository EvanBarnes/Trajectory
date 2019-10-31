using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eotate : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    Transform meeple = transform.parent.GetChild(1);
    transform.position = meeple.position;
    
    }
}
