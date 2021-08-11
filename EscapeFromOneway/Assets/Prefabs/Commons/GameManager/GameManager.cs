using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    /// <summary>
    /// Call <c>GameManager.instance</c> when need to use <c>GameManager</c>.
    /// </summary>
    public static GameManager instance = null;
    public PlayerBridgeController playerBridgeController;

    private void Awake()
    {
        // Set GameManager unique.
        if (instance == null) instance = this;
        else if (instance != this) Destroy(this.gameObject);
        DontDestroyOnLoad(this.gameObject);
    }

    public string CharacterSelect = "Dino";
    public string GameResult;
    public int direction = 1000000;

    public void LoadScene(string id)
    {
        SceneManager.LoadScene(id);
    }
}
