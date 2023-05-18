using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.SceneManagement;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public string sceneName;

    //Function that loads into a scene

    public void LoadScene()
    {
        SceneManager.LoadScene(sceneName);
    }
}
