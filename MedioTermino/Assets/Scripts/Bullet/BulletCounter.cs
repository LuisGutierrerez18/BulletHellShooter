using UnityEngine;
using TMPro;
using System.Collections;

public class BulletCounter : MonoBehaviour
{
    // Referencia al canvas donde mostraremos el contador
    public TextMeshProUGUI bulletCountText;
    
    private int activeBullets = 0;
    
    public void Start()
    {
        StartCoroutine(CountBulletsCoroutine());
    }
    
    // Coroutine que cuenta balas cada 0.1 segundos 
    IEnumerator CountBulletsCoroutine()
    {
        while (true)
        {
            CountActiveBullets();
            UpdateDisplay(); // actualiza el TMP
            yield return new WaitForSeconds(0.1f); // Actualiza cada 0.1 segundos
        }
    }
    
    public void CountActiveBullets()
    {
        // Busca todos los objetos Bullet que estén activos
        Bullet[] allBullets = FindObjectsOfType<Bullet>();
        activeBullets = 0;
        
        foreach (Bullet bullet in allBullets)
        {
            if (bullet.gameObject.activeInHierarchy)
            {
                activeBullets++;
            }
        }
    }
    
    public void UpdateDisplay()
    {
        if (bulletCountText != null)
        {
            bulletCountText.text = "Bullets: " + activeBullets;
        }
    }
}
