using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    [SerializeField] private GameObject cube;
    [SerializeField] private float spawnSpeed;
    [SerializeField] private float destroySpeed;

    private float timer = 0f;

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnSpeed)
        {
            timer = 0;
            SpawnCube();
        }
    }

    private void SpawnCube()
    {
        GameObject newCube = Instantiate(cube, transform.position, transform.rotation);
        Destroy(newCube, destroySpeed);
    }
}
