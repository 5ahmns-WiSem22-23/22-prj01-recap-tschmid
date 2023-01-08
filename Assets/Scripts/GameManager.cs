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

        //counter
        pickUpCount = 0;
    }

    void Update()
    {
        // delta time lässt von framerate unabhängigen counter zu
        time += Time.deltaTime;

        // läuft die zeit ab, läd die szene neu
        if (time >= timeMax)
        {
            SceneManager.LoadScene(0);
        }

        // timer und score werden als text angezeigt
        timer.text = Mathf.Round(timeMax - time).ToString() + " sec. übrig"; ;
        counter.text = "Score: " + pickUpCount.ToString();
    }
}
