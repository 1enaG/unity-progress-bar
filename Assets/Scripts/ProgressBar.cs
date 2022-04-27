using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    Slider slider;
    Text progressText; 

    float targetProgress; // 0 
    public float fillSpeed; // how fast the progress bar fills to new value

    public float maxProgress; // set in editor // 100 
    public float incrProgress; // 10 

    public Color32 fillColor; 
    private void Awake()
    {
        slider = GetComponent<Slider>();    
        progressText = GameObject.Find("ProgressText").GetComponent<Text>();
        slider.transform.GetChild(1).GetChild(0).GetComponent<Image>().color = fillColor; 
    }

    void Start()
    {
        targetProgress = 0; //at the beginning of the game

        if (!valuesAreValid())
        {
            maxProgress = 100;
            incrProgress = 10;
            fillSpeed = 30; 
        }

        slider.minValue = 0;
        slider.maxValue = maxProgress; //given in editor TODO: add a check!

        

        // for testing purposes. 
        //IncrementProgress(); 
    }


    void Update()
    {
        if(slider.value < targetProgress)
        {
            slider.value += fillSpeed * Time.deltaTime; 
        }
        progressText.text = targetProgress + "/" + maxProgress; 
    }

    public void IncrementProgress()
    {
        //slider.value += progress; // we need to animate this to fill in gradually, not just snap to new value 
        targetProgress += incrProgress;   
    }

    bool valuesAreValid()
    {
        return (maxProgress > incrProgress) && (maxProgress % incrProgress == 0); 
    }
}
