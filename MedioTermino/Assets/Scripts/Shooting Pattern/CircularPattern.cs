using UnityEngine;

public class CircularPattern : MonoBehaviour
{
    // En este patrón el boss dispara balas en todas las direcciones formando un círculo
    public BossController bossController;
    public int numberOfBullets = 12; // Número de balas por círculo
    public float shootInterval = 1.5f; // Intervalo entre cada círculo
    public int maxWaves = 5; // Número de ondas circulares
    private int currentWave = 0;
    private float shootTimer = 0f;
    private float rotationOffset = 0f; // Para rotar cada onda

    void Update()
    {
        // Si ya completó todas las ondas circulares, para el patrón
        if (currentWave >= maxWaves)
        {
            return; // Detiene la ejecución del patrón
        }

        shootTimer += Time.deltaTime;

        // Disparar cuando llegue el momento
        if (shootTimer >= shootInterval)
        {
            ShootCircle();
            currentWave++;
            shootTimer = 0f;
            rotationOffset += 15f; // Rota 15° cada onda para crear variación
        }
    }

    void ShootCircle()
    {
        // Calcula el ángulo entre cada bala
        float angleStep = 360f / numberOfBullets;
        
        for (int i = 0; i < numberOfBullets; i++)
        {
            // Calcula el ángulo para esta bala
            float angle = (i * angleStep) + rotationOffset;
            
            // Convierte el ángulo a dirección vectorial
            Vector2 direction = new Vector2(
                Mathf.Cos(angle * Mathf.Deg2Rad),
                Mathf.Sin(angle * Mathf.Deg2Rad)
            );
            
            // Dispara la bala
            bossController.shoot(direction);
        }
    }
}
