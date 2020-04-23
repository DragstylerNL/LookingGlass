using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishMovement : MonoBehaviour
{
    [SerializeField] private GameObject fish;
    [SerializeField] private Transform minBox;
    [SerializeField] private Transform maxBox;
    [SerializeField] private float speed = 0.05f;
    [SerializeField] private float rocketSpeedMultiplier = 3;
    
    private Vector3 _target;
    private Vector3 _heading;
    private Vector3 _direction;
    private float _directionLength;
    private float _finalSpeed;
    private float _finalRocketSpeedMultiplier;
    
    void Start()
    {
        GetNewTarget();
    }

    void Update()
    {
        if (Input.GetMouseButton(0)) _finalSpeed = speed * rocketSpeedMultiplier;
        else _finalSpeed = speed;
        
        UpdateDirection();
        
        if (CheckOutOfBounce()) fish.transform.position = Vector3.zero; 
        
        if (_heading.sqrMagnitude <= _finalSpeed * _finalSpeed) GetNewTarget();
        else
        {
            fish.transform.position += _direction * _finalSpeed;
        }
    }

    private void GetNewTarget()
    {
        _target = new Vector3(Random.Range(minBox.position.x, maxBox.position.x), Random.Range(minBox.position.y, maxBox.position.y), Random.Range(minBox.position.z, maxBox.position.z));
    }

    private void UpdateDirection()
    {
        _heading = _target - fish.transform.position;
        _directionLength = _heading.magnitude;
        _direction = _heading / _directionLength;
    }
    
    private bool CheckOutOfBounce()
    {
        bool checkX = (fish.transform.position.x > maxBox.position.x || fish.transform.position.x < minBox.position.x);
        bool checkY = (fish.transform.position.y > maxBox.position.y || fish.transform.position.y < minBox.position.y);
        bool checkZ = (fish.transform.position.z > maxBox.position.z || fish.transform.position.z < minBox.position.z);
        return (checkX || checkY || checkZ);
    }
}
