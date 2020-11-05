using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torreta1 : MonoBehaviour
{
    private Transform target;
    public Transform rotatoria;

    public float rango = 15f, speed = 10f;

    public string TagEnemigo = "Enemigo";

    void Start()
    {
        InvokeRepeating("ActualizarTarget", 0f, 0.5f);
    }

    public void ActualizarTarget()
    {
        GameObject[] enemigos = GameObject.FindGameObjectsWithTag(TagEnemigo);
        GameObject enemigoCerca = null;

        float distanciaEnemigo, distanciaCerca = Mathf.Infinity; 

        foreach(GameObject e in enemigos)
        {
            distanciaEnemigo = Vector3.Distance(transform.position, e.transform.position);

            if(distanciaEnemigo < distanciaCerca)
            {
                distanciaCerca = distanciaEnemigo;
                enemigoCerca = e;
            }
        }

        if(enemigoCerca != null && distanciaCerca <= rango)
        {
            target = enemigoCerca.transform;
        }
        else
        {
            target = null;
        }
    }

    void Update()
    {
        if(target == null)
        {
            return;
        }

        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotacion = Quaternion.Lerp(rotatoria.rotation, lookRotation, Time.deltaTime * speed).eulerAngles;
        rotatoria.rotation = Quaternion.Euler(0f, rotacion.y, 0f);
    }

    public void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, rango);
    }
}
