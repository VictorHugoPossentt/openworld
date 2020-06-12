using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimento : MonoBehaviour
{
    public float inputx, inputy, rotationSpeed, jumpingForce;
    public Camera cam;
    public Rigidbody rigid;
    public Animator anin;
    public bool jump = false;
    // Use this for initialization
    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        bool spell = Input.GetKeyDown(KeyCode.Mouse1);
        bool firing = Input.GetKeyDown(KeyCode.Mouse0);
        bool jumping = (Input.GetAxis("Jump") == 1) ? true : false;

        inputx = Input.GetAxis("Horizontal");
        inputy = Input.GetAxis("Vertical");

        if (firing)
        {
            Debug.Log("uiui");
            anin.SetTrigger("attacking");
        }

        if (spell)
        {
            anin.SetTrigger("spellcasting");
        }

        if (jumping && !jump)
        {
            jump = true;
            anin.SetBool("jump", true);
            rigid.AddForce(new Vector3((jumpingForce * 3) *inputx ,jumpingForce, (jumpingForce * 3)), ForceMode.Force);
        }

        if (inputy != 0 || inputx != 0)
        {
            anin.SetBool("run",true);
            Rotation();
        }
        else
        {
            anin.SetBool("run", false);
            transform.rotation.Normalize();
            //Quaternion rotation = transform.rotation;
        }
    }

    private void Rotation()
    {
        Vector3 forward = cam.transform.forward;
        Vector3 right = cam.transform.right;

        forward.y = 0f;
        right.y = 0f;

        forward.Normalize();
        right.Normalize();

        Vector3 desiredMoveDirection = forward * inputy + right * inputx;

        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(desiredMoveDirection), rotationSpeed);
    }

    void OnCollisionEnter (Collision collision)
    {
        StartCoroutine("Jumptimer");
        
    }

    IEnumerator Jumptimer()
    {
        anin.SetBool("jump", false);
        rigid.velocity = Vector3.zero;
        yield return new WaitForSeconds(0.5f);
        jump = false;     
    }
}
