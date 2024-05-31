using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeathScene : MonoBehaviour
{

    public Text text1;
    // Start is called before the first frame update
    void Start()
    {
        text1.text="Stage: " + (CharacterDataClass.CharacterStage + 1).ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
