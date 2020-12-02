using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// This class is very simple. It's only purpose is to retrieve the GameName from the CreditsAttributes base class.
/// </summary>
public class MainMenu : CreditsAttributes
{
    [SerializeField] Text Name;   
    void Start()
    {
        Name.text = GameName;
    }
}
