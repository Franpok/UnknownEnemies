using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour
{
    public float Velocidad = 20f;
    private int IDPunto = 0;
    private int IDPath;

    private Transform target;
    private Transform[] PTS;

    public GameObject [] posSpawn;

    private bool door = true;

    private void Start()
    {
        if (this.transform.position == posSpawn[0].transform.position)
        {
            IDPath = 1;
        }
        else
        {
            IDPath = 2;
        }
        
        switch (IDPath)
        {
            case 1: PTS = Path.puntos1;
                target = Path.puntos1[0];
                break;
            case 2: PTS = Path.puntos2;
                target = Path.puntos2[0];
                break;
        }  
    }

    private void Update()
    {
        if (door)
        {
            Vector3 dir = target.position - transform.position;
            transform.Translate(dir.normalized * Velocidad * Time.deltaTime, Space.World);
        } 

        if (Vector3.Distance(transform.position, target.position) <= 0.2f)
        {
            SiguientePunto();
        }
    }

    public void SiguientePunto()
    {
        if (PTS.Length - 1 <= IDPunto)
        {
            //Destroy(gameObject);
            door = false;
            return;
        }
        
        IDPunto++;
        target = PTS[IDPunto];
    }
}
