using UnityEngine;

public class Tienda : MonoBehaviour
{
    BuildManager buildManager;

    private void Start()
    {
        buildManager = BuildManager.instance;
    }

    public void ComprarTorreta1()
    {
        buildManager.ElegirEstructura(buildManager.torreta1);
    }

    public void ComprarTorreta2()
    {

    }
    public void ComprarTorreta3()
    {

    }
}
