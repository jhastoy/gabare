﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turnOver : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, -transform.parent.localEulerAngles.y, transform.localEulerAngles.z);

    }
}
