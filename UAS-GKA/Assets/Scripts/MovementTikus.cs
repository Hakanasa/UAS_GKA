﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovementTikus : MonoBehaviour
{
    public CharacterController controller;
    public Transform cam;

    public float speed = 3f;

    public bool isPlaying = true;

    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;

    public float gravity = -10f;
    public float jumpheight = 1f;
    Vector3 velocity;    

    private Animator animator;
    private Animator animatorPintu;
    private Animator animatorPintu1;
    private Animator animatorPintu2;
    private Animator animatorPintu3;

    public AudioSource kejuu;
    public AudioSource jebakan;
    public AudioClip loncat;

    private AudioSource source { get { return GetComponent<AudioSource>(); } }

    public GameObject pause;

    private void Start()
    {
        animator = this.GetComponent<Animator>();
        animatorPintu = GameObject.Find("DoorHolder").GetComponent<Animator>();
        animatorPintu1 = GameObject.Find("DoorHolder1").GetComponent<Animator>();
        animatorPintu2 = GameObject.Find("DoorHolder2").GetComponent<Animator>();
        animatorPintu3 = GameObject.Find("DoorHolder3").GetComponent<Animator>();

        source.clip = loncat;
        source.volume = .2f;
    }
    private void Update()
    {

        //Pause
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pause.SetActive(true);
            Time.timeScale = 0;
        }
        if (isPlaying == true)
        {
            if (controller.isGrounded && velocity.y < 0)
            {
                velocity.y = -2f;
                animator.SetBool("jump", false);
                animator.SetBool("jumpUp", false);
            }


            /*if (Input.GetButtonDown("Jump"))
            {
                animator.SetBool("jumpUp", true);
            }
            else
            {
                animator.SetBool("jumpUp", false);
            }*/

            float horizontal = Input.GetAxisRaw("Horizontal");
            float vertical = Input.GetAxisRaw("Vertical");

            Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

            if (direction.magnitude >= 0.1f)
            {
                float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
                float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
                transform.rotation = Quaternion.Euler(0f, angle, 0f);

                Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
                controller.Move(moveDir.normalized * speed * Time.deltaTime);

                velocity.y += gravity * Time.deltaTime;
                controller.Move(velocity * Time.deltaTime);

                if (Input.GetButtonDown("Jump") && controller.isGrounded)
                {
                    velocity.y = Mathf.Sqrt(jumpheight * -2f * gravity);
                    animator.SetBool("jump", true);
                    source.PlayOneShot(loncat);
                    //animator.SetBool("jumpUp", true);
                }

                animator.SetBool("run", true);
            }
            else
            {
                velocity.y += gravity * Time.deltaTime;
                controller.Move(velocity * Time.deltaTime);
                if (Input.GetButtonDown("Jump") && controller.isGrounded)
                {
                    velocity.y = Mathf.Sqrt(jumpheight * -2f * gravity);
                    animator.SetBool("jumpUp", true);
                    source.PlayOneShot(loncat);
                    //animator.SetBool("jumpUp", true);
                }
                animator.SetBool("run", false);
            }

        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Pintu")
        {
            //Debug.Log("pintu");
            animatorPintu.SetBool("doorOpen", false);
            animatorPintu1.SetBool("doorOpen", false);
            animatorPintu2.SetBool("doorOpen", false);
            animatorPintu3.SetBool("doorOpen", false);
        }
      
    }

    private void OnControllerColliderHit(ControllerColliderHit collision)
    {
        if (collision.gameObject.tag == "Fast")
        {
            Destroy(collision.gameObject);
            StartCoroutine(percepat());
            //this.gameObject.SetActive(false);
        }

        if (collision.gameObject.tag == "Slow")
        {
            Destroy(collision.gameObject);
            StartCoroutine(perlambat());
        }


        if (collision.gameObject.tag == "Trap")
        {
            jebakan.Play();
            Destroy(collision.gameObject);
            StartCoroutine(kenatrap());
        }

        if(collision.gameObject.tag == "Water")
        {
            GameObject respawn = GameObject.Find("Respawn");
            this.gameObject.transform.position = respawn.transform.position;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
       /* if (other.tag == "Fast")
        {
            Destroy(other.gameObject);
            StartCoroutine(percepat());
            //this.gameObject.SetActive(false);
        }

        if (other.tag == "Slow")
        {
            Destroy(other.gameObject);
            StartCoroutine(perlambat());
        }*/

        if(other.tag == "Cheese")
        {
            kejuu.Play();
            Destroy(other.gameObject);
        }

        if(other.tag == "Pintu")
        {
            //Debug.Log("pintu");
            animatorPintu.SetBool("doorOpen", true);
            animatorPintu1.SetBool("doorOpen", true);
            animatorPintu2.SetBool("doorOpen", true);
            animatorPintu3.SetBool("doorOpen", true);
        }
 }

    IEnumerator kenatrap()
    {
        speed = 3f;
        for (int i = 0; i < 5; i++)
        {
            this.transform.GetChild(0).GetComponent<SkinnedMeshRenderer>().enabled = false;
            yield return new WaitForSeconds(0.2f);
            this.transform.GetChild(0).GetComponent<SkinnedMeshRenderer>().enabled = true;
            yield return new WaitForSeconds(0.2f);
        }
        speed = 6f;
    }
    IEnumerator percepat()
    {

        Time.timeScale = 2f;
        yield return new WaitForSeconds(4);
        Time.timeScale = 1f;
        //Destroy(this.gameObject);

        yield return null;
    }

    IEnumerator perlambat()
    {

        Time.timeScale = 0.5f;
        yield return new WaitForSeconds(4);
        Time.timeScale = 1f;
        //Destroy(this.gameObject);

        yield return null;
    }
}
