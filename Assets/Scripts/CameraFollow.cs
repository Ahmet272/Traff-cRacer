using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // Takip edilecek nesne (örneðin araç)

    public Vector3 offset = new Vector3(0, 5, -10); // Kamera ile takip edilen nesne arasýndaki mesafe ve yükseklik

    void LateUpdate()
    {
        if (target != null)
        {
            transform.position = target.position + offset; // Kamerayý takip edilecek nesnenin pozisyonuna ayarla
            transform.LookAt(target); // Kamerayý takip edilecek nesneye doðru döndür
        }
    }
}