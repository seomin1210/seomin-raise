using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoSingleton<GameManager>
{
    [SerializeField]
    private User user = null;
    public User CurrentUser
    {
        get
        {
            return user;
        }
    }

    private UiManager uiManager;
    public UiManager UI
    {
        get
        {
            if (uiManager == null)
            {
                uiManager = GetComponent<UiManager>();
            }
            return uiManager;
        }
    }
    private Canvas canvas = null;
    public Canvas Canvas
    {
        get
        {
            if (canvas == null)
            {
                canvas = FindObjectOfType<Canvas>();
            }
            return canvas;
        }
    }
    private ButtonManager buttonm = null;
    public ButtonManager Buttonm
    {
        get
        {
            if (buttonm == null)
            {
                buttonm = FindObjectOfType<ButtonManager>();
            }
            return buttonm;
        }
    }

    private string SAVE_PATH = "";
    private string SAVE_FILENAME = "/SaveFile.txt";
    private bool bPaused = false;
    private bool bEsc = false;
    public bool bOther = false;
    private void Awake()
    {
        SAVE_PATH = Application.dataPath + "/Save";
        if (!Directory.Exists(SAVE_PATH))
        {
            Directory.CreateDirectory(SAVE_PATH);
        }
    }
    private void Start()
    {
        LoadFromJson();
        InvokeRepeating("SaveToJson", 1f, 60f);
        InvokeRepeating("EarnMoneyPerSecond", 0f, 1f);
    }
    private void Update()
    {
        if (Input.GetKeyDown("escape"))
        {
            if (bOther)
            {
                Buttonm.OnClickCloseWorkList();
                return;
            }
            if (bEsc)
            {
                Buttonm.OnClickCloseSettingPanel();
                bEsc = false;
                return;
            }
            Buttonm.OpenSettingPanel();
            bEsc = true;
        }
        if (Input.GetKey(KeyCode.LeftShift))
        {
            EarnMoneyPerSecond();
            UI.OnClickImage();
        }
    }
    private void LoadFromJson()
    {
        if (File.Exists(SAVE_PATH + SAVE_FILENAME))
        {
            string json = File.ReadAllText(SAVE_PATH + SAVE_FILENAME);
            user = JsonUtility.FromJson<User>(json);
        }
    }
    private void SaveToJson()
    {
        string json = JsonUtility.ToJson(user, true);
        File.WriteAllText(SAVE_PATH + SAVE_FILENAME, json, System.Text.Encoding.UTF8);
    }
    private void OnApplicationQuit()
    {
        SaveToJson();
    }
    private void OnApplicationPause(bool pause)
    {
        if (pause)
        {
            bPaused = true;
            SaveToJson();
        }
        else
        {
            if (bPaused)
            {
                bPaused = false;
                LoadFromJson();
            }
        }
    }
    private void EarnMoneyPerSecond()
    {
        user.money += (int)(user.userDex*1.5) + user.userJobs;
        UI.UpdateMoneyPanel();
    }
}
