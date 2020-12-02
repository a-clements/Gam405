using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Credits : CreditsAttributes
{
    /// <summary>
    /// This class inherits from the CreditsAttributes class. In this class I am setting the text of Text Objects from the attributes in the CreditsAttributes class.
    /// </summary>
    [SerializeField] private Text Name;
    [SerializeField] private Text ProgrammerName;
    [SerializeField] private Text ArtistName;
    [SerializeField] private Text AudioName;
    [SerializeField] private Button CloseButton;

    private void Start()
    {
        Name.text = GameName;
        ProgrammerName.text = Programmer;
        ArtistName.text = Art;
        AudioName.text = Audio;
    }
}
