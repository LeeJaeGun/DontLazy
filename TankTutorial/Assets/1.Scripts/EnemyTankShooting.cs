﻿using System.Collections;
using UnityEngine;
using UnityEngine.UI;


public class EnemyTankShooting : MonoBehaviour
{
    public int m_PlayerNumber = 1;              // Used to identify the different players.
    public Rigidbody m_Shell;                   // Prefab of the shell.
    public Transform m_FireTransform;           // A child of the tank where the shells are spawned.
    public Slider m_AimSlider;                  // A child of the tank that displays the current launch force.
    public AudioSource m_ShootingAudio;         // Reference to the audio source used to play the shooting audio. NB: different to the movement audio source.
    public AudioClip m_ChargingClip;            // Audio that plays when each shot is charging up.
    public AudioClip m_FireClip;                // Audio that plays when each shot is fired.
    public float m_MinLaunchForce = 15f;        // The force given to the shell if the fire button is not held.
    public float m_MaxLaunchForce = 30f;        // The force given to the shell if the fire button is held for the max charge time.
    public float m_MaxChargeTime = 0.75f;       // How long the shell can charge for before it is fired at max force.


    private string m_FireButton;                // The input axis that is used for launching shells.
    private float m_CurrentLaunchForce;         // The force that will be given to the shell when the fire button is released.
    private float m_ChargeSpeed;                // How fast the launch force increases, based on the max charge time.
    private bool m_Fired;                       // Whether or not the shell has been launched with this button press.
    
    private bool checkPlayer;
    private float distancePlayer;
    private float delayTimer;

    private void OnEnable()
    {
        // When the tank is turned on, reset the launch force and the UI
        m_CurrentLaunchForce = m_MinLaunchForce;
        m_AimSlider.value = m_MinLaunchForce;
        m_ChargeSpeed = 2.5f;
        EnemyTankMonvement.setForFire += SetDistance;

    }

    private void OnDisable()
    {
        ResetEnemyTank();
        EnemyTankMonvement.setForFire -= SetDistance;
    }

    public void ResetEnemyTank()
    {
        checkPlayer = false;
        distancePlayer = 0.0f;
        m_Fired = false;
        m_CurrentLaunchForce = m_MinLaunchForce;
        delayTimer = 0.0f;
    }


    public void SetDistance(float d)
    {

        if (!checkPlayer&& !m_Fired)
        {
            Debug.Log("타겟 설정 완료 타겟과의 거리 "+d);
            distancePlayer = d;
            checkPlayer = true;
            StartCoroutine(ChargePower());
        }
        else if(checkPlayer&&delayTimer<=5.0f)
        {
            delayTimer += Time.deltaTime;
            if (delayTimer > 5.0f)
                ResetEnemyTank();
        }
     
      
    }


    IEnumerator ChargePower()
    {
        yield return new WaitForSeconds(1.0f);
        m_Fired = true;
        m_CurrentLaunchForce = m_MinLaunchForce;
        m_ShootingAudio.clip = m_ChargingClip;
        m_ShootingAudio.Play();

        while (m_CurrentLaunchForce<=distancePlayer)
        {
          
                Debug.Log("Charging 중 현재 파워:"+ m_CurrentLaunchForce);

                // Increment the launch force and update the slider.
                m_CurrentLaunchForce += m_ChargeSpeed * Time.deltaTime;

                m_AimSlider.value = m_CurrentLaunchForce;
                yield return new WaitForEndOfFrame();
           

        }
        Fire();
    }

    private void Update()
    {
        if(!m_Fired)
        {
            m_AimSlider.value = m_MinLaunchForce;
        }
        else if(m_Fired&& m_CurrentLaunchForce>= m_MaxLaunchForce)
        {
            StopCoroutine(ChargePower());
            Fire();
        }
    }


    private void Fire()
    {
        Debug.Log("발사! 중");
        // Set the fired flag so only Fire is only called once.
   

        // Create an instance of the shell and store a reference to it's rigidbody.
        Rigidbody shellInstance =
            Instantiate(m_Shell, m_FireTransform.position, m_FireTransform.rotation) as Rigidbody;

        // Set the shell's velocity to the launch force in the fire position's forward direction.
        shellInstance.velocity = m_CurrentLaunchForce * m_FireTransform.forward;

        // Change the clip to the firing clip and play it.
        m_ShootingAudio.clip = m_FireClip;
        m_ShootingAudio.Play();

        // Reset the launch force.  This is a precaution in case of missing button events.
        m_CurrentLaunchForce = m_MinLaunchForce;
        checkPlayer = false;
        m_Fired = false;
        distancePlayer = 0.0f;
      
    }
}
