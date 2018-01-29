using UnityEngine;
using System.Collections;

public class AgentMovement : MonoBehaviour {

	private Rigidbody2D _rigidbody;
	private Animator _faceAnimation;
	private Transform _eyes;
	
	public float walkSpeed = 20f;
	public float slowSpeed = 10f;
	public float maxSpeed = 5f;
	public float jumpVel = 7f;
	public float climbSpeed = 5f;

	private float timeSinceUpdate = 0f;
	private float updateInterval = 0.2f;
	
	private bool climbing = false;
	
	//private int playerMask = 1 << 8;
	
	private bool hasJumped = false;
	[HideInInspector]
	public bool active = false;
	[HideInInspector]
	public Vector3 facing = -Vector3.right;
	public KeyCode agentNumber = KeyCode.Alpha1;
	
	// Call this to set the active status of the script.
	public void SetActiveStatus(bool status)
	{
		GameObject[] agents = GameObject.FindGameObjectsWithTag("Player");
		foreach (GameObject agent in agents)
		{
			agent.GetComponent<AgentMovement>().active = false;
		}
		active = status;
	}
	
	public void SetClimbing(bool status)
	{
		climbing = status;
		if(climbing)
		{
			_rigidbody.velocity = Vector2.zero;
			_rigidbody.gravityScale = 0f;
		}
		else
		{
			_rigidbody.gravityScale = 1f;
		}
	}
	public bool GetClimbing() {return climbing;}
	
	
	// Use this for initialization
	void Start () {
		_rigidbody = GetComponent<Rigidbody2D>();
		_eyes = transform.GetChild(0);
		_faceAnimation = _eyes.GetComponent<Animator>();
		if(agentNumber == KeyCode.Alpha1)
			active = true;
	}
	
	// Update is called once per frame
	void Update () {
		
		if(Input.GetKeyDown(KeyCode.Escape))
			Application.Quit();
		
		if(Input.GetKeyDown(agentNumber))
			SetActiveStatus(true);
		if(Mathf.Abs(_rigidbody.velocity.x) < 0.1)
			_faceAnimation.SetBool("isWalking",false);
		
		if(!active)
			return;
		
		if(climbing)
			UpdateClimb();
		else
			UpdateMovement();

		UpdateCamera();
	}
	
	void UpdateClimb()
	{
		if(Input.GetKey(KeyCode.W))
			transform.Translate(Vector2.up * climbSpeed * Time.deltaTime);
		else if(Input.GetKey(KeyCode.S))
			transform.Translate(-Vector2.up * climbSpeed * Time.deltaTime);
		if(Input.GetKey(KeyCode.D))
			{transform.Translate(Vector2.right * climbSpeed * Time.deltaTime); _eyes.localPosition = new Vector3(0.4f,0.25f,-0.1f);}
		else if(Input.GetKey(KeyCode.A))
			{transform.Translate(-Vector2.right * climbSpeed * Time.deltaTime); _eyes.localPosition = new Vector3(-0.4f,0.25f,-0.1f);}
	}
	
	
	void UpdateMovement()
	{
		if(Input.GetKey(KeyCode.D) && Mathf.Abs(_rigidbody.velocity.x) < maxSpeed)
		{
			_rigidbody.velocity = new Vector2(_rigidbody.velocity.x + walkSpeed * Time.deltaTime,_rigidbody.velocity.y);
			_faceAnimation.SetBool("isWalking",true);
			facing = Vector3.right;
			_eyes.localPosition = new Vector3(0.4f,0.25f,-0.1f);
		}		
		else if(Input.GetKey(KeyCode.A) && Mathf.Abs(_rigidbody.velocity.x) < maxSpeed)
		{
			_rigidbody.velocity = new Vector2(_rigidbody.velocity.x - walkSpeed * Time.deltaTime,_rigidbody.velocity.y);
			_faceAnimation.SetBool("isWalking",true);
			facing = -Vector3.right;
			_eyes.localPosition = new Vector3(-0.4f,0.25f,-0.1f);
		}
		else if(Mathf.Abs(_rigidbody.velocity.x) > 0.1)
		{
			Vector2 slowdown = new Vector2(_rigidbody.velocity.x + ((_rigidbody.velocity.x < 0) ? slowSpeed : slowSpeed * -1f) * Time.deltaTime, _rigidbody.velocity.y);
			_rigidbody.velocity = slowdown;
		}
		
		if(Input.GetKey(KeyCode.W) && !hasJumped)
		{
			_rigidbody.velocity = new Vector2(_rigidbody.velocity.x,jumpVel);
			hasJumped = true;
		}
		
	}
	
	public void UpdateCamera()
	{
		if( timeSinceUpdate > updateInterval)
		{
			if(Camera.main.WorldToScreenPoint(transform.position).x > Screen.width)
			{
				Camera.main.transform.position = 
				new Vector3(Camera.main.transform.position.x + ((Camera.main.ScreenToWorldPoint(new Vector3(Screen.width,0,0)).x) - Camera.main.transform.position.x)*2f,
							Camera.main.transform.position.y,
							-10f);
			}
			else if(Camera.main.WorldToScreenPoint(transform.position).x < 0)
			{
				Camera.main.transform.position = 
				new Vector3(Camera.main.transform.position.x - ((Camera.main.ScreenToWorldPoint(new Vector3(Screen.width,0,0)).x) - Camera.main.transform.position.x)*2f,
							Camera.main.transform.position.y,
							-10f);
			}
			if(Camera.main.WorldToScreenPoint(transform.position).y > Screen.height)
			{
				Camera.main.transform.position = 
				new Vector3(Camera.main.transform.position.x,
							Camera.main.transform.position.y - ((Camera.main.ScreenToWorldPoint(new Vector3(Screen.height,0,0)).y) - Camera.main.transform.position.y)*2f,
							-10f);
			}
			else if(Camera.main.WorldToScreenPoint(transform.position).y < 0)
			{
				Camera.main.transform.position = 
				new Vector3(Camera.main.transform.position.x,
							Camera.main.transform.position.y + ((Camera.main.ScreenToWorldPoint(new Vector3(Screen.height,0,0)).y) - Camera.main.transform.position.y)*2f,
							-10f);
			}			
			timeSinceUpdate = 0f;
		}
		else
		{
			timeSinceUpdate += Time.deltaTime;
		}
	}
	
	void OnCollisionEnter2D(Collision2D col)
	{
		if(hasJumped && col.transform.position.y < transform.position.y)
		{
			for(int i = 0; i < 5; i++)
			{
				float xoffset = 0f;
				if(i == 0) xoffset = 0.1f;
				if(i == 4) xoffset = -0.1f;
				Vector2 pos = new Vector2(	transform.position.x - 1f + (i*2f)/5 + xoffset,
											transform.position.y - 1.01f);
				RaycastHit2D hit = Physics2D.Raycast(pos,-Vector2.up, 0.2f);
				if(hit.collider != null)
				{
					hasJumped = false;
					break;
				}
			}
		}
	}
	
}
