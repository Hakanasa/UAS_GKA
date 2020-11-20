using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public GameObject GameObject;
    float speed = 10;
    // Start is called before the first frame update
    void Start()
    {
        GameObject.Find("Idle");
    }

    // Update is called once per frame
    void Update()
    {
        OrbitAround();
        StartCoroutine(ChangeTarget());
    }

    IEnumerator ChangeTarget()
    {
        string[] x = {"Idle", "House_Stone_2", "House_Wood"};

        for(int i = 0; i < x.Length; i++)
        {
            Debug.Log(x[i]);
            GameObject.Find(x[i]);
            yield return new WaitForSeconds(6f);
        }
    }

    void OrbitAround()
    {
        transform.RotateAround(GameObject.transform.position, Vector3.down, speed * Time.deltaTime);
    }
}
