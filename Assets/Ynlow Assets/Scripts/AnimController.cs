using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimController : MonoBehaviour {

	private Animator anim;	
	public AnimatorStateInfo currentBaseLayer;

	public float maxSpeed = 5.0f;

	public float animSpeed = 1.5f;				// a public setting for overall animator animation speed

	static int idleState = Animator.StringToHash("Base Layer.Idle");	
	static int Hack1_to_Hack2 = Animator.StringToHash("Base Layer.Hack1_to_Hack2");	
	//static int none = Animator.StringToHash("Base Layer.New State");
	public int hack01 = Animator.StringToHash("Base Layer.Hack_001");	
	public int hack02 = Animator.StringToHash("Base Layer.Hack_002");	
	static int run = Animator.StringToHash("Base Layer.Run_002");



	public bool attackenable;

	// enable key working
	public bool KeysON;


	// horizontal and vertical float parameters
	//public float hSpeed;
	//public float vSpeed;
	public float speed;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
		KeysON = true;
		attackenable = false;

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void FixedUpdate()
	{
		

		currentBaseLayer = anim.GetCurrentAnimatorStateInfo (0);



		if (KeysON == true) {
			//speed = Input.GetAxis ("Horizontal");				// setup h variable as our horizontal input axis
			speed = gameObject.GetComponent<Controller>().mo;
			anim.SetFloat ("Speed", speed );							// set our animator's float parameter 'Speed' equal to the vertical input axis				
			//anim.SetFloat ("Direction", hSpeed ); 						// set our animator's float parameter 'Direction' equal to the horizontal input axis		
			anim.speed = animSpeed;								// set the speed of our animator to the public variable 'animSpeed'



			//Move forward
			//RunForward(vSpeed);

			if ( attackenable == true)
			// Attacks---Fighting
			BattleActions ();

		}
		if (currentBaseLayer.nameHash == hack01 || currentBaseLayer.nameHash == hack02 || currentBaseLayer.nameHash == Hack1_to_Hack2){
			gameObject.SendMessage ("disableInput");
			
		} else {
			gameObject.SendMessage ("enableInput");
		}
	}

	IEnumerator Attack1()
	{
		anim.SetBool ("Hack01", true);
		yield return new WaitForSeconds (0.1f);
		anim.SetBool ("Hack01", false);
	}
	IEnumerator Attack2()
	{
		anim.SetBool ("Hack02", true);
		yield return new WaitForSeconds (0.1f);
		anim.SetBool ("Hack02", false);
	}

	void BattleActions()
	{
		/*
			if( Input.GetButtonDown("Fire1")   )
			{
				StartCoroutine("Attack1");
				
			}
				if( (Input.GetButtonDown("Fire1")) && (currentBaseLayer.nameHash == Hack1_to_Hack2) ) 
			{
				StartCoroutine("Attack2");
			}
		*/
		if(  currentBaseLayer.nameHash != Hack1_to_Hack2  )
		{
			StartCoroutine("Attack1");
			attackenable = false;
		} else {
			StartCoroutine("Attack2");
			attackenable = false;
		}

	}
				/*
	void RunForward(float inputAxisSpeed)
	{
		if ( (currentBaseStateBattleMoveLayer.nameHash == walkingBattle || currentBaseStateBattleMoveLayer.nameHash == walking) && (currentBaseStateAttackLayer.nameHash == none ))  {
			gameObject.GetComponent<Rigidbody>().velocity = transform.forward * maxSpeed * inputAxisSpeed ;		

		}
	}
*/

	void ResetMecanimStates()
	{

	}

	void HorizontalVeritcalZero()
	{
		
		speed = 0.0f;
		anim.SetFloat ("Speed", 0.0f);				

	}
}
