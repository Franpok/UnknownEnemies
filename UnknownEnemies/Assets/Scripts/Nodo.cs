using UnityEngine.EventSystems;
using UnityEngine;

public class Nodo : MonoBehaviour
{
    BuildManager buildManager;
    
    public Color colorSelector;
    private Color colorInicial;

    [Header ("Optional")]
    public GameObject estructura;

    private Renderer r;

    public void Start()
    {
        r = GetComponent<Renderer>();
        colorInicial = r.material.color;

        buildManager = BuildManager.instance;
    }

    private void OnMouseDown()
    {
        if(!buildManager.Construir)
        {
            return;
        }
        
        if(estructura != null)
        {
            Debug.Log("No se puede construir aquí");
            return;
        }

        buildManager.ConstruirAqui(this);
    }

    public void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
        
        if (!buildManager.Construir)
        {
            return;
        }

        if (buildManager.DineroSuficiente)
        {
            r.material.color = colorSelector;
        }
        else
        {
            r.material.color = Color.red;
        }
    }

    public void OnMouseExit()
    {
        r.material.color = colorInicial;
    }
}
