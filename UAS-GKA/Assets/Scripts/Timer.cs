using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public float timetoDisplay = 720f;
    private Text timernya;
    private float minutes, seconds;
    public GameObject timeup, lose;
    public bool isWin = false;
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
            timeup.SetActive(true);
            lose.SetActive(true);
            GameObject.Find("Player/Idle").GetComponent<MovementTikus>().isPlaying = false;
            StartCoroutine(balikmain());
        }

        if(isWin == true)
        {
            timernya.text = string.Format("{0:00}:{1:00}", 0, 0);
            StartCoroutine(balikmain());
        }
    }

    IEnumerator balikmain()
    {
        yield return new WaitForSeconds(4f);
        SceneManager.LoadScene(0);
    }

    void DisplayTime()
    {
        minutes = Mathf.FloorToInt(timetoDisplay / 60);
        seconds = Mathf.FloorToInt(timetoDisplay % 60);

        timernya.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
