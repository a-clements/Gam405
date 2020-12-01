using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : CreditsAttributes
{
    [SerializeField] Text Name;   
    void Start()
    {
        Name.text = GameName;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
