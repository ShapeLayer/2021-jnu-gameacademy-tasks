using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{

    public void ChangeSceneChallengeLobbyBtn()   //챌린지모드 로비화면
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

    public void ChangeSceneStageLobbyBtn()   //스테이지모드 로비화면
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
        }
    }

    public void ChangeSceneChallengeResultBtn() //챌린지모드 결과화면
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

    public void ChangeSceneStageResultBtn() //스테이지모드 결과화면
    {
        switch (this.gameObject.name)
        {
            case "RetryButton":
                SceneManager.LoadScene("StageIngameUI");
                break;
            case "HomeButton":
                SceneManager.LoadScene("StageLobbyUI");
                break;
            case "NextStageButton":
                SceneManager.LoadScene("StageIngameUI");
                break;
        }
    }

    public void ChangeSceneChallengeIngameBtn()  //챌린지모드인게임 화면
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

    public void ChangeSceneStageIngameBtn()  //스테이지모드인게임 화면
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
                SceneManager.LoadScene("StagePauseMenuUI");
                break;
        }
    }

    public void ChangeSceneChallengePauseMenuBtn()  //챌린지모드 일시정지메뉴
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

    public void ChangeSceneStagePauseMenuBtn()  //스테이지모드 일시정지메뉴
    {
        switch (this.gameObject.name)
        {
            case "PlayButton":
                SceneManager.LoadScene("StageIngameUI");
                break;
            case "HomeButton":
                SceneManager.LoadScene("StageLobbyUI");
                break;
            case "RetryButton":
                SceneManager.LoadScene("StageIngameUI");
                break;
            case "StageSelectButton":
                SceneManager.LoadScene("StageSelectUI");
                break;
        }
    }

    public void ChangeSceneStageSelectBtn() //스테이지선택
    {
        switch (this.gameObject.name)
        {
            case "Stage1Button":
                SceneManager.LoadScene("CharacterControl");
                //SceneManager.LoadScene("StageIngameUI");
                break;
            case "Stage2Button":
                SceneManager.LoadScene("StageIngameUI");
                break;
            case "Stage3Button":
                SceneManager.LoadScene("StageIngameUI");
                break;
            
        }
    }

    public void ChangeSceneModeChangeBtn()  //모드선택 화면
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
}
