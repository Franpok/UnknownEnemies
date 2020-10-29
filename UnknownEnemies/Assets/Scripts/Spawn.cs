using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public Transform PrefabEnemigo;

    public Transform[] PuntosSpawn;

    public float TiempoEntreOleadas = 5f;
    private float cuentaAtras = 2f;

    private int numeroOleada = 1;
    private int numeroEnemigos = 20;

    private void Update()
    {
        if(cuentaAtras <= 0f)
        {
            SpawnOleada();
            cuentaAtras = TiempoEntreOleadas;
        }

        cuentaAtras -= Time.deltaTime;
    }

    public void SpawnOleada()
    {
        for (int i = 0; i < numeroOleada; i++)
        {
            SpawnEnemigo();
        }

        numeroOleada++;
    }

    public void SpawnEnemigo()
    {
        int a = Random.Range(1, 2);

        Instantiate(PrefabEnemigo, PuntosSpawn[a - 1].position, PuntosSpawn[a - 1].rotation);
    }
}
