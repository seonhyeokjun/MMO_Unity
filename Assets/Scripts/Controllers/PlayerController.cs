using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;
using UnityEngine.Windows;
using Input = UnityEngine.Input;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    float _speed = 10.0f;
    
    bool _moveToDest = false;
    Vector3 _destPos;
    
    void Start()
    {
        Managers.Input.KeyAction -= Onkeyboard;
        Managers.Input.KeyAction += Onkeyboard;
        Managers.Input.MouseAction -= OnMouseClicked;
        Managers.Input.MouseAction += OnMouseClicked;
    }

    void Update()
    {
        if (_moveToDest)
        {
            Vector3 dir = _destPos - transform.position;
            if (dir.magnitude < 0.0001f)
            {
                _moveToDest = false;
            }
            else
            {
                float moveDist = Mathf.Clamp(_speed * Time.deltaTime, 0, dir.magnitude);
                transform.position += dir.normalized * moveDist;
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dir), 10 * Time.deltaTime);
            }
        }

        if (_moveToDest)
        {
            Animator anim = GetComponent<Animator>();
            anim.Play("RUN");
        }
        else
        {
            Animator anim = GetComponent<Animator>();
            anim.Play("WAIT");
        }
        
    }

    void Onkeyboard()
    {
        if (Input.GetKey(KeyCode.W))
        {
            // transform.rotation = Quaternion.LookRotation(Vector3.forward);
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.forward), 0.2f);
            transform.position += Vector3.forward * (Time.deltaTime * _speed);
        }

        if (Input.GetKey(KeyCode.S))
        {
            // transform.rotation = Quaternion.LookRotation(Vector3.back);
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.back), 0.2f);
            transform.position += Vector3.back * (Time.deltaTime * _speed);
        }

        if (Input.GetKey(KeyCode.A))
        {
            // transform.rotation = Quaternion.LookRotation(Vector3.left);
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.left), 0.2f);
            transform.position += Vector3.left * (Time.deltaTime * _speed);
        }

        if (Input.GetKey(KeyCode.D))
        {
            // transform.rotation = Quaternion.LookRotation(Vector3.right);
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.right), 0.2f);
            transform.position += Vector3.right * (Time.deltaTime * _speed);
        }
        
        _moveToDest = false;
    }
    
    void OnMouseClicked(Define.MouseEvent evt)
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(Camera.main.transform.position, ray.direction * 100.0f, Color.red, 1.0f);

        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 100.0f, LayerMask.GetMask("Wall")))
        {
            _destPos = hit.point;
            _moveToDest = true;
        }
    }
}