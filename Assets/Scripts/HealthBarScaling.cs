using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarScaling : MonoBehaviour
{
    public UnityEngine.UI.Image targetImage;
    public Text uiText;
    public void changer()
    {
        uiText.text = CharacterDataClass.CharacterHealth + "/" + PlayerDataClass.PlayerHealth;
        Debug.Log((float)CharacterDataClass.CharacterHealth / PlayerDataClass.PlayerHealth);
        targetImage.fillAmount = (float)CharacterDataClass.CharacterHealth / PlayerDataClass.PlayerHealth;

    }


    // Update is called once per frame
    void Update()
    {
        changer();
    }
}