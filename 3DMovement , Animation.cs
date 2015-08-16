using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	public bool canControl = true;

	//On Ground Stuff
	public float maxWalkspeed = 2;
	public float maxRunSpeed = 4;
	public bool running = false;
	public float xSpeed;
	
	public float angle = 90;
	

	//In Air Stuff
	public bool grounded = false;
	public Transform groundCheck;
	public float groundRadius =1;
	public LayerMask whatIsGround;
	public float jumpForce;
	public bool jumped;
	public bool bounce;//uses groundCheck.postistion
	public float bounceAmount;//uses groundCheck.position
	public LayerMask whatIsBounce;

	//Attacking Stuff
	public bool attacking;

	Animator anim;
	
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		transform.rotation = Quaternion.AngleAxis(angle, Vector3.up);
		float move = Input.GetAxis ("Horizontal");
		xSpeed = rigidbody.velocity.x;
		running = false;

		anim.SetFloat ("Walking", move);
		anim.SetBool ("Ground", grounded);
		anim.SetBool ("Jumped", jumped);
		anim.SetBool ("Running", running);
		anim.SetBool ("FireBall Attacking", attacking);
		anim.SetFloat ("Movement Speed", Mathf.Abs (xSpeed));

		//-------For Checking if Player is Running or Walking-----------------------------
		if (move > 0.1f && !Input.GetButton("Run") && canControl){
			rigidbody.velocity = new Vector3(move * maxWalkspeed, rigidbody.velocity.y);
			angle = 90;
			running = false;
		}
		if (move < -0.1f && !Input.GetButton("Run")&& canControl){
			rigidbody.velocity = new Vector3(move * maxWalkspeed, rigidbody.velocity.y);
			angle = 270;
			running = false;
		}
		if (move > 0.1f && Input.GetButton("Run")&& canControl){
			rigidbody.velocity = new Vector3(move * maxRunSpeed, rigidbody.velocity.y);
			anim.SetBool("Running", true);
			running = true;
			angle = 90;
		}
		if (move < -0.1f && Input.GetButton("Run")&& canControl){
			rigidbody.velocity = new Vector3(move * maxRunSpeed, rigidbody.velocity.y);
			anim.SetBool("Running", true);
			running = true;
			angle = 270;
		}

		//Jumping & Bouncing
		if(grounded){jumped = false;}

		if(grounded && Input.GetButtonDown("Jump")&& canControl){
			rigidbody.AddForce(new Vector2(0, jumpForce * 100));
			jumped = true;
		}

		if(Physics.CheckSphere (groundCheck.position, groundRadius, whatIsBounce)){
			anim.SetBool("Ground", false);
			rigidbody.AddForce(new Vector2(0, bounceAmount * 100));
			jumped = true;
		}

		//Attacking
		if(grounded && Input.GetButtonDown("Attack") && !attacking){
			attacking = true;
		}
	}

	void Update(){
		grounded = Physics.CheckSphere (groundCheck.position, groundRadius, whatIsGround);
	}

	void CantControl(){
		canControl = false;
	}
	void CanControl(){
		canControl = true;
	}
    } 
}
