using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class ButtonEvents : MonoBehaviour, IPointerClickHandler
{
    /// <summary>
    /// This class inherits from both MonoBehaviour and IPointerClickHander. MonoBehaviour allows this script to be attached to game objects. By inheriting from the
    /// IPointerClickHandler interface, I have bypassed the inspector and called the functionality directly. This script can be placed on any button within a
    /// scene. The function takes a parameter called eventData, of the type PointerEventData. Using a switch statement I am checking the name of the selected object.
    /// If the name of the selected object matches a case, then code is executed. This is extensible by adding more cases to the switch statement.
    /// </summary>
    /// <param name="eventData"></param>
    public void OnPointerClick(PointerEventData eventData)
    {
        switch(eventData.selectedObject.name)
        {
            case "Close":
                SceneManager.LoadSceneAsync("MainMenu", LoadSceneMode.Single);
                break;

            case "Play":
                SceneManager.LoadSceneAsync("Game", LoadSceneMode.Single);
                break;

            case "Exit":
                    #if UNITY_STANDALONE
                                    Application.Quit();
                    #endif

                    #if UNITY_EDITOR
                                    UnityEditor.EditorApplication.isPlaying = false;
                    #endif
                break;

            case "Credits":
                SceneManager.LoadSceneAsync("Credits", LoadSceneMode.Single);
                break;
        }
    }
}
