using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // Takip edilecek nesne (�rne�in ara�)

    public Vector3 offset = new Vector3(0, 5, -10); // Kamera ile takip edilen nesne aras�ndaki mesafe ve y�kseklik

    void LateUpdate()
    {
        if (target != null)
        {
            transform.position = target.position + offset; // Kameray� takip edilecek nesnenin pozisyonuna ayarla
            transform.LookAt(target); // Kameray� takip edilecek nesneye do�ru d�nd�r
        }
    }
}