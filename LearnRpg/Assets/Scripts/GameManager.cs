using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private void Awake()
    {
        if (GameManager.instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        SceneManager.sceneLoaded += LoadState;
        DontDestroyOnLoad(gameObject);
        
    }

    //Resources
    public List<Sprite> PlayerSprites;
    public List<Sprite> weaponSprites;
    public List<int> weaponPrices;
    public List<int> xpTable;

    //References
    public Player player;
    //public Weapon weapon

    //Logic
    public int Coins;
    public int experience;

    //Save State
    /*
     * INT preferedSkin
     * Int Coins
     * Int Experience
     * int Weaponlevel
     */


    public void SaveState()
    {
        string s = "";

        s += "0" + "|";
        s += Coins.ToString() + "|";
        s += experience.ToString() + "|";
        s += "0";

        PlayerPrefs.SetString("SaveState", s);

    }

    public void LoadState(Scene S, LoadSceneMode mode)
    {
        if (!PlayerPrefs.HasKey("SaveState"))
            return;

        string[] data = PlayerPrefs.GetString("SaveState").Split('|');

        //Change Player Skin
        Coins = int.Parse(data[1]);
        experience = int.Parse(data[2]);
        //Change Weapon Level

        Debug.Log("Load State");
    }
}
