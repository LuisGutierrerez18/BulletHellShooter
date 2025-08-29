using UnityEngine;

public class MoveForward : MonoBehaviour
{
    public float speed = 2f; // Velocidad de movimiento

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Usa la rotación actual del barco para calcular la dirección
        float angleInRadians = transform.eulerAngles.z * Mathf.Deg2Rad;

        // Calcula la dirección en la que se moverá el barco
        Vector2 direction = new Vector2(Mathf.Cos(angleInRadians), Mathf.Sin(angleInRadians));

        // Mueve el barco en esa dirección
        transform.position += (Vector3)(direction * speed * Time.deltaTime);

        // Destruye el barco si sale de la pantalla
        if (Vector2.Distance(transform.position, Vector2.zero) > 150f)
        {
            Destroy(gameObject);
        }
    }
    // Barcos explotan si son alcanzados por una bala
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PlayerBullet"))
        {
            // Aquí puedes agregar efectos de explosión o sonido si lo deseas
            Destroy(gameObject); // Destruye el barco
            Destroy(collision.gameObject); // Destruye la bala
        }
    }
}
