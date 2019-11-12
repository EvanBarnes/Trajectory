using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eotate : MonoBehaviour
{
  // Start is called before the first frame update
  Transform meeple;
    void Start()
    {
    meeple = transform.parent.GetChild(1);
  }

    // Update is called once per frame
    void Update()
    {
    
    transform.position = meeple.position;
    
    }
  
  private void OnCollisionEnter2D(Collision2D collision)
  {
    if (collision.collider.CompareTag("Bullet"))
    {
      meeple.GetComponent<BigB>().damage();
      Destroy(collision.gameObject);
    }
  }
  
}
