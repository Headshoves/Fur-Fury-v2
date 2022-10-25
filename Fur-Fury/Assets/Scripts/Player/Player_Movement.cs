using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class Player_Movement : MonoBehaviour
{

    [SerializeField] private float speed;
    [SerializeField] private Transform cam;

    //Movement Control
    private bool _forward;
    private bool _back;
    private bool _right;
    private bool _left;
    private bool _isWalking;

    //Components
    private Animator _anim;
    private Rigidbody _rb;

    [Header("Sound Control")]
    [SerializeField] private float breakFootstep;
    [SerializeField] private AudioClip Player_Footsteps;
    private AudioSource _src;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _anim = transform.GetChild(1).GetComponent<Animator>();
        _src = GetComponent<AudioSource>();
    }

    void Update()
    {
        CanMove();
    }

    private void FixedUpdate()
    {
        DoMove();
    }


    private void PlayWalkingSound()
    {
        if(!_isWalking)
        {
            InvokeRepeating("PlaySoundFootstep", 0, breakFootstep);
            _isWalking = true;
        }
    }

    private void StopWalkingSound()
    {
        _isWalking = false;
        _src.Stop();
        _anim.SetBool("ISRunning", false);
        CancelInvoke("PlaySoundFootstep");
    }

    private void PlaySoundFootstep()
    {
        _src.clip = Player_Footsteps;
        _src.Play();
        _anim.SetBool("ISRunning", true);
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

        if (!_right && !_left && !_forward && !_back)
        {
            StopWalkingSound();
        }
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
