using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Changer : MonoBehaviour
{
    [SerializeField] GameObject[] Camera;

    private void Start()
    {
        StartCoroutine(ChangeCamera());
    }

    IEnumerator ChangeCamera()
    {
        int i = 0;
        for(; ;)
        {
            if (i == Camera.Length)
            {
                i = 0;
                Camera[2].SetActive(false);
            }
            if(i < 1)
                Camera[i].SetActive(true);
            else
            {
                Camera[i-1].SetActive(false);
                Camera[i].SetActive(true);
            }
            
            i++;
            yield return new WaitForSeconds(4f);
        }
    }
}
