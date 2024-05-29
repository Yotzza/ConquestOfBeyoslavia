using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;
using System;

public class LevelManager : MonoBehaviour
{
    public Text timertext;
    public Text leveltext;
    public float time=30;
    public float currentTime;
    
    
    void Start()
    {
        CharacterDataClass.SetCharacterData();
        currentTime=time;
        
    }

    // Update is called once per frame
    void Update()
    {
        CheckCharacterHealth();
        currentTime-=Time.deltaTime;
        WaveTimer();
        
    }

    void CheckCharacterHealth(){
        if (CharacterDataClass.CharacterHealth<=0){
            SceneSwitchButtons.LoadYouDiedScene();
        }
   
   
    
    }

    public void WaveTimer(){
        

        if (currentTime>10){
            timertext.color=Color.white;
        }
        else if(currentTime>0 && currentTime<=10)
        {
            timertext.color=Color.red;

        }
        else{
            //SceneSwitchButtons.LoadStageClear();
            SceneSwitchButtons.LoadStageClear();
        }
        
        timertext.text=Mathf.FloorToInt(currentTime).ToString();
        
       
        
        
        
        
    }
}
