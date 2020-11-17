using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float panSpeed = 30f, scrollSpeed = 5f, minScroll = 10f, maxScroll = 151f;
    private float offset = 10f;

    private bool movimiento = true;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            movimiento = !movimiento;
        }
        
        if (!movimiento)
        {
            return;
        }
        
        //Hacer Clamp?

        if (Input.GetKey("w") || Input.mousePosition.y >= Screen.height - offset)
        {
            transform.Translate(Vector3.forward * panSpeed * Time.deltaTime, Space.World);
        }

        if (Input.GetKey("s") || Input.mousePosition.y <= offset)
        {
            transform.Translate(Vector3.back * panSpeed * Time.deltaTime, Space.World);
        }

        if (Input.GetKey("d") || Input.mousePosition.x >= Screen.width - offset)
        {
            transform.Translate(Vector3.right * panSpeed * Time.deltaTime, Space.World);
        }

        if (Input.GetKey("a") || Input.mousePosition.x <= offset)
        {
            transform.Translate(Vector3.left * panSpeed * Time.deltaTime, Space.World);
        }

        float scroll = Input.GetAxis("Mouse ScrollWheel");

        Vector3 pos = transform.position;

        pos.y -= scroll * 1000 * scrollSpeed * Time.deltaTime;
        pos.y = Mathf.Clamp(pos.y, minScroll, maxScroll);

        transform.position = pos;
    }
}
