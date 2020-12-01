using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Show : MonoBehaviour
{
    void Start()
    {
        iTween.ScaleTo(this.gameObject, new Vector3(1, 1, 1), 1f);
    }
}
