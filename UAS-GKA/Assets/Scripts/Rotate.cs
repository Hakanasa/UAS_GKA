using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public GameObject GameObject;
    float speed = 10;

    void Update()
    {
        OrbitAround();
    }

    void OrbitAround()
    {
        transform.RotateAround(GameObject.transform.position, Vector3.down, speed * Time.deltaTime);
    }
}
