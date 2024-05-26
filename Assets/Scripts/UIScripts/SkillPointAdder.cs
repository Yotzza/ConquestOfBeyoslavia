using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class NewBehaviourScript : MonoBehaviour
{
    // ako je 0 exp gleda ako je 1 points gleda
    public int i;
    public Text uiText;

    void Start(){

        if (i==0){
            uiText.text="Experience: "+ PlayerDataClass.PlayerExp + "/1000";


        }
        else if(i==1){
            uiText.text="Available Skills Points: "+ PlayerDataClass.PlayerSkillPoints;

        }

    }
}
