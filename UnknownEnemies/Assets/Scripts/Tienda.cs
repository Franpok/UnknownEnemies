using UnityEngine;

public class Tienda : MonoBehaviour
{
    BuildManager buildManager;

    public ClaseTorreta torreta_1, torreta_2;

    private void Start()
    {
        buildManager = BuildManager.instance;
    }

    public void ElegirTorreta1()
    {
        buildManager.ElegirEstructura(torreta_1);
    }

    public void ElegirTorreta2()
    {
        buildManager.ElegirEstructura(torreta_2);
    }
    public void ElegirTorreta3()
    {
        //buildManager.ElegirEstructura(buildManager.torreta3);
    }
}
