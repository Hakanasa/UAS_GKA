using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    GameObject count;
    public GameObject win;
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

        if(jumlah == 0)
        {
            GameObject.Find("Player/Idle").GetComponent<MovementTikus>().isPlaying = false;
            GameObject.Find("Player/Idle").GetComponent<Animator>().SetBool("run", false);
            GameObject.Find("Canvas/Timer").GetComponent<Timer>().isWin = true;
            win.SetActive(true);
        }
    }
}
