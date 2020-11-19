using UnityEngine;

public class Bala : MonoBehaviour
{
    private Transform target;

    public float speed = 70f, rango = 5f;

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

        transform.LookAt(target);
    }

    public void BajaConfirmada()
    {
        GameObject aux = Instantiate(efectoImpacto, transform.position, transform.rotation);
        Destroy(aux, 2f);

        if(rango > 0f)
        {
            Explosion();
        } 
        else
        {
            Daño(target);
        }

        Destroy(gameObject);
    }

    private void Daño(Transform ene)
    {
        Destroy(ene.gameObject);
    }

    private void Explosion()
    {
        Collider [] cols = Physics.OverlapSphere(transform.position, rango);

        foreach(Collider c in cols)
        {
            if (c.tag == "Enemigo")
            {
                Daño(c.transform);
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, rango);
    }
}
