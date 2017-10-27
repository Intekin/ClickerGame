using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {
	/// <summary>
	/// How many triangles the player has.
	/// </summary>
	private float _currentTris;
	public float CurrentTris
	{
		get{
			return _currentTris;
		}
		set{
			_currentTris = value;
			cashText.text = "You have: " + _currentTris.ToString ("0.00");
		}	
	}

	private float _trisPerSecond;
	public float TrisPerSecond
	{
		get{
			return _trisPerSecond;
		}
		set{
			_trisPerSecond = value;
			rateText.text = "per second: " + _trisPerSecond.ToString ("0.0");
		}
	}

	[Header("Other Stats")]
	public float totalTris;
	public int totalBuildings;
	public int totalClicks;
	public float totalClickValue;

	[Header("Object References")]
	public Text cashText;
	public Text rateText;

	[Header("TPS Base Values")]
	public float trisPerClick = 0;
	public float clicking = 1;
	public float overwork = 0;
	public float programmer = 0;
	public float basement = 0;
	public float artist = 0;
	public float office = 0;
	public float happyHour = 0;
	public float renderFarms = 0;
	public float quantumComputers = 0;
	public float fullDiveVR = 0;

	[Header("TPS Bonus Multiplyer")]
	public float clickingMP = 1f;
	public float overworkMP = 1f;
	public float programmerMP = 1f;
	public float basementMP = 1f;
	public float artistMP = 1f;
	public float officeMP = 1f;
	public float happyHourMP = 1f;
	public float renderFarmsMP = 1f;
	public float quantumComputersMP = 1f;
	public float fullDiveVRMP = 1f;

	public float gameMP = 0f;


	public float cheatMP = 1000f;

	private float tempTris = 0;
	private bool cheatBool = true;

	private ParticleSystem particleSystems;
	//private int particleEmissionRate = 0;
	//private int particleEmission = 1;


	// Use this for initialization
	void Start () {
		CurrentTris = 0;
		TrisPerSecond = 0;
		//particleSystems = GameObject.Find("TriButton").GetComponent<ParticleSystem>();
		//ParticleSystem meh = particleSystems.emission.;
		//meh = particleEmissionRate;

		Recalculate ();
	}
	
	// Update is called once per frame for the total amount of tris made. 
	void Update () {
		tempTris = TrisPerSecond * Time.deltaTime;
		totalTris += tempTris;
		CurrentTris += tempTris;
	}

	public void ClickedButton(){
		totalClicks++;					//Statistics and maybe for clicking upgrades
		CurrentTris += trisPerClick;	//Adds the value to the total;
		totalTris += trisPerClick;		//Statistics
		totalClickValue += trisPerClick;//more statistics
		//particleSystems.Emit(particleEmission);
	}

	//recalculate tris per second, should be called everything something is bought. 
	public void Recalculate(){
		float triTemp = 0;
		float clickTemp = 0;
		clickTemp += clicking * clickingMP;
		//particleEmission = (int)triTemp;

		triTemp += overwork * overworkMP;
		triTemp += programmer * programmerMP;
		triTemp += basement * basementMP;
		triTemp += artist * artistMP;
		triTemp += office * officeMP;
		triTemp += happyHour * happyHourMP;
		triTemp += renderFarms * renderFarmsMP;
		triTemp += quantumComputers * quantumComputersMP;
		triTemp += fullDiveVR * fullDiveVRMP;

		triTemp += triTemp * gameMP;

		if (cheatBool == true) {
			triTemp = triTemp * cheatMP;
			clickTemp = clickTemp * cheatMP;
			Debug.Log ("Hi I am a cheat");
		}

		TrisPerSecond = triTemp;
		trisPerClick = clickTemp;
	}

	public void CheatCheck(){
		cheatBool = !cheatBool;

		Recalculate ();
	}
}
