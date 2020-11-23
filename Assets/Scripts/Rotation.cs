﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 10f;


    void Update()
    {
        gameObject.transform.Rotate(0,rotationSpeed*Time.deltaTime, 0);
    }
}
