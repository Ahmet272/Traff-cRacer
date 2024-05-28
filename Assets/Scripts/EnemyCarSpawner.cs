using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCarSpawner : MonoBehaviour
{
    public GameObject enemyCarPrefab;  // D��man ara� prefab'�
    public Transform car;  // Oyuncu arac�n�n referans�
    public float spawnInterval = 2f;  // D��man ara�lar�n�n spawnlanma aral���
    public float spawnDistance = 50f;  // D��man ara�lar�n�n oyuncu arac�n�n �n�ne spawnlanaca�� mesafe
    public int maxEnemiesAtOnce = 5;  // Ayn� anda bulunabilecek maksimum d��man ara� say�s�

    private List<GameObject> activeEnemies = new List<GameObject>();  // Aktif d��man ara�lar�n listesi

    private void Start()
    {
        StartCoroutine(SpawnEnemyCars());
    }

    private void Update()
    {
        // Geride kalan d��man ara�lar�n� temizle
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
        // Oyuncu arac�n�n �n�nde rastgele bir pozisyonda d��man arac� spawnla
        Vector3 spawnPosition = new Vector3(Random.Range(-2f, 2f), 0, car.position.z + spawnDistance);
        GameObject enemyCar = Instantiate(enemyCarPrefab, spawnPosition, Quaternion.identity);
        activeEnemies.Add(enemyCar);
    }
}