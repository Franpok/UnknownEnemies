using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;
    
    private GameObject estructura;

    public GameObject torreta1;

    public void Awake()
    {
        if(instance != null)
        {
            Debug.LogError("Doble BuildManager");
        }

        instance = this;
    }

    public GameObject GetEstructura()
    {
        return estructura;
    }

    public void ElegirEstructura(GameObject est)
    {
        estructura = est;
    }
}
