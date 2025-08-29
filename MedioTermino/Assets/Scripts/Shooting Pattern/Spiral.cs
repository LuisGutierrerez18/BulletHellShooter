using UnityEngine;

public class Spiral : MonoBehaviour
{
    // En este patrón el boss rota continuamente mientras dispara, creando una espiral
    public BossController bossController;
    public int totalBullets = 40; // Total de balas en la espiral
    public float rotationSpeed = 9f; // Grados que rota por cada disparo (360°/40 = 9°)
    public float shootInterval = 0.1f; // Intervalo entre disparos (más rápido para efecto espiral)
    public int maxSpirals = 3; // Número de espirales completas
    
    private int bulletsShot = 0;
    private int currentSpiral = 0;
    private float shootTimer = 0f;
    private float currentAngle = 0f;

    //   
    public void OnEnable()
    {
        bulletsShot = 0;
        currentSpiral = 0;
        shootTimer = 0f;
        currentAngle = 0f;
    }
    
    public void Update()
    {
        // Detiene el patrón cuando haya completado todas las espirales
        if (currentSpiral >= maxSpirals)
        {
            return; // Sale de la función Update, detiene el patrón
        }

        shootTimer += Time.deltaTime;

        // Dispara y rota continuamente
        if (shootTimer >= shootInterval && bulletsShot < totalBullets)
        {
            // Dispara en la dirección actual
            Vector2 direction = -transform.up;
            bossController.shoot(direction);

            // Rota un poco para el siguiente disparo
            currentAngle += rotationSpeed;
            transform.rotation = Quaternion.Euler(0, 0, currentAngle);

            bulletsShot++;
            shootTimer = 0f;
        }

        // Si completó una espiral, reinicia para la siguiente
        if (bulletsShot >= totalBullets)
        {
            bulletsShot = 0;
            currentSpiral++;
            // Opcional: pequeña pausa entre espirales
            shootTimer = -1f; // Pausa de 1s entre espirales
        }
    }
}
