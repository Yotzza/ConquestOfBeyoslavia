using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUIItemSelectionEnablerClass : MonoBehaviour
{
    // Start is called before the first frame update
    public int EquipmentLevel;//(ovo je od 0 ili 2)
    public int CurrentEquipment;//(ovo ide od 0 do 30)
    public Button myButton;
    void Awake()
    {
        
        var exists = PlayerDataClass.PlayerItemList.Contains(CurrentEquipment);
        Debug.Log(exists);
        if (exists==true){
            myButton.interactable = false;
            Debug.Log("god");
            
        }
        else{
            
            myButton.interactable = true;
        }
        
    }       



public void OnButtonPress()
{
//if (PlayerDataClass.PlayerItemList.Contains(CurrentEquipment))
//{
CharacterDataClass.CharacterItems[EquipmentLevel]=CurrentEquipment;
Debug.Log(CharacterDataClass.CharacterItems[0]);
Debug.Log(CharacterDataClass.CharacterItems[1]);
Debug.Log(CharacterDataClass.CharacterItems[2]);
SceneSwitchButtons.LoadInventory();
//}
}
}
