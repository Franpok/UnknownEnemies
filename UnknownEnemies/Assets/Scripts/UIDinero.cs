using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class UIDinero : MonoBehaviour
{
    public Text TextoDinero;
    void Update()
    {
        TextoDinero.text = Stats.Dinero.ToString() + "€";
    }
}
