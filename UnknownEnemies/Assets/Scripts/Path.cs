﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Path : MonoBehaviour
{
    public static Transform[] puntos;

    private void Awake()
    {
        puntos = new Transform[transform.childCount];

        for (int i = 0; i < puntos.Length; i++)
        {
            transform.GetChild(i);
        }
    }
}
