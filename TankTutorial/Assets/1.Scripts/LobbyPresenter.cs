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

    [SerializeField]
    Dropdown dropdown;



    private void Start()
    {
        PvPToggle.onValueChanged.AddListener(OnClickPvPToggle);
        PvEToggle.onValueChanged.AddListener(OnClickPvEToggle);
        dropdown.onValueChanged.AddListener(OnChangeDropDownValue);
        PlayButton.onClick.AddListener(OnClickPlayButton);
        OkButton.onClick.AddListener(OnClickOkButton);
    }
    void OnChangeDropDownValue(int v)
    {
        GameControllManager.Instance.EnemyCount = v;
        Debug.Log("현재 몬스터 수" + v);
    }

    void OnClickPvPToggle(bool isOn)
    {
        ColorBlock colorblock = PvPToggle.colors;

        if (isOn)
        {
            dropdown.gameObject.SetActive(false);
            colorblock.normalColor = Color.red;
            colorblock.highlightedColor = Color.red;
            GameControllManager.Instance.ChangeGameMode(TankUtility.GAMEMODE.PVP);
            if (PvEToggle.isOn)
            {
                PvEToggle.isOn = false;
                dropdown.gameObject.SetActive(false);
            }
        }
        else
        {
            colorblock.normalColor = Color.white;
            colorblock.highlightedColor = Color.white;

            if (!PvEToggle.isOn)
            {
                PvEToggle.isOn = true;
                dropdown.gameObject.SetActive(true);
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
            dropdown.gameObject.SetActive(true);
            if (PvPToggle.isOn)
            {
                PvPToggle.isOn = false;
                dropdown.gameObject.SetActive(true);
            }

            GameControllManager.Instance.ChangeGameMode(TankUtility.GAMEMODE.PVE);
        }
        else
        {
            colorblock.normalColor = Color.white;
            colorblock.highlightedColor = Color.white;

            if (!PvPToggle.isOn)
            {
                PvPToggle.isOn = true;
                dropdown.gameObject.SetActive(false);
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
            GameControllManager.Instance.ChangeScene(TankUtility.GAMESCENE.INGAME);
    }

    void OnClickOkButton()
    {
        WarningPanel.SetActive(false);
    }
}
