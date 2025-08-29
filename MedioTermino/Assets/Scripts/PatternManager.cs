using UnityEngine;

public class PatternManager : MonoBehaviour
{
    [Header("Patrones de Disparo")]
    public MonoBehaviour linearShooting;    // Referencia al script LinearShooting
    public MonoBehaviour circularPattern;   // Referencia al script CircularPattern
    public MonoBehaviour spiral;            // Referencia al script Spiral
    
    [Header("Configuración de Tiempo")]
    public float patternDuration = 10f;     // Duración de cada patrón (10 segundos)
    
    private float timer = 0f;
    private int currentPattern = 0;         // 0 = Linear, 1 = Circular, 2 = Spiral
    private bool gameStarted = false;
    
    void Start()
    {
        // Desactiva todos los patrones al inicio
        DisableAllPatterns();
        
        // Inicia el primer patrón
        StartPattern(0);
        gameStarted = true;
    }
    
    void Update()
    {
        if (!gameStarted) return;
        
        timer += Time.deltaTime;
        
        // Cambia de patrón cada 10 segundos
        if (timer >= patternDuration)
        {
            // Desactiva el patrón actual
            DisableAllPatterns();
            
            // Pasa al siguiente patrón
            currentPattern++;
            
            // Si completó los 3 patrones (30 segundos total), reinicia o termina
            if (currentPattern >= 3)
            {
                Debug.Log("¡Secuencia de patrones completada!");
                currentPattern = 0; // Reinicia la secuencia (opcional)
            }
            
            // Activa el nuevo patrón
            StartPattern(currentPattern);
            
            // Reinicia el timer
            timer = 0f;
        }
    }
    
    void StartPattern(int patternIndex)
    {
        switch (patternIndex)
        {
            case 0:
                Debug.Log("Iniciando Patrón Linear");
                linearShooting.enabled = true;
                break;
            case 1:
                Debug.Log("Iniciando Patrón Circular");
                circularPattern.enabled = true;
                break;
            case 2:
                Debug.Log("Iniciando Patrón Spiral");
                spiral.enabled = true;
                break;
        }
    }
    
    void DisableAllPatterns()
    {
        linearShooting.enabled = false;
        circularPattern.enabled = false;
        spiral.enabled = false;
    }
    
    // Método público para obtener información del patrón actual
    public string GetCurrentPatternName()
    {
        switch (currentPattern)
        {
            case 0: return "Linear Shooting";
            case 1: return "Circular Pattern";
            case 2: return "Spiral Pattern";
            default: return "Unknown";
        }
    }
    
    public float GetRemainingTime()
    {
        return patternDuration - timer;
    }
}
