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

    public void ChangeSceneStageLobbyBtn()   //����������� �κ�ȭ��
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

    public void ChangeSceneStageResultBtn() //����������� ���ȭ��
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

    public void ChangeSceneStageIngameBtn()  //������������ΰ��� ȭ��
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

    public void ChangeSceneStagePauseMenuBtn()  //����������� �Ͻ������޴�
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

    public void ChangeSceneStageSelectBtn() //������������
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
}
