using UnityEngine.EventSystems;
using UnityEngine;

public class Nodo : MonoBehaviour
{
    BuildManager buildManager;
    
    public Color colorSelector;
    private Color colorInicial;

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
        if(buildManager.GetEstructura() == null)
        {
            return;
        }
        
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
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
        
        if (buildManager.GetEstructura() == null)
        {
            return;
        }

        r.material.color = colorSelector;
    }

    public void OnMouseExit()
    {
        r.material.color = colorInicial;
    }
}
