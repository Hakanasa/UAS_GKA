using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float timetoDisplay = 360f;
    private Text timernya;
    private float minutes, seconds;
    // Start is called before the first frame update
    void Start()
    {
        timernya = this.gameObject.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if(timetoDisplay > 0)
        {
            timetoDisplay -= Time.deltaTime;
            DisplayTime();
        }
        else
        {
            timernya.text = string.Format("{0:00}:{1:00}", 0, 0);
            Time.timeScale = 0;
        }
    }

    void DisplayTime()
    {
        minutes = Mathf.FloorToInt(timetoDisplay / 60);
        seconds = Mathf.FloorToInt(timetoDisplay % 60);

        timernya.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
