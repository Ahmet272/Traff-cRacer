using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadManager : MonoBehaviour
{
    public GameObject[] roadPrefabs; // Yol segment prefablar�
    public Transform playerTransform; // Oyuncunun arabas�n�n Transform component'i
    private float spawnZ = 0.0f; // �lk yol segmentinin spawn edilece�i Z koordinat�
    private float roadLength = 30.0f; // Yol segmentinin uzunlu�u (her segmentin uzunlu�una g�re ayarlay�n)
    private int numberOfRoads = 5; // Ayn� anda aktif olan yol segmenti say�s�
    private List<GameObject> activeRoads; // Aktif olan yol segmentlerinin listesi

    void Start()
    {
        activeRoads = new List<GameObject>();

        for (int i = 0; i < numberOfRoads; i++)
        {
            if (i < 2) // Oyuncunun ilk g�rece�i segmentler
                SpawnRoad(0);
            else
                SpawnRoad(Random.Range(0, roadPrefabs.Length));
        }
    }

    void Update()
    {
        if (playerTransform.position.z - 35 > (spawnZ - numberOfRoads * roadLength))
        {
            SpawnRoad(Random.Range(0, roadPrefabs.Length));
            DeleteRoad();
        }
    }

    private void SpawnRoad(int roadIndex)
    {
        GameObject go = Instantiate(roadPrefabs[roadIndex]) as GameObject;
        go.transform.SetParent(transform);
        go.transform.position = Vector3.forward * spawnZ;
        spawnZ += roadLength;
        activeRoads.Add(go);
    }

    private void DeleteRoad()
    {
        Destroy(activeRoads[0]);
        activeRoads.RemoveAt(0);
    }
}
