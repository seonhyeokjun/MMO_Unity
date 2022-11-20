using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;
using UnityEngine.Windows;
using Input = UnityEngine.Input;

// 1. 위치벡터
// 2. 방향벡터
struct MyVector
{
    public float x;
    public float y;
    public float z;
    
    //               +
    //       +       +
    // +-------------+
    public float manitude
    {
        get
        {
            return Mathf.Sqrt(x * x + y * y + z * z);
        }
    }
    public MyVector normalized
    {
        get
        {
            return new MyVector(x / manitude, y / manitude, z / manitude);
        }
    }
    
    public MyVector(float x, float y, float z)
    {
        this.x = x;
        this.y = y;
        this.z = z;
    }

    public static MyVector operator +(MyVector a, MyVector b)
    {
        return new MyVector(a.x + b.x, a.y + b.y, a.z + b.z);
    }
    
    public static MyVector operator -(MyVector a, MyVector b)
    {
        return new MyVector(a.x - b.x, a.y - b.y, a.z - b.z);
    }

    public static MyVector operator *(MyVector a, float d)
    {
        return new MyVector(a.x * d, a.y * d, a.z * d);
    }
}

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    float _speed = 10.0f;
    
    void Start()
    {
        // MyVector pos = new MyVector(0.0f, 10.0f, 0.0f);
        // pos += new MyVector(0.0f, 2.0f, 0.0f);
        
        MyVector to = new MyVector(10.0f, 0.0f, 0.0f);
        MyVector from = new MyVector(5.0f, 0.0f, 0.0f);
        MyVector dir = to - from; // (5.0f, 0.0f, 0.0f)

        dir = dir.normalized; // (1.0f, 0.0f, 0.0f)

        MyVector newPos = from + dir * _speed;

        // 방향 벡터
        // 1. 거리 (크기)
        // 2. 실제 방향


    }

    // GameObject (Player)
        // Transform
        // PlayerController(*)
    void Update()
    {
        // Local -> World
        // TransformDirection
        
        // World -> Local
        // InverseTransformDirection

        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * (Time.deltaTime * _speed));
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.back * (Time.deltaTime * _speed));
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * (Time.deltaTime * _speed));
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * (Time.deltaTime * _speed));
        }
    }
}