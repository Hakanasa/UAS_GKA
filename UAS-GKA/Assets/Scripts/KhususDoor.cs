using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KhususDoor : MonoBehaviour
{
    [SerializeField] Mesh mesh1;
    void Start()
    {
        this.GetComponent<MeshFilter>().mesh = mesh1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
