using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBridgeController : MonoBehaviour
{
    public GameObject PlayerPrefab;
    public GameObject playerAudioObject;
    public int CurrentDirection;
    public bool isStartMoving = false;
    public bool isFalling = false;
    public bool isFalled = false;
    public bool isFinish = false;
    GameObject CloneObject;
    GameObject MainCamera;
    GameObject BackgroundAudioManager;
    Animator Animator;
    Collider2D isGround;
    MapConstructor MapConstructor;
    PlayerAudioManager playerAudioManager;

    [ContextMenu("Debug Init")]
    void Start()
    {
        isStartMoving = false;
        isFalling = false;
        isFinish = false;
        //Animator.Play();
        PlayerPrefab = LoadCharacter(GameManager.instance.CharacterSelect);
        CloneObject = Instantiate(PlayerPrefab) as GameObject;
        CloneObject.transform.SetParent(this.gameObject.transform);
        CloneObject.GetComponent<SpriteRenderer>().sortingLayerName = "Player";
        Animator = CloneObject.GetComponent<Animator>();
        MainCamera = GameObject.Find("Main Camera");
        BackgroundAudioManager = GameObject.Find("BackgroundAudioManager");
        MapConstructor = GameObject.Find("MapConstructor").GetComponent<MapConstructor>();
        playerAudioManager = playerAudioObject.GetComponent<PlayerAudioManager>();
        GameManager.instance.playerBridgeController = this;
    }

    void Update()
    {
        // Moving Player
        if (Input.GetKeyDown("up")) Move(0);
        else if (Input.GetKeyDown("right")) Move(1);
        else if (Input.GetKeyDown("left")) Move(-1);
        // Binding Camera
        BindToPlayer();
        // Playing Animation
        AnimationHandler();
    }

    void BindToPlayer()
    {
        if (!isFalling) {
            MainCamera.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, Config.DefaultMainCameraPositionZ);
            BackgroundAudioManager.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, AudioSourceConfig.TransformDefaultPositionZ);
        }
    }
    void AnimationHandler()
    {
        if (isStartMoving)
        {
            isGround = Physics2D.OverlapBox(transform.position, new Vector2(1, 1), 0f, 1 << 6);
            if (isGround) {
                string blockType = isGround.GetComponent<TileBridgeController>().TriggerDisappear();
                if (blockType == "finish") TriggerSuccess();
            }
            else TriggerFalling();
        }
    }

    GameObject LoadCharacter(string name)
    {
        PlayerPrefabLibrary library = gameObject.GetComponent<PlayerPrefabLibrary>();
        if (name == "Dino") return library.DinoCharacter;
        else if (name == "Dog") return library.DogCharacter;
        else if (name == "Spaceling") return library.SpacelingCharacter;
        else if (name == "Squirrel") return library.SquirrelCharacter;
        // fallback
        return library.DinoCharacter;
    }

    public void Move(int deltaDirection)
    {
        if (!isStartMoving) isStartMoving = true;
        if (!isFalling && !isFinish)
        {
            CurrentDirection = (CurrentDirection + deltaDirection) % 4;
            CurrentDirection = CurrentDirection < 0 ? CurrentDirection + 4 : CurrentDirection;
            TriggerMovePosition(CurrentDirection);
            TriggerMoveAnimation(CurrentDirection);
            TriggerMoveSound();
        }
        // Update MapConstructor BreakPoint
        MapConstructor.UpdateBreakPoint("player", CurrentDirection);
    }

    /// <summary>
    /// Move Player's position to specific direction
    /// </summary>
    void TriggerMovePosition(int direction)
    {
        Transform transform = this.gameObject.transform;
        if (direction == 0) transform.position = new Vector3(transform.position.x, transform.position.y + GameConstructorConfig.TileSizeOffset, 0);
        else if (direction == 1) transform.position = new Vector3(transform.position.x + GameConstructorConfig.TileSizeOffset, transform.position.y, 0);
        else if (direction == 2) transform.position = new Vector3(transform.position.x, transform.position.y - GameConstructorConfig.TileSizeOffset, 0);
        else if (direction == 3) transform.position = new Vector3(transform.position.x - GameConstructorConfig.TileSizeOffset, transform.position.y, 0);
    }

    void TriggerMoveAnimation(int direction)
    {
        if (direction == 1) CloneObject.transform.localScale = new Vector3(-1, 1, 1);
        else CloneObject.transform.localScale = new Vector3(1, 1, 1);
        Animator.SetInteger("direction", direction);
        Animator.SetTrigger("walk");
    }
    void TriggerMoveSound()
    {
        playerAudioManager.PlayOnMoveSound();
    }

    public void TriggerFalling()
    {
        if (!isFalling) playerAudioManager.PlayOnFallingSound();
        isFalling = true;
        CloneObject.GetComponent<Animator>().enabled = false;
        StartCoroutine(FallingEnumerator());
        StartCoroutine(GameEndingEnumerator());
    }
    IEnumerator FallingEnumerator()
    {
        yield return new WaitForSeconds(GameConstructorConfig.DelayTimeOnFalling);
        GetComponent<Rigidbody2D>().gravityScale = PlayerControlConfig.PlayerFallingGravity;
        yield return new WaitForSeconds(AudioSourceConfig.PlayerOnDieSoundTiming);
        if (!isFalled)
        {
            playerAudioManager.PlayOnDieSound();
            isFalled = true;
        }
        //transform.position = new Vector2(transform.position.x, transform.position.y - PlayerControlConfig.PlayerFallingParam * Time.deltaTime);
    }
    IEnumerator GameEndingEnumerator()
    {
        yield return new WaitForSeconds(GameConstructorConfig.DelayTimeOnFailed);
        GameManager.instance.GameResult = "Fail";
        GameManager.instance.LoadScene("StageFailResultUI");
    }
    
    public void TriggerSuccess()
    {
        if (!isFinish) playerAudioManager.PlayOnSuccessSound();
        isFinish = true;
        StartCoroutine(GameSuccessEnumerator());
        GameManager.instance.GameResult = "Success";

        List<string> UnlockedStages = UserDataManager.instance.UserData.UnlockedStages;
        List<string> ClearedStages = UserDataManager.instance.UserData.ClearedStages;
        string nowLevelID = IngameDataManager.instance.levelID;
        string nextLevelID = IngameDataManager.instance.level.nextLevelID;
        if (nextLevelID != "none" && UserDataManager.instance.UserData.UnlockedStages.FindIndex(x => x == nextLevelID) < 0)
        {
            UserDataManager.instance.UserData.UnlockedStages.Add(nextLevelID);
        }
        if (UserDataManager.instance.UserData.ClearedStages.FindIndex(x => x == nowLevelID) < 0)
        {
            UserDataManager.instance.UserData.ClearedStages.Add(nowLevelID);
        }
        UserDataManager.instance.SaveUserDataToBinaryStorage();
    }
    IEnumerator GameSuccessEnumerator()
    {
        yield return new WaitForSeconds(GameConstructorConfig.DelayTimeOnSuccess);
        GameManager.instance.LoadScene("StageSuccessResultUI");
    }

    // Debug Context Menu
    [ContextMenu("Debug Move 0")] void DebugMove0() { TriggerMoveAnimation(0); }
    [ContextMenu("Debug Move 1")] void DebugMove1() { TriggerMoveAnimation(1); }
    [ContextMenu("Debug Move 2")] void DebugMove2() { TriggerMoveAnimation(2); }
    [ContextMenu("Debug Move 3")] void DebugMove3() { TriggerMoveAnimation(3); }
}
