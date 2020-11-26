using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spawn : MonoBehaviour
{
    public Transform PrefabEnemigo;

    public Transform[] PuntosSpawn;

    public Text numeroOleadaTexto;

    public float TiempoEntreOleadas = 5f;
    private float cuentaAtras = 2f;

    private int numeroOleada = 0;
    private int numeroEnemigos = 20;

    private void Update()
    {
        if(cuentaAtras <= 0f)
        {
            StartCoroutine(SpawnOleada());
            cuentaAtras = TiempoEntreOleadas;
        }

        cuentaAtras -= Time.deltaTime;

        cuentaAtras = Mathf.Clamp(cuentaAtras, 0f, Mathf.Infinity);

        numeroOleadaTexto.text = string.Format("{0:00.00}", cuentaAtras);
    }

    IEnumerator SpawnOleada()
    {
        numeroOleada++;

        for (int i = 0; i < numeroOleada; i++)
        {
            SpawnEnemigo();
            yield return new WaitForSeconds(0.4f);
        }
    }

    public void SpawnEnemigo()
    {
        int a = Random.Range(1, 3);

        Instantiate(PrefabEnemigo, PuntosSpawn[a - 1].position, PuntosSpawn[a - 1].rotation);
    }
}
