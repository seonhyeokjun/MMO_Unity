using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCollision : MonoBehaviour
{
    // 1) 나 혹은 상대한테 RigidBody 있어야 한다. (isKinematic = off)
    // 2) 나한테 Collider 있어야 한다. (isTrigger = off)
    // 3) 상대방한테 Collider 있어야 한다. (isTrigger = off)
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log($"OnCollision @{collision.gameObject.name} !");
    }

    // 1) 둘 다 Collider 있어야 한다.
    // 2) 둘 중 하나는 isTrigger = on
    // 3) 둘 중 하나는 RigidBody 있어야 한다.
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log($"OnTrigger @{other.gameObject.name} !");
    }
    
    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
