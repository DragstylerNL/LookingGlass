using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Leap.Unity.Interaction;
using UnityEngine;
using UnityEngine.Serialization;

public class CubeSpawner : MonoBehaviour
{
    [SerializeField] private GameObject cube;
    [SerializeField] private float spawnSpeed;
    [SerializeField] private float destroySpeed;
    [SerializeField] private InteractionManager manager;

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
        newCube.GetComponent<InteractionBehaviour>().manager = manager;
        Destroy(newCube, destroySpeed);
    }
}
