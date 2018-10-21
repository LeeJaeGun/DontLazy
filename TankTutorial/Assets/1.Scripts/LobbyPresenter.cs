using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LobbyPresenter : MonoBehaviour {

    [SerializeField]
    Toggle PvPToggle;

    [SerializeField]
    Toggle PvEToggle;

    [SerializeField]
    Button PlayButton;

    [SerializeField]
    GameObject WarningPanel;

    [SerializeField]
    Button OkButton;


    private void Start()
    {
        PvPToggle.onValueChanged.AddListener(OnClickPvPToggle);
        PvEToggle.onValueChanged.AddListener(OnClickPvEToggle);
        PlayButton.onClick.AddListener(OnClickPlayButton);
        OkButton.onClick.AddListener(OnClickOkButton);
    }

    void OnClickPvPToggle(bool isOn)
    {
        ColorBlock colorblock = PvPToggle.colors;

        if (isOn)
        {
            colorblock.normalColor = Color.red;
            colorblock.highlightedColor = Color.red;
            GameControllerManager.Instance.ChangeGameMode(TankUtility.GAMEMODE.PVP);
            if (PvEToggle.isOn)
            {
                PvEToggle.isOn = false;
            }
        }
        else
        {
            colorblock.normalColor = Color.white;
            colorblock.highlightedColor = Color.white;

            if (!PvEToggle.isOn)
            {
                PvEToggle.isOn = true;
            }
          
        }

        PvPToggle.colors = colorblock;
       

    }

    void OnClickPvEToggle(bool isOn)
    {
        ColorBlock colorblock = PvEToggle.colors;
        if (isOn)
        {
            colorblock.normalColor = Color.red;
            colorblock.highlightedColor = Color.red;

            if (PvPToggle.isOn)
            {
                PvPToggle.isOn = false;
            }

            GameControllerManager.Instance.ChangeGameMode(TankUtility.GAMEMODE.PVE);
        }
        else
        {
            colorblock.normalColor = Color.white;
            colorblock.highlightedColor = Color.white;

            if (!PvPToggle.isOn)
            {
                PvPToggle.isOn = true;
            }
          
        }  

        PvEToggle.colors = colorblock;
    }

    void OnClickPlayButton()
    {
        if(!PvPToggle.isOn&& !PvEToggle.isOn)
        {
            WarningPanel.SetActive(true);
          
        }
        else
            GameControllerManager.Instance.ChangeScene(TankUtility.GAMESCENE.INGAME);
    }

    void OnClickOkButton()
    {
        WarningPanel.SetActive(false);
    }
}
