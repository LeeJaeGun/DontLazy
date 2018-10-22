using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbstractTankController : MonoBehaviour
{

    public int PlayerNumber = 1;              // Used to identify which tank belongs to which player.  This is set by this tank's manager.
    public float Speed = 12f;                 // How fast the tank moves forward and back.
    public float TurnSpeed = 180f;            // How fast the tank turns in degrees per second.
    public AudioSource MovementAudio;         // Reference to the audio source used to play engine sounds. NB: different to the shooting audio source.
    public AudioClip EngineIdling;            // Audio to play when the tank isn't moving.
    public AudioClip EngineDriving;           // Audio to play when the tank is moving.
    public float PitchRange = 0.2f;           // The amount by which the pitch of the engine noises can vary.

    private Rigidbody rb;              // Reference used to move the tank.
    private float movementInputValue;         // The current value of the movement input.
    private float turnInputValue;             // The current value of the turn input.
    private float originalPitch;              // The pitch of the audio source at the start of the scene.
    private ParticleSystem[] particleSystems; // References to all the particles systems used by the Tanks

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
