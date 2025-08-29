using UnityEngine;

public class BossController : MonoBehaviour
{
    // Hacemos referencia al bullet pool para poder utilizarlo
    public BulletPool bulletPool;

    public void shoot(Vector2 direction)
    {
        Bullet bullet = bulletPool.GetBullet();
        bullet.transform.position = transform.position; // Posición del jefe
        bullet.direction = direction; // Dirección de disparo
        bullet.speed = 10f; // Puedes ajustar la velocidad
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    /*void Start()
    {
        // Dispara automáticamente cada segundo
        InvokeRepeating("ShootForward", 1f, 1f);
    }

    void ShootForward()
    {
        shoot(Vector2.down); // Dispara hacia abajo
    }*/

    // Update is called once per frame
    void Update()
    {
        
    }
}
