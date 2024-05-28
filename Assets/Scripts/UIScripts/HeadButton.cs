using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadButton : MonoBehaviour
{
    public int i;
    
    public void FaceChanger(){
        PlayerDataClass.PlayerFaceID=i;
    }
}
