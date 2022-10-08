using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class Player_Movement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Transform cam;

    private Rigidbody _rb;

    private bool _forward;
    private bool _back;
    private bool _right;
    private bool _left;

    private Animator anim;


    [Header("Sound Control")]
    [SerializeField] private float breakFootstep;
    public AudioSource src;
    public AudioClip Player_Footsteps;

    private bool isWalking;



    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        anim = transform.GetChild(1).GetComponent<Animator>();
        //Player_Footsteps = GetComponent<AudioSource>();
    }

    void Update()
    {
        CanMove();
       
    }


    private void FixedUpdate()
    {
        DoMove();
    }

    private void CanMove()
    {
        if (Input.GetKey(KeyCode.W))
        {
            _forward = true;
            PlayWalkingSound();
        }


        if (Input.GetKeyUp(KeyCode.W))
        {
            _forward = false;
        }

        if (Input.GetKey(KeyCode.S))
        {
            _back = true;
            PlayWalkingSound();
        }

        if (Input.GetKeyUp(KeyCode.S)) 
        {
            _back = false;
        }
            
        
        if (Input.GetKey(KeyCode.A))
        {
            _left = true;
            PlayWalkingSound();
        }

        if (Input.GetKeyUp(KeyCode.A)) 
        {
            _left = false;
        }
            
        
        if (Input.GetKey(KeyCode.D))
        {
            _right = true;
            PlayWalkingSound();
        }
            

        if (Input.GetKeyUp(KeyCode.D)) 
        {
            _right = false;
        }

        if(!_right && !_left && !_forward && !_back)
        {
            StopWalkingSound();
        }
    }


    private void PlayWalkingSound()
    {
        if(!isWalking)
        {
            InvokeRepeating("PlaySoundFootstep", 0, breakFootstep);
            isWalking = true;
        }
    }

    private void StopWalkingSound()
    {
        isWalking = false;
        src.Stop();
        anim.SetBool("ISRunning", false);
        CancelInvoke("PlaySoundFootstep");
    }

    private void PlaySoundFootstep()
    {
        src.clip = Player_Footsteps;
        src.Play();
        anim.SetBool("ISRunning", true);
    }
            

    private void DoMove()
    {
        

        if (_forward)
        {
            _rb.velocity = new Vector3(cam.forward.x, _rb.velocity.y, cam.forward.z).normalized * speed;
        }


        if (_back)
        {
           _rb.velocity = new Vector3(cam.forward.x, _rb.velocity.y, cam.forward.z).normalized * -speed;
            PlayWalkingSound();
        }

        if (_left)
        {
            _rb.velocity = new Vector3(cam.right.x, _rb.velocity.y, cam.right.z).normalized * -speed;
            PlayWalkingSound();
        }

        if (_right)
        {
            _rb.velocity = new Vector3(cam.right.x, _rb.velocity.y, cam.right.z).normalized * speed;
            PlayWalkingSound();
        }

        if (_left && _forward)
        {
            _rb.velocity = new Vector3(cam.forward.x - cam.right.x, _rb.velocity.y, cam.forward.z - cam.right.z).normalized * speed;
            PlayWalkingSound();
        }

        if (_right && _forward)
        {
            _rb.velocity = new Vector3(cam.forward.x + cam.right.x, _rb.velocity.y, cam.forward.z + cam.right.z).normalized * speed;
            PlayWalkingSound();
        }

        if (_left && _back)
        {
            _rb.velocity = new Vector3(-cam.forward.x - cam.right.x, _rb.velocity.y, -cam.forward.z - cam.right.z).normalized * speed;
            PlayWalkingSound();
        }

        if (_right && _back)
        {
            _rb.velocity = new Vector3(-cam.forward.x + cam.right.x, _rb.velocity.y, -cam.forward.z + cam.right.z).normalized * speed;
            PlayWalkingSound();
        }
    }
}
