using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PlayManager : MonoBehaviour
{
    float elapsedTime = -1.0f;

    public TextMeshProUGUI elapsedText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        elapsedTime += Time.deltaTime;
        int timeInSeconds = (int)elapsedTime;
        int minutes = timeInSeconds / 60;
        int seconds = timeInSeconds - (minutes * 60);
        elapsedText.SetText(elapsedTime < 0.0f ? "--:--" : minutes.ToString("D2") + ":" + seconds.ToString("D2"));

    }
}
