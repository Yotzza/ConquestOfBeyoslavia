using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using UnityEngine.UI;

public class BarScaling : MonoBehaviour
{
    public UnityEngine.UI.Image targetImage;
    public Text uiText;
   public void changer(){
    uiText.text=PlayerDataClass.PlayerExp + "/1000";
    //Debug.Log((float)CharacterDataClass.CharacterHealth/PlayerDataClass.PlayerHealth);
    targetImage.fillAmount=(float)PlayerDataClass.PlayerExp/1000;

   }
    

    // Update is called once per frame
    void Update()
    {   
        changer();
    }
}
