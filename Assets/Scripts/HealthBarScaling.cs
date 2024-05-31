using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarScaling : MonoBehaviour
{
    public UnityEngine.UI.Image targetImage;
    public Text uiText;
    public void changer()
    {
        uiText.text = CharacterDataClass.CharacterHealth + "/" + (PlayerDataClass.PlayerHealth + CharacterDataClass.GetCharacterEquipmentSkills(1));
        
        targetImage.fillAmount = (float)CharacterDataClass.CharacterHealth / (PlayerDataClass.PlayerHealth + CharacterDataClass.GetCharacterEquipmentSkills(1));

    }


    // Update is called once per frame
    void Update()
    {
        changer();
    }
}