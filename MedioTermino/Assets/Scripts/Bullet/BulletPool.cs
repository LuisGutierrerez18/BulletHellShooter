using UnityEngine;
using System.Collections.Generic;

public class BulletPool : MonoBehaviour
{
    // Tiene referencia al prefab de la bala
    // SerializeField se utiliza para hacer que un campo privado sea visible en el Inspector de Unity
    [SerializeField] private Bullet bulletPrefab;
    [SerializeField] private int poolSize = 10;

    // Lista de balas donde iremos guardando las balas utilizadas
    private List<Bullet> bulletPool = new List<Bullet>();

    
    void Awake()
    {
        // Inicializamos el pool de balas
        AddBulletsToPool(poolSize);
    }

    // Agregamos las balas al pool
    void AddBulletsToPool(int count)
    {
        // Creamos las balas y las desactivamos
        for (int i = 0; i < count; i++)
        {
            Bullet bullet = Instantiate(bulletPrefab);
            bullet.gameObject.SetActive(false);
            bulletPool.Add(bullet);
            bullet.transform.parent = transform;
        }
    }

    public Bullet GetBullet()
    {
        // Recorre todos los elementos de la lista de balas en busca de una bala inactiva en el pool
       foreach (Bullet bullet in bulletPool)
        {
            if (!bullet.gameObject.activeInHierarchy)
            {
                bullet.gameObject.SetActive(true);
                return bullet;
            }
        }
        // Si no encontramos una bala inactiva, agregamos una nueva al pool
        AddBulletsToPool(1);
        Bullet newBullet = bulletPool[bulletPool.Count - 1];
        newBullet.gameObject.SetActive(true);
        return newBullet;
    }
}
