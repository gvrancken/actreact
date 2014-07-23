using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float maxSpeed = 2f;
	public float jumpForce = 240f;

	public Transform groundCheck;
	public LayerMask whatIsGround;

	private bool isFacingRight = true;
	private bool isGrounded = false;

	private Animator anim;

	private float groundRadius = 0.2f;


	// Use this for initialization
	void Start () 
	{
		anim = GetComponent<Animator>();
	}

	void OpenDoor() {
		rigidbody2D.velocity = Vector2.zero;
		anim.SetFloat("Speed", 0);
		anim.SetBool ("OpenDoor", true);
	}

	void FixedUpdate() 
	{
		isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
		anim.SetBool("IsGrounded", isGrounded);
		anim.SetFloat("vSpeed", rigidbody2D.velocity.y);

		//if (!isGrounded) return;

		float move = Input.GetAxis("Horizontal");

		rigidbody2D.velocity = new Vector2(move * maxSpeed, rigidbody2D.velocity.y);

		anim.SetFloat("Speed", Mathf.Abs(move));

		if (move > 0 && !isFacingRight) {
			Flip();
		} else if (move < 0 && isFacingRight) {
			Flip();
		}
	}

	void Flip() {
		isFacingRight = !isFacingRight;

		Vector2 playerScale = transform.localScale;
		playerScale.x *= -1;
		transform.localScale = playerScale;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (isGrounded && Input.GetKeyDown(KeyCode.UpArrow)) {
			anim.SetBool("IsGrounded", false);
			rigidbody2D.AddForce(new Vector2(0, jumpForce));
		}
	}
}
