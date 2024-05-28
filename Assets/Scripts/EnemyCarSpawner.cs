using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCarSpawner : MonoBehaviour
{
    public GameObject enemyCarPrefab;  // Düþman araç prefab'ý
    public Transform car;  // Oyuncu aracýnýn referansý
    public float spawnInterval = 2f;  // Düþman araçlarýnýn spawnlanma aralýðý
    public float spawnDistance = 50f;  // Düþman araçlarýnýn oyuncu aracýnýn önüne spawnlanacaðý mesafe
    public int maxEnemiesAtOnce = 5;  // Ayný anda bulunabilecek maksimum düþman araç sayýsý

    private List<GameObject> activeEnemies = new List<GameObject>();  // Aktif düþman araçlarýn listesi

    private void Start()
    {
        StartCoroutine(SpawnEnemyCars());
    }

    private void Update()
    {
        // Geride kalan düþman araçlarýný temizle
        for (int i = activeEnemies.Count - 1; i >= 0; i--)
        {
            if (activeEnemies[i].transform.position.z < car.position.z - 10f)
            {
                Destroy(activeEnemies[i]);
                activeEnemies.RemoveAt(i);
            }
        }
    }

    private IEnumerator SpawnEnemyCars()
    {
        while (true)
        {
            if (activeEnemies.Count < maxEnemiesAtOnce)
            {
                SpawnEnemyCar();
            }
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    private void SpawnEnemyCar()
    {
        // Oyuncu aracýnýn önünde rastgele bir pozisyonda düþman aracý spawnla
        Vector3 spawnPosition = new Vector3(Random.Range(-2f, 2f), 0, car.position.z + spawnDistance);
        GameObject enemyCar = Instantiate(enemyCarPrefab, spawnPosition, Quaternion.identity);
        activeEnemies.Add(enemyCar);
    }
}