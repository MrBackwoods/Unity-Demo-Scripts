using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

// Simple management for escape key and quitting the game
public class EscapeHandler : MonoBehaviour
{
    public bool quitOnEsc;

    [Space(10)] 

    public bool toggleCanvasObjectOnEsc;
    public GameObject escCanvasObject;

    [Space(10)] 

    public bool toggleCanvasComponentOnEsc;
    public Canvas escCanvasComponent;

    [Space(10)] 

    public bool changeSceneOnEsc;
    public int escScene;

    [Space(10)] 

    public bool invokeFunctionOnEsc;
    public string escFunction;

    [Space(10)] 

    public Image fadeOutImage;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Escape();
        }
    }

    void Escape() 
    {
        // Quit game
        if (quitOnEsc) 
        {
            AppManager.QuitGame();
        }

        // Enable or disable canvas object
        if (toggleCanvasObjectOnEsc)
        {
            if (escCanvasObject.activeSelf)
            {
                escCanvasObject.SetActive(false);
            }

            else
            {
                escCanvasObject.SetActive(true);
            }
        }

        // Enable or disable canvas component
        if (toggleCanvasComponentOnEsc) 
        {
            if (escCanvasComponent.enabled)
            {
                escCanvasComponent.enabled = false;
            }

            else
            {
                escCanvasComponent.enabled = true;
            }
        }

        // Load scene
        if (changeSceneOnEsc) 
        {
            AppManager.LoadScene(escScene, fadeOutImage, this);
        }

        // Invoke a function
        if (invokeFunctionOnEsc) 
        {
            Invoke(escFunction, 0);
        }
    }
}
