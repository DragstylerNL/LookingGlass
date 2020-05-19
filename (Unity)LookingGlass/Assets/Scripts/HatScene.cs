using System;
using System.Collections;
using System.Collections.Generic;
using Leap.Unity.Interaction;
using UnityEngine;

public class HatScene : MonoBehaviour
{
    [SerializeField] private Color32 color;
    [SerializeField] private GameObject floor;
    public string name;
    private bool _onit = false;

    void Update()
    {
        if (!_onit) return;
        RaycastHit hit;
        if (!Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), out hit, 10f))
        {
            floor.GetComponent<MeshRenderer>().material.color = Color.white;
            _onit = false;
        }
        else
        {
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), out hit, 10f))
            {
                if (!hit.collider.CompareTag("Character"))
                {
                    floor.GetComponent<MeshRenderer>().material.color = Color.white;
                    _onit = false;
                }
            }
        }
    }

    public void SetWorld()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), out hit, 10f))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.down) * hit.distance, Color.blue);
            if (hit.collider.CompareTag("Character"))
            {
                floor.GetComponent<MeshRenderer>().material.color = color;
                _onit = true;
            }
        }
    }
}
