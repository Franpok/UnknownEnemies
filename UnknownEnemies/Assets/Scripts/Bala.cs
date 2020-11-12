using UnityEngine;

public class Bala : MonoBehaviour
{
    private Transform target;

    public float speed = 70f;

    public GameObject efectoImpacto;

    public void Follow(Transform t)
    {
        target = t;
    }

    void Update()
    {
        if(target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;
        float distanciaActual = speed * Time.deltaTime;

        if(dir.magnitude <= distanciaActual)
        {
            BajaConfirmada();
            return;
        }

        transform.Translate(dir.normalized * distanciaActual, Space.World);
    }

    public void BajaConfirmada()
    {
        GameObject aux = Instantiate(efectoImpacto, transform.position, transform.rotation);
        Destroy(aux, 2f);
        Destroy(gameObject);
    }
}
