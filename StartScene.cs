using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartScene : MonoBehaviour
{
    public Image fadeImage;
    public bool resetScore;

    void Start()
    {
        AppManager.StartScene(fadeImage, resetScore, this);
    }
}
