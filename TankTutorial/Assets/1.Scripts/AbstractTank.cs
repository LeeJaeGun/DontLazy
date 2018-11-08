using UnityEngine;

public class AbstractTank
{

    public Color m_PlayerColor;                             // This is the color this tank will be tinted.
    public Transform m_SpawnPoint;                          // The position and direction the tank will have when it spawns.
    [HideInInspector]
    public int m_PlayerNumber;            // This specifies which player this the manager for.
    [HideInInspector]
    public string m_ColoredPlayerText;    // A string that represents the player with their number colored to match their tank.
    [HideInInspector]
    public int m_Wins;                    // The number of wins this player has so far.
    [HideInInspector]
    public GameObject m_Instance;         // A reference to the instance of the tank when it is created.
    // Use this for initialization
    public void Reset()
    {
        m_Instance.transform.position = m_SpawnPoint.position;
        m_Instance.transform.rotation = m_SpawnPoint.rotation;

        m_Instance.SetActive(false);
        m_Instance.SetActive(true);
    }
}
