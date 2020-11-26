using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class UIVidas : MonoBehaviour
{
    public Text TextoVida;
    void Update()
    {
        TextoVida.text = Stats.Vida.ToString() + " VIDAS";
    }
}
