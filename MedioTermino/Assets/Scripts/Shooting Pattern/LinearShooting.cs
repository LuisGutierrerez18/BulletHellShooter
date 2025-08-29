using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    // En este modo de disparo el boss rotara sobre su eje 90 grados y disparara
    public BossController bossController;
    public int bulletsPerRotation = 10;
    public float rotationAngle = 90f;
    private int currentRotation = 0;
    private int bulletsShot = 0;
    public int maxRotations = 5; // Para permitir 4 rotaciones completas
    private float shootTimer = 0f;
    public float shootInterval = 0.5f;
    private float currentAngle = 0f;


    void Update() {
        // Para cuando complete 1080° (3 ciclos completos) y haya disparado las balas finales
        if (currentAngle >= 1080f && bulletsShot >= bulletsPerRotation) return;

        shootTimer += Time.deltaTime; // Actualiza el temporizador de disparo

        // Dispara si es tiempo y faltan balas
        if (shootTimer >= shootInterval && bulletsShot < bulletsPerRotation)
        {
            Vector2 direction = -transform.up; // Dirección de disparo
            bossController.shoot(direction);
            bulletsShot++;
            shootTimer = 0f;
        }
        
        // Si completó las 10 balas y no ha completado 1080°, rota
        if (bulletsShot >= bulletsPerRotation && currentAngle < 1080f && shootTimer >= 0.1f)
        {
            currentAngle += rotationAngle; // Rota el objeto
            transform.rotation = Quaternion.Euler(0, 0, currentAngle); // Aplica la rotación
            bulletsShot = 0;
            currentRotation++;
            shootTimer = shootInterval; // Reinicia el temporizador de disparo
        }
    }


}
