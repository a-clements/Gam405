using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class ButtonEvents : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        switch(eventData.selectedObject.name)
        {
            case "Close":
                SceneManager.LoadSceneAsync("MainMenu");
                break;

            case "Play":
                SceneManager.LoadSceneAsync("Game");
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
                SceneManager.LoadSceneAsync("Credits");
                break;
        }
    }
}
