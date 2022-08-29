using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    public static SaveManager Instance { set; get; }
    public SaveState state;

    public int levelNow;

    private void Awake()
    {
        Instance = this;
        Load();
        LoadOnFirst();

        //Debug.Log(Helper.Serialize<SaveState>(state));
    }

    public void LoadOnFirst()
    {
        levelNow = state.levelNow;
    }

    public void Save()
    {
        PlayerPrefs.SetString("save", Helper.Serialize<SaveState>(state));
    }

    public void Load()
    {
        if (PlayerPrefs.HasKey("save"))
        {
            state = Helper.Deserilize<SaveState>(PlayerPrefs.GetString("save"));
        }
        else
        {
            state = new SaveState();
            Save();
            Debug.Log("File Not Found, Make a New Save Game");
        }
    }

}
