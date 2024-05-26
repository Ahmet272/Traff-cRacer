using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarController : MonoBehaviour
{
    public float speed = 2f; // Baþlangýç hýzý
    public float maxSpeed = 20f;
    public float acceleration = 2f;
    public float deceleration = 2f;
    public float steeringSpeed = 2f;

    private bool isAccelerating = false;
    private bool isBraking = false;
    private bool isSteeringLeft = false;
    private bool isSteeringRight = false;

   // public float speed = 10.0f;
    public float maxRight = 3.0f; // Sað sýnýr
    public float maxLeft = -3.0f; // Sol sýnýr
    void Start()
    {
        // Butonlarý bul ve olay dinleyicilerini ekle
        Button gasButton = GameObject.Find("GasButton").GetComponent<Button>();
        gasButton.onClick.AddListener(() => StartAccelerating());
        gasButton.onClick.AddListener(() => StopAccelerating());

        Button brakeButton = GameObject.Find("BrakeButton").GetComponent<Button>();
        brakeButton.onClick.AddListener(() => StartBraking());
        brakeButton.onClick.AddListener(() => StopBraking());

        Button leftButton = GameObject.Find("LeftButton").GetComponent<Button>();
        leftButton.onClick.AddListener(() => StartSteeringLeft());
        leftButton.onClick.AddListener(() => StopSteeringLeft());

        Button rightButton = GameObject.Find("RightButton").GetComponent<Button>();
        rightButton.onClick.AddListener(() => StartSteeringRight());
        rightButton.onClick.AddListener(() => StopSteeringRight());

        // Baþlangýçta aracý hareket ettir
        GetComponent<Rigidbody>().velocity = transform.forward * speed;
    }

    void Update()
    {
        // Aracý ileri hareket ettirin
        if (isAccelerating)
        {
            speed = Mathf.Min(speed + acceleration * 3.5f *Time.deltaTime, maxSpeed);
        }
        if (isBraking)
        {
            speed = Mathf.Max(speed - deceleration * 10f *Time.deltaTime, 2.5f);
        }

        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        // Saða ve sola hareket ettirin
        if (isSteeringLeft)
        {
            transform.Translate(Vector3.left * steeringSpeed * 5f * Time.deltaTime);
        }
        if (isSteeringRight)
        {
            transform.Translate(Vector3.right * steeringSpeed * 5f *Time.deltaTime);
        }
        // Sað sýnýr kontrolü
        if (transform.position.x > maxRight)
        {
            transform.position = new Vector3(maxRight, transform.position.y, transform.position.z);
        }

        // Sol sýnýr kontrolü
        if (transform.position.x < maxLeft)
        {
            transform.position = new Vector3(maxLeft, transform.position.y, transform.position.z);
        }
    }

    public void StartAccelerating()
    {
        isAccelerating = true;
    }

    public void StopAccelerating()
    {
        isAccelerating = false;
    }

    public void StartBraking()
    {
        isBraking = true;
    }

    public void StopBraking()
    {
        isBraking = false;
    }

    public void StartSteeringLeft()
    {
        isSteeringLeft = true;
    }

    public void StopSteeringLeft()
    {
        isSteeringLeft = false;
    }

    public void StartSteeringRight()
    {
        isSteeringRight = true;
    }

    public void StopSteeringRight()
    {
        isSteeringRight = false;
    }
}
