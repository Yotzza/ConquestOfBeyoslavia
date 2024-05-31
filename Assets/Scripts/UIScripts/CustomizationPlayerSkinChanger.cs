using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CustomizationPlayerSkinChanger : MonoBehaviour
{

    public UnityEngine.UI.Image PlayerHead;
    public UnityEngine.UI.Image PlayerBody;
    public UnityEngine.UI.Image PlayerRLeg;
    public UnityEngine.UI.Image PlayerLLeg;
    // Start is called before the first frame update
    void Start()
    {
        Color newcolor;
        ColorUtility.TryParseHtmlString(PlayerDataClass.PlayerColorHex, out newcolor);
        PlayerHead.sprite=PlayerDataClass.FaceImageChanger(PlayerDataClass.PlayerFaceID);
        PlayerHead.color=newcolor;
        PlayerBody.color=newcolor;
        PlayerRLeg.color=newcolor;
        PlayerLLeg.color=newcolor;
    }

    // Update is called once per frame
    void Update()
    {
        Color newcolor;
        ColorUtility.TryParseHtmlString(PlayerDataClass.PlayerColorHex, out newcolor);
        PlayerHead.sprite=PlayerDataClass.FaceImageChanger(PlayerDataClass.PlayerFaceID);
        PlayerHead.color=newcolor;
        PlayerBody.color=newcolor;
        PlayerRLeg.color=newcolor;
        PlayerLLeg.color=newcolor;
    }
}
