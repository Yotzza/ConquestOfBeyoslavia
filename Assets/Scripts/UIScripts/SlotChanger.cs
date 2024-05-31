using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SlotChanger : MonoBehaviour
{

    public int PlayerID;
    bool Used;
    public Image SlotImage;
    public Text SlotText;


    public void Click(){
        PlayerDataClass.PlayerID=PlayerID;
        if (Used==false){
            Debug.Log(PlayerDataClass.PlayerID);
            Debug.Log("non used slot");
            SceneSwitchButtons.LoadRegister();
            
                       
        }
        else if(Used==true){
            Debug.Log(PlayerDataClass.PlayerID);
            Debug.Log("USED slot");
            SceneSwitchButtons.LoadLogin();
        }
    }

    public void ClickDelete(){
        //PlayerDataClass.PlayerID=PlayerID;
        if (Used==false){
            //Debug.Log(PlayerDataClass.PlayerID);
            Debug.Log("non used slot");
            //SceneSwitchButtons.LoadRegister();
            
                       
        }
        else if(Used==true){
            //Debug.Log(PlayerDataClass.PlayerID);
            Debug.Log("USED slot");
            DatabaseManager.DeletePlayer(PlayerID);
            DatabaseManager.SlotsOccupancy(PlayerID,SlotImage,SlotText);
            Used=false;

        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
        Used=DatabaseManager.SlotsOccupancy(PlayerID,SlotImage,SlotText);
            
        
        Debug.Log(Used);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
