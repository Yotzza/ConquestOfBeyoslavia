using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Register : MonoBehaviour
{

    public Text usernameinput;
    public Text passwordinput;
    public bool nez;
    public void OnClick(){
        if(usernameinput.text=="" || passwordinput.text==""){
            return;
        }
        else{
          nez=  DatabaseManager.PlayerUsernameChecker(usernameinput.text);
          if (nez==false){
            DatabaseManager.AddPlayerData(PlayerDataClass.PlayerID,0,"#ffffff",100,10,0,5,0,0,0,0,passwordinput.text,usernameinput.text,"000000000000000000000000000000");
            PlayerDataClass.PlayerFaceID=0;
            PlayerDataClass.PlayerColorHex="#ffffff";
            PlayerDataClass.PlayerHealth=100;
            PlayerDataClass.PlayerDamage=10;
            PlayerDataClass.PlayerSpeed=0;
            PlayerDataClass.PlayerExp=0;
            PlayerDataClass.PlayerStage=0;
            PlayerDataClass.PlayerSkillPoints=0;
            PlayerDataClass.PlayerLevel=0;
            SceneSwitchButtons.LoadLevelSelection();
          }
          else{
            Debug.Log("NAME TAKEN");
          }
        }
        

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
