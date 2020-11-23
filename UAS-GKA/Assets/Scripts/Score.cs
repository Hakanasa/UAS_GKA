using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    GameObject count;
    int jumlah;
    // Start is called before the first frame update
    void Start()
    {
       jumlah = (GameObject.FindGameObjectsWithTag("Cheese").Length);
        count = GameObject.Find("Canvas/Left");
    }

    // Update is called once per frame
    void Update()
    {
        jumlah = (GameObject.FindGameObjectsWithTag("Cheese").Length);
        count.GetComponent<Text>().text = jumlah.ToString();
    }
}
