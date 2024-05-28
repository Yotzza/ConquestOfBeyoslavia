using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class RaceButton : MonoBehaviour
{

    public string HexColor;

    public void OnPressed(){
        PlayerDataClass.PlayerColorHex=HexColor;
        Debug.Log(PlayerDataClass.PlayerColorHex);

    }
}
