using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torreta3 : MonoBehaviour
{
    public string TagEnemigo = "Enemigo";

    private Transform target;
    public Transform rotatoria;

    public float rango = 15f, speed = 10f, cadencia = 1f;

    public LineRenderer lR;

    public GameObject prefabBala;
    public Transform spawnBala;

    void Start()
    {
        InvokeRepeating("ActualizarTarget", 0f, 0.5f);
    }

    public void ActualizarTarget()
    {
        GameObject[] enemigos = GameObject.FindGameObjectsWithTag(TagEnemigo);
        GameObject enemigoCerca = null;

        float distanciaEnemigo, distanciaCerca = Mathf.Infinity;

        foreach (GameObject e in enemigos)
        {
            distanciaEnemigo = Vector3.Distance(transform.position, e.transform.position);

            if (distanciaEnemigo < distanciaCerca)
            {
                distanciaCerca = distanciaEnemigo;
                enemigoCerca = e;
            }
        }

        if (enemigoCerca != null && distanciaCerca <= rango)
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
        if (target == null)
        {
            if (lR.enabled)
            {
                lR.enabled = false;
            }

            return;
        }

        MirarTarget();

        if (!lR.enabled)
            lR.enabled = true;

        lR.SetPosition(0, spawnBala.position);
        lR.SetPosition(1, target.position);
    }

    public void MirarTarget()
    {
        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotacion = Quaternion.Lerp(rotatoria.rotation, lookRotation, Time.deltaTime * speed).eulerAngles;
        rotatoria.rotation = Quaternion.Euler(0f, rotacion.y, 0f);
    }

    public void Shoot()
    {
        GameObject balaPro = Instantiate(prefabBala, spawnBala.position, spawnBala.rotation);
        Bala bala = balaPro.GetComponent<Bala>();

        if (bala != null)
        {
            bala.Follow(target);
        }
    }

    public void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, rango);
    }
}
