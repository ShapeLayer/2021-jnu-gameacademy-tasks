using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class TitleScene : MonoBehaviour, IPointerClickHandler
{



    public void OnPointerClick(PointerEventData eventData)
    {
        if(eventData.button == PointerEventData.InputButton.Left)
        {
            SceneManager.LoadScene("StageLobbyUI");
        }
    }

    void Start()
    {
    
    }



    void Update()
    {
        
    }
}
