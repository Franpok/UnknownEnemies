using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour
{
    public float Velocidad = 10f;

    private Transform target;
    private int IDPunto = 0;

    private void Start()
    {
        target = Path.puntos[0];
    }

    private void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * Velocidad * Time.deltaTime, Space.World);
    }
}
