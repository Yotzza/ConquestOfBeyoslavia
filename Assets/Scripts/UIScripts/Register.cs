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
        if(usernameinput.text==""){
            return;
        }
        else{
          nez=  DatabaseManager.PlayerUsernameChecker(usernameinput.text);
          Debug.Log(nez);
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
