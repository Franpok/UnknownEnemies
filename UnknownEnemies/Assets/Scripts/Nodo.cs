using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;

public class Nodo : MonoBehaviour
{
    public Color colorSelector;
    private Color colorInicial;

    public GameObject estructura;

    private Renderer r;

    public void Start()
    {
        r = GetComponent<Renderer>();
        colorInicial = r.material.color;
    }

    private void OnMouseDown()
    {
        if(estructura != null)
        {
            Debug.Log("No se puede construir aquí");
            return;
        }

        GameObject aux = BuildManager.instance.GetEstructura();
        estructura = Instantiate(aux, transform.position, transform.rotation);
    }

    public void OnMouseEnter()
    {
        r.material.color = colorSelector;
    }

    public void OnMouseExit()
    {
        r.material.color = colorInicial;
    }
}
