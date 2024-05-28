using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;

public class KVAZISKRIPTA : MonoBehaviour
{
    public SpriteRenderer PlayerHead;
    public SpriteRenderer PlayerBody;
    public SpriteRenderer PlayerRLeg;
    public SpriteRenderer PlayerLLeg;
    
    // Start is called before the first frame update
    void Start()
    {
        
        
        Color newcolor;
        ColorUtility.TryParseHtmlString(PlayerDataClass.PlayerColorHex, out newcolor);
            
                // Change the sprite color to the new color
                PlayerHead.sprite=PlayerDataClass.FaceImageChanger(PlayerDataClass.PlayerFaceID);
                PlayerHead.color = newcolor;
                PlayerBody.color = newcolor;
                PlayerRLeg.color = newcolor;
                PlayerLLeg.color = newcolor;
            

        
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
