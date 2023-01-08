using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int pickUpCount;
    float time;
    public float timeMax;
    public Text timer;
    public Text counter;

    private void Start()
    {
        pickUpCount = 0;
    }

    void Update()
    {
        // Über die Delta Time kann unabhängig von der FrameRate ein Timer gebaut werden
        time += Time.deltaTime;

        // Wenn die Zeit abgelaufen ist, soll das Spiel neu beginnen
        if (time >= timeMax)
        {
            SceneManager.LoadScene(0);
        }

        // Der Timer und der Score sollen jeden Frame angezeigt werden
        timer.text = Mathf.Round(timeMax - time).ToString() + " sec. übrig"; ;
        counter.text = "Score: " + pickUpCount.ToString();
    }
}
