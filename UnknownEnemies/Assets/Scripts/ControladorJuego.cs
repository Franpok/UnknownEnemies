using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorJuego : MonoBehaviour
{
    private bool gO = false;

    void Update()
    {
        if (gO)
            return;
        
        if(Stats.Vida <= 0)
        {
            GameOver();
        }
    }

    public void GameOver()
    {
        gO = true;
        Debug.Log("GameOver");
    }
}
