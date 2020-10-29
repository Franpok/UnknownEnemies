using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Path : MonoBehaviour
{
    public int IDPath;

    public static Transform[] puntos1;
    public static Transform[] puntos2;

    private void Awake()
    {
        switch (IDPath)
        {
            case 1:

                puntos1 = new Transform[transform.childCount];

                for (int i = 0; i < puntos1.Length; i++)
                {
                    puntos1[i] = transform.GetChild(i);
                }

                break;

            case 2:

                puntos2 = new Transform[transform.childCount];

                for (int i = 0; i < puntos2.Length; i++)
                {
                    puntos2[i] = transform.GetChild(i);
                }

                break;
        }
    }
}
