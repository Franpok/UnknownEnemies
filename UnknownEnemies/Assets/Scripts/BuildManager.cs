using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;

    private ClaseTorreta estructura;

    public GameObject torreta1, torreta2, torreta3;

    public void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("Doble BuildManager");
        }

        instance = this;
    }

    public bool Construir { get {return estructura != null;} }
    public bool DineroSuficiente { get { return Stats.Dinero >= estructura.coste; } }

    public void ConstruirAqui(Nodo n)
    {
        if(Stats.Dinero < estructura.coste)
        {
            return;
        }

        Stats.Dinero -= estructura.coste;

        GameObject aux = (GameObject) Instantiate(estructura.prefab, n.transform.position, Quaternion.identity);
        n.estructura = aux;
    }

    public void ElegirEstructura(ClaseTorreta est)
    {
        estructura = est;
    }
}
