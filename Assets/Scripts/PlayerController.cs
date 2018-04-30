using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float moveSpeed;
	private float moveSpeedStore;
	public float speedMultiplier;
	public float speedIncreaseMilestone;
	private float speedMilestoneCount;
	private float speedMilestoneCountStore;

	public float jumpForce;
	public float jumpTime;
	private float jumpTimeCounter;
	public bool StoppedJumping;
	public bool canDoubleJump;

	private Rigidbody2D myRigibody;

	public bool grounded;
	public LayerMask whatIsGround;
	public Transform groundCheck;
	public float groundCheckRadius;

	//private Collider2D myCollider;
	private Animator myAnimator;
	public GameManager theGameManager;

	public bool btnJump;

	public AudioSource jumpSound;
	public AudioSource deathSound;

	// Use this for initialization
	void Start () {
		myRigibody = GetComponent<Rigidbody2D>();
		//myCollider = GetComponent<Collider2D>();
		myAnimator = GetComponent<Animator>();
		jumpTimeCounter = jumpTime;
		speedMilestoneCount = speedIncreaseMilestone;
		moveSpeedStore = moveSpeed;
		speedMilestoneCountStore = speedMilestoneCount;
		StoppedJumping = true;
	}
	
	// Update is called once per frame
	void Update () {
		grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);

		if(transform.position.x > speedMilestoneCount){
			speedMilestoneCount += speedIncreaseMilestone;
			speedIncreaseMilestone = speedIncreaseMilestone * speedMultiplier;
			moveSpeed = moveSpeed * speedMultiplier;
		}

		myRigibody.velocity = new Vector2(moveSpeed, myRigibody.velocity.y);

		if(Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0) || btnJump == true){
			if(grounded){
				myRigibody.velocity = new Vector2(myRigibody.velocity.x, jumpForce);
				StoppedJumping = false;
				jumpSound.Play();
			}

			if(!grounded && canDoubleJump){
				myRigibody.velocity = new Vector2(myRigibody.velocity.x, jumpForce);
				jumpTimeCounter = jumpTime;
				StoppedJumping = false;
				canDoubleJump = false;
				jumpSound.Play();
			}
		}

		if((Input.GetKey(KeyCode.Space) || Input.GetMouseButton(0)) || btnJump == true && !StoppedJumping){
			if(jumpTimeCounter > 0){
				myRigibody.velocity = new Vector2(myRigibody.velocity.x, jumpForce);
				jumpTimeCounter -= Time.deltaTime;
			}
		}

		if(Input.GetKeyUp(KeyCode.Space) || Input.GetMouseButtonUp(0) || btnJump == true){
			jumpTimeCounter = 0;
			StoppedJumping = true;
		}

		if(grounded){
			jumpTimeCounter = jumpTime;
			canDoubleJump = true;
		}

		myAnimator.SetFloat("Speed", myRigibody.velocity.x);
		myAnimator.SetBool("Grounded", grounded);
	}

	void OnCollisionEnter2D(Collision2D other){
		if(other.gameObject.tag == "enemies"){
			theGameManager.RestartGame();
			moveSpeed = moveSpeedStore;
			speedMilestoneCount = speedMilestoneCountStore;
			deathSound.Play();
		}
	}

		public void jump(){
			if(grounded == true ){
			myRigibody.AddForce(new Vector2(0,jumpForce));
		}
	}
}
