using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//additional packages being used for player input
using UnityEngine.InputSystem;
using UnityEngine.AI;

//Controller for the players movement and animation using a NavMeshAgent and input system
public class PlayerController : MonoBehaviour
{
    //Animation states
    const string IDLE = "Idle";
    const string WALK = "Walk";
    const string ITEMPICKUP = "itemPickUp";

    //input system for player action
    CustomAction input;

    //navigation and animation
    NavMeshAgent agent;
    Animator animator;

    [Header("Movement")]
    //effect to display when the player clicks
    [SerializeField] ParticleSystem clickEffect;
    //defines layers that can be clicked
    [SerializeField] LayerMask clickableLayers;

    //speed that player rotates
    float lookRotationSpeed = 8f;
    //last direction player faced, to stop from snapping back to a position
    Vector3 lastDirection;

    //Awake method for on start
    private void Awake()
    {
        //getters
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();

        //initialising the input and assign input action
        input = new CustomAction();
        AssignInputs();
    }

    //assigns input actions to corresponding methods
    void AssignInputs()
    {
        input.Main.Move.performed += ctx => ClickToMove();
    }

    //handles the players movement when clicking on ground layer
    void ClickToMove()
    {
        //performing a raycast to detect where player clicked
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100, clickableLayers))
        {
            //setting player destination to clicked point
            agent.destination = hit.point;

            //display a click effect at clicked point
            if (clickEffect != null)
            {
                Instantiate(clickEffect, hit.point += new Vector3(0, 0.1f, 0), clickEffect.transform.rotation);
            }
        }
    }

    void OnEnable()
    {
        input.Enable();
    }

    void OnDisable()
    {
        input.Disable();
    }

    void Update()
    {
        //checking if the agent is still moving to destination
        if (agent.remainingDistance > agent.stoppingDistance)
        {
            //rotates face to that direction
            FaceTarget();
            //update last direction
            lastDirection = agent.velocity.normalized;
        }
        else if (agent.remainingDistance <= agent.stoppingDistance && !agent.pathPending)
        {
            //if stopped update direction faced
            if (lastDirection != Vector3.zero)
            {
                FaceFinalDirection();
            }
        }
        //update the animations based on player movement
        SetAnimations();
    }

    //smoothly rotates player to face where desired direction is
    void FaceTarget()
    {
        Vector3 direction = agent.velocity.normalized;
        //only rotates if valid direction
        if (direction != Vector3.zero)
        {
            Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * lookRotationSpeed);
        }
    }

    //allows for facing last know direction (where player was facing)
    void FaceFinalDirection()
    {
        Quaternion finalRotation = Quaternion.LookRotation(new Vector3(lastDirection.x, 0, lastDirection.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, finalRotation, Time.deltaTime * lookRotationSpeed);
    }

    //sets aniamtion wether player is moving or walking or ETC.
    void SetAnimations()
    {
        if (agent.velocity == Vector3.zero)
        {
            animator.Play(IDLE);
        }
        else
        {
            animator.Play(WALK);
        }

        //if ()
        //{
        //    animator.Play(ITEMPICKUP);
        //}
    }
}
