﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class restart : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    if (Input.GetKey(KeyCode.R))
    {
      SceneManager.LoadScene("SampleScene");

    }
    if (Input.GetAxis("X")>.9)
    {
      SceneManager.LoadScene("SampleScene");
    }
  }
}
