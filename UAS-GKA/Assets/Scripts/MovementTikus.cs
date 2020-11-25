using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementTikus : MonoBehaviour
{
    public CharacterController controller;
    public Transform cam;

    public float speed = 3f;

    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;

    public float gravity = -10f;
    public float jumpheight = 1f;
    Vector3 velocity;    

    private Animator animator;
    private Animator animatorPintu;

    private void Start()
    {
        animator = this.GetComponent<Animator>();
        animatorPintu = GameObject.Find("DoorHolder").GetComponent<Animator>();

    }
    private void Update()
    {
        if(controller.isGrounded && velocity.y < 0)
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
                //animator.SetBool("jumpUp", true);
            }
            animator.SetBool("run", false);
        }
     
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Pintu")
        {
            //Debug.Log("pintu");
            animatorPintu.SetBool("doorOpen", false);
        }
      
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Fast")
        {
            Destroy(other.gameObject);
            StartCoroutine(percepat());
            //this.gameObject.SetActive(false);
        }

        if (other.tag == "Slow")
        {
            Destroy(other.gameObject);
            StartCoroutine(perlambat());
        }

        if(other.tag == "Cheese")
        {
            Destroy(other.gameObject);
        }

        if(other.tag == "Pintu")
        {
            //Debug.Log("pintu");
            animatorPintu.SetBool("doorOpen", true);
        }
       

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
