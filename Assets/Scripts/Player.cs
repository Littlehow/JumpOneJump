using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    bool onGround;
    float jumpPressure = 0;
    float jumpPressure_min = 3f;
    float jumpPressure_max = 10f;
    Rigidbody rb;
    Animator anim;

	// Use this for initialization
	void Start ()
    {
        onGround = true;
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(onGround)
        {
            if(Input.GetButton("Jump"))
            {
                if (jumpPressure < jumpPressure_max)
                    jumpPressure += Time.deltaTime * 10f;
                else
                    jumpPressure = jumpPressure_max;

                anim.SetFloat("IsPressure", jumpPressure);
            }
            else
            {
                if(jumpPressure>0)
                {
                    jumpPressure += jumpPressure_min;
                    rb.velocity = new Vector3(0, jumpPressure, 0);
                    jumpPressure = 0;
                    onGround = false;
                }

                anim.SetFloat("IsPressure", 0f);
                anim.SetBool("OnGround", onGround);
            }
        }
	
	}

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "ground")
        {
            onGround = true;
        }
    }
}
