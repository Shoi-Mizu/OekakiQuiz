﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{

    void Update()
    {
        Destroy(this.gameObject, 7);
    }
}
