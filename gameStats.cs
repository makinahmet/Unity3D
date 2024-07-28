using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class gameStats : MonoBehaviour
{
    public TextMeshProUGUI fpsText;
    private float currentFpsTime = 0;
    private int fpsCounter = 0;

    void Update()
    {
        currentFpsTime = currentFpsTime + Time.deltaTime;
        fpsCounter++;

        if(currentFpsTime > 1){
            fpsText.text ="FPS : " +  fpsCounter.ToString();
            currentFpsTime = 0;
            fpsCounter = 0;
        }        
    }
}
