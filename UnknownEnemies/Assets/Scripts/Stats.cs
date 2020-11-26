using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{
    public static int Dinero, Vida;
    public int DineroInicial = 400, VidaInicial = 20;

    private void Start()
    {
        Dinero = DineroInicial;
        Vida = VidaInicial;
    }


}
