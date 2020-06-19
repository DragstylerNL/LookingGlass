using System;
using System.Collections;
using System.Collections.Generic;
using Leap.Unity.Interaction;
using UnityEngine;

public class ObjectScene : MonoBehaviour
{
    [SerializeField] private Color32 color;
    [SerializeField] private GameObject floor;
    [SerializeField] private Transform wantedObjectPos;
    [SerializeField] private float closeEnoughDistance = 0.125f;
    public string name;
    private bool _onit = false;
    private bool grabbed = false;
    private Rigidbody _rigidbody;
    [SerializeField] private float maxWaitTime;
    private float currentTime = 0f;
    private bool allowed = true;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {

        if (currentTime < maxWaitTime) currentTime += Time.deltaTime;
        else allowed = true;
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Test");
            transform.position = wantedObjectPos.position;
            transform.rotation = wantedObjectPos.rotation;
        }
        
        if (!_onit) return;
        if (grabbed)
        {
            floor.GetComponent<MeshRenderer>().material.color = Color.white;
            _rigidbody.constraints = RigidbodyConstraints.None;
            _onit = false;
        }
        /*RaycastHit hit;
        if (!Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), out hit, 10f))
        {
            floor.GetComponent<MeshRenderer>().material.color = Color.white;
            _rigidbody.constraints = RigidbodyConstraints.None;
            _onit = false;
        }
        else
        {
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), out hit, 10f))
            {
                if (!hit.collider.CompareTag("Character"))
                {
                    floor.GetComponent<MeshRenderer>().material.color = Color.white;
                    _rigidbody.constraints = RigidbodyConstraints.None;
                    _onit = false;
                }
            }
        }*/
    }

    public void SetWorld()
    {
        //RaycastHit hit;
        //if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), out hit, 10f))
        //{
            //Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.down) * hit.distance, Color.blue);
            if (CloseEnough())
            {
                grabbed = false;
                floor.GetComponent<MeshRenderer>().material.color = color;
                _onit = true;
                _rigidbody.constraints = RigidbodyConstraints.FreezeAll;
                allowed = false;
                currentTime = 0;
            }
        //}
    }

    private bool CloseEnough()
    {
        float distance = Vector3.Distance(this.transform.position, wantedObjectPos.position);
        Debug.Log(distance);
        
        if (distance < closeEnoughDistance)
        {
            transform.position = wantedObjectPos.position;
            transform.rotation = wantedObjectPos.rotation;
            return true;
        }
        else
        {
            return false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name.Contains("HandZone")) return;
        if (other.name.Contains("Contact") && allowed)
        {
            grabbed = true;
            _rigidbody.constraints = RigidbodyConstraints.None;
        }
    }
}
