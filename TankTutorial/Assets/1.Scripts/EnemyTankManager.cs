using System;
using UnityEngine;


[Serializable]
public class EnemyTankManager:AbstractTank
{


    private EnemyTankMonvement m_Movement;                        // Reference to tank's movement script, used to disable and enable control.
    private EnemyTankShooting m_Shooting;                        // Reference to tank's shooting script, used to disable and enable control.
    private GameObject m_CanvasGameObject;                  // Used to disable the world space UI during the Starting and Ending phases of each round.


    public void Setup()
    {

        // Get references to the components.
        m_Movement = m_Instance.GetComponent<EnemyTankMonvement>();
        m_Shooting = m_Instance.GetComponent<EnemyTankShooting>();
        m_CanvasGameObject = m_Instance.GetComponentInChildren<Canvas>().gameObject;

        // Set the player numbers to be consistent across the scripts.
        m_Movement.PlayerNumber = m_PlayerNumber;
        m_Shooting.m_PlayerNumber = m_PlayerNumber;

        // Create a string using the correct color that says 'PLAYER 1' etc based on the tank's color and the player's number.
        m_ColoredPlayerText = "<color=#" + ColorUtility.ToHtmlStringRGB(m_PlayerColor) + ">Enemy " + m_PlayerNumber + "</color>";

        // Get all of the renderers of the tank.
        MeshRenderer[] renderers = m_Instance.GetComponentsInChildren<MeshRenderer>();

        // Go through all the renderers...
        for (int i = 0; i < renderers.Length; i++)
        {
            // ... set their material color to the color specific to this tank.
            renderers[i].material.color = m_PlayerColor;
        }


    }


    // Used during the phases of the game where the player shouldn't be able to control their tank.
    public void DisableControl()
    {

        m_Movement.enabled = false;
        m_Shooting.enabled = false;

        m_CanvasGameObject.SetActive(false);

    }


    // Used during the phases of the game where the player should be able to control their tank.
    public void EnableControl()
    {
        m_Movement.enabled = true;
        m_Shooting.enabled = true;

        m_CanvasGameObject.SetActive(true);

    }


}
