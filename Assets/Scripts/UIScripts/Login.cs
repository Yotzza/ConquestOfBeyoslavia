using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Login : MonoBehaviour
{
    public Text inputField;
    public Text usernametext;
    public Text continuetext;

    public void OnClick(){

        DatabaseManager.PasswordChecker(inputField.text,continuetext);
    }
    // Start is called before the first frame update
    void Start()
    {
        DatabaseManager.PlayerLoginScreen(usernametext);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
