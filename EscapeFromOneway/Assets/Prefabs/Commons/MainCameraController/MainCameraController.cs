using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainCameraController : MonoBehaviour
{
    public static MainCameraController instance = null;
    void Awake()
    {
        if (instance == null) instance = this;
        else if (instance != this) Destroy(this.gameObject);
        DontDestroyOnLoad(this.gameObject);
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    void Start()
    {
        SetDefaultBackgroundColor();
    }
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if ($"{mode}" == "Single") SetDefaultBackgroundColor();
    }
    void SetDefaultBackgroundColor()
    {
        Camera.main.backgroundColor = new Color32(
            GameConstructorConfig.MainCameraBackgroundColor[0],
            GameConstructorConfig.MainCameraBackgroundColor[1],
            GameConstructorConfig.MainCameraBackgroundColor[2],
            GameConstructorConfig.MainCameraBackgroundColor[3]
        );
    }
}
