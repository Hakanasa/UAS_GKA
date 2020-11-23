using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetParent : MonoBehaviour
{
    [SerializeField] Transform Target;

    private void Start()
    {
        this.transform.SetParent(Target);
    }
}
