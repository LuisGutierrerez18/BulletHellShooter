using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Velocidad de la bala
    public float speed = 10f;

    // Dirección de la bala
    public Vector2 direction = Vector2.down;

    // Vida de la bala en caso de no impactar con nada
    private float maxLifetime = 5f;
    private float lifetime = 0f;

    // Update is called once per frame
    void Update()
    {
        // Mover la bala en la dirección especificada
        transform.Translate(direction * speed * Time.deltaTime);

        // Actualizar el tiempo de vida de la bala
        lifetime += Time.deltaTime;
        // Destruir la bala si ha excedido su tiempo de vida
        if (lifetime > maxLifetime)
        {
            Disable();
        }
    }

    void OnEnable()
    {
        lifetime = 0f; // Reinicia el lifetime cada vez que se activa
    }

    private void Disable()
    {
        lifetime = 0f; // Reinicia el lifetime para el próximo uso
        gameObject.SetActive(false);
    } 
}
