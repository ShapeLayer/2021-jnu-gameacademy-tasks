using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OverlaySceneLoader : MonoBehaviour
{
    void Start()
    {
        SceneManager.LoadScene("StageIngameUI", LoadSceneMode.Additive);
    }
}
