using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject Trap;
    [SerializeField] Transform[] Target;

    private void Start()
    {
        for (int i = 0; i < Target.Length; i++)
        {
            string x = "GameObject (" + i + ")";
            Target[i] = GameObject.Find(x).transform;
        }

        for (int i = 0; i < Target.Length; i++)
        {
            GameObject x = Instantiate(Trap, Target[i].position, Trap.transform.rotation);
            x.transform.SetParent(Target[i].transform); 
        }
    }
}
