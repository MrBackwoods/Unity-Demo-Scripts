using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public static class AppManager 
{
    static int score = 0;

    public static void StartScene(Image fadeInImage = null, bool resetScore = true, MonoBehaviour instance = null)
    {
        if (fadeInImage != null && instance != null) 
        {
            instance.StartCoroutine(FadeIn(fadeInImage));
        }

        if (resetScore) 
        {
            SetScore(0);
        }
    }
 
    public static void LoadScene(int scene, Image fadeInImage = null, MonoBehaviour instance = null)
    {
        DebugLog("Loading scene " + scene);

        if (fadeInImage != null && instance != null) 
        {
            instance.StartCoroutine(FadeOut(fadeInImage, scene));  
        }

        else
        {
           SceneManager.LoadScene(scene);
        }
    }

    static IEnumerator FadeIn(Image image)
    {
        DebugLog("Fading in");
        
        for (float a = 1; a >= 0; a -= Time.deltaTime)
        {
            image.color = new Color(image.color.r, image.color.g, image.color.b, a);
            yield return null;
        }
    }

    static IEnumerator FadeOut(Image image, int? loadNextScene = null) 
    {
        DebugLog("Fading out");

        for (float a = 0; a <= 1; a += Time.deltaTime)
        {
            image.color = new Color(image.color.r, image.color.g, image.color.b, a);
            yield return null;
        }

        if (loadNextScene != null) 
        {
            SceneManager.LoadScene((int)loadNextScene);
        }
    }

    public static void QuitGame()
    {
        DebugLog("Quitting game");
        Application.Quit();
    }

    public static float GetVolume()
    {
        return AudioListener.volume;
    }

    public static void SetVolume(float volume)
    {
        DebugLog("Setting volume to " + volume);
        AudioListener.volume = volume;
    }

    public static int GetScore()
    {
        return score;
    }

    public static void SetScore(int newScore)
    {
        DebugLog("Setting score to " + newScore);
        score = newScore;
    } 

    public static void AddScore(int addToScore)
    {
        DebugLog("Adding " + addToScore + " to score");
        score += addToScore;
    } 

    public static void DebugLog(string log) 
    {
    #if UNITY_EDITOR	
        Debug.Log(log);
    #endif
    }
}

