using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KnifeFix : MonoBehaviour
{
    
    public Image weaponbutton;

    void Start()
    {
        if(CharacterDataClass.CharacterItems[0]==0){
            weaponbutton.sprite=Resources.Load<Sprite>("Weapon/0");
            weaponbutton.type = Image.Type.Simple;
            weaponbutton.preserveAspect = true;
           
        }
    }


}
