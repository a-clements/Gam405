using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemAttributes : MonoBehaviour
{
    /// <summary>
    /// This interface class inherits from Monobehaviour. This is so that the derived class can be attached to game objects. This class has a string and integer variables
    /// common to all items in the game.
    /// </summary>
    public string Type;
    public int PointValue;
    public int Speed;
}
