using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class SkillUpgrade : MonoBehaviour
{
    //1-health,2-damage,3-armor.4-speed
    public int SkillGroup;
    public  Text text1;
    private bool debounce=false;
    
    void Start()
    {
        TextChanger();
        
    }

    public void TextChanger(){
        switch (SkillGroup)
        {
            case 1:
                text1.text=PlayerDataClass.PlayerHealth + "+ Eq(" + CharacterDataClass.GetCharacterEquipmentSkills(SkillGroup) + ")";
                break;
            case 2:
                text1.text=PlayerDataClass.PlayerDamage + "+ Eq(" + CharacterDataClass.GetCharacterEquipmentSkills(SkillGroup) + ")";
                break;
            case 3:
                text1.text=PlayerDataClass.PlayerArmor + "+ Eq(" + CharacterDataClass.GetCharacterEquipmentSkills(SkillGroup) + ")";
                break;
            case 4:
                text1.text=PlayerDataClass.PlayerSpeed + "+ Eq(" + CharacterDataClass.GetCharacterEquipmentSkills(SkillGroup) + ")";
                break;
            default:
                Debug.LogWarning("Unknown SkillGroup: " + SkillGroup);
                break;
        }
    }

    public void SkillUp(){
      
    if (debounce==false)
        {
        debounce=true;
        if (PlayerDataClass.PlayerSkillPoints>=1)
{
    switch (SkillGroup)
    {
        case 1:
            PlayerDataClass.PlayerHealth+=10;
            break;
        case 2:
            PlayerDataClass.PlayerDamage+=2;
            break;
        case 3:
            PlayerDataClass.PlayerArmor+=1;
            break;
        case 4:
             PlayerDataClass.PlayerSpeed+=1;
             break;
        default:
            Debug.Log("Default case");
            break;
            
            
    }


}
else
{

}
        }
    }

}