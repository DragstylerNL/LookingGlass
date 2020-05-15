using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneOutChecker : MonoBehaviour
{
    [SerializeField] private Transform transform;

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("HandZone"))
        {
            Invoke("Reset", 2f);
        }
    }

    private void Reset()
    {
        gameObject.transform.position = transform.position;
        gameObject.transform.rotation = transform.rotation;
    }
}
