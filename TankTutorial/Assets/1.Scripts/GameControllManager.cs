using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TankUtility;
using UnityEngine.SceneManagement;

public class GameControllManager : Singleton<GameControllManager> {

    
    public GAMEMODE selectedGameMode { get; private set; }


	void Awake ()
    {
        Instance.Init();
        selectedGameMode = GAMEMODE.PVE;
    }   

    public void ChangeScene(GAMESCENE s)
    {
        SceneManager.LoadSceneAsync((int)s);
    }

   public void ChangeGameMode(GAMEMODE g)
    {
        selectedGameMode = g;

    }





}
