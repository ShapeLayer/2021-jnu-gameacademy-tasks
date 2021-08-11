using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{

    public void ChangeSceneChallengeLobbyBtn()   //ç������� �κ�ȭ��
    {
        switch (this.gameObject.name)
        {
            case "ModeChangeButton":
                SceneManager.LoadScene("ModeChangeUI");
                break;
            case "PlayButton":
                SceneManager.LoadScene("ChallengeIngameUI");
                break;
            case "CharacterSelectButton":
                SceneManager.LoadScene("CharacterSelectUI");
                break;
        }
    }

    public void ChangeSceneStageLobbyBtn()   //StageMode LobbyScene 
    {
        switch (this.gameObject.name)
        {
            case "ModeChangeButton":
                SceneManager.LoadScene("ModeChangeUI");
                break;
            case "PlayButton":
                SceneManager.LoadScene("StageSelectUI");
                break;
            case "CharacterSelectButton":
                SceneManager.LoadScene("CharacterSelectUI");
                break;
            case "PowerButton":
                Application.Quit();
                break;
        }
    }

    public void ChangeSceneChallengeResultBtn() //ç������� ���ȭ��
    {
        switch (this.gameObject.name)
        {
            case "RetryButton":
                SceneManager.LoadScene("ChallengeIngameUI");
                break;
            case "HomeButton":
                SceneManager.LoadScene("ChallengeLobbyUI");
                break;
        }
    }

    public void ChangeSceneStageResultBtn() // StageMode ResultScene
    {
        switch (this.gameObject.name)
        {
            case "RetryButton":
                IngameDataManager.instance.LoadLevel(IngameDataManager.instance.levelID);
                GameManager.instance.LoadScene("Ingame");
                break;
            case "HomeButton":
                SceneManager.LoadScene("StageLobbyUI");
                break;
            case "NextStageButton":
                IngameDataManager.instance.LoadLevel(IngameDataManager.instance.level.nextLevelID);
                GameManager.instance.LoadScene("Ingame");
                break;
        }
    }

    public void ChangeSceneChallengeIngameBtn()  //ç��������ΰ��� ȭ��
    {
        switch (this.gameObject.name)
        {
            case "LeftButton":
            
                break;
            case "UpButton":

                break;
            case "RightButton":
                
                break;
            case "PauseButton":
                SceneManager.LoadScene("ChallengePauseMenuUI");
                break;
        }
    }

    public void ChangeSceneStageIngameBtn()  //StageMode Ingame Scene 
    {
        switch (this.gameObject.name)
        {
            case "LeftButton":

                break;
            case "UpButton":

                break;
            case "RightButton":

                break;
            case "PauseButton":
                   SceneManager.LoadScene("StagePauseMenuUI", LoadSceneMode.Additive);
                   Time.timeScale = 0;
                break;
        }
    }

    public void ChangeSceneChallengePauseMenuBtn()  //ç������� �Ͻ������޴�
    {
        switch (this.gameObject.name)
        {
            case "PlayButton":
                SceneManager.LoadScene("ChallengeIngameUI");
                break;
            case "HomeButton":
                SceneManager.LoadScene("ChallengeLobbyUI");
                break;
            case "RetryButton":
                SceneManager.LoadScene("ChallengeIngameUI");
                break;
        }
    }

    public void ChangeSceneStagePauseMenuBtn()  //StageMode PauseMenu 
    {
        switch (this.gameObject.name)
        {
            case "PlayButton":
                SceneManager.UnloadSceneAsync("StagePauseMenuUI");
                Time.timeScale = 1;
                break;
            case "HomeButton":
                SceneManager.LoadScene("StageLobbyUI");
                break;
            case "RetryButton":
                SceneManager.LoadScene("Ingame");
                break;
            case "StageSelectButton":
                SceneManager.LoadScene("StageSelectUI");
                break;
        }
    }

    public void ChangeSceneStageSelectBtn() //Stege Select
    {
        switch (this.gameObject.name)
        {
            case "Stage1Button":
                SceneManager.LoadScene("CharacterControl");
                break;
            case "Stage2Button":
                SceneManager.LoadScene("StageIngameUI");
                break;
            case "Stage3Button":
                SceneManager.LoadScene("StageIngameUI");
                break;
            
        }
    }

    public void ChangeSceneModeChangeBtn()  //��弱�� ȭ��
    {
        switch (this.gameObject.name)
        {
            case "StageModeButton":
                SceneManager.LoadScene("StageLobbyUI");
                break;
            case "ChallengeModeButton":
                SceneManager.LoadScene("ChallengeLobbyUI");
                break;
        }
    }

    public void CharacterSelectUI() //Character Select
    {
        switch (this.gameObject.name)
        {
            case "HomeButton":
                SceneManager.LoadScene("StageLobbyUI");
                break;
        }
    }

    public void HomeButtonTrigger()
    {
        SceneManager.LoadScene("StageLobbyUI");
    }
}
