using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum UpgradeType{
	ClickingMulti,
	OvertimeMulti,
	ProgrammerMulti,
	BasementMulti,
	ArtistMulti,
	OfficeMulti,
	HappyHourMulti,
	RenderFarmMulti,
	QuantumComputerMulti,
	FullDiveVRMulti

}

public class UpgradeItem : MonoBehaviour {
	public UpgradeType upgradeType;

	[Tooltip("Name of upgrade")]
	public string descName;

	[Tooltip("How much will this upgrade cost?")]
	public int cost;

	[Tooltip("Unlock requirement")]
	public int requirement;

	[Tooltip("If purchased, how much will be added?")]
	public float multiplierAmount;

	public Text costText;
	public Text descText;
	//public Text tooltip;

	private GameController controller;
	private Button button;
	private bool bought;
	private float updateTimer = 1; //run the update 1 time every second.


	// Use this for initialization
	void Start () {
		bought = false;

		costText.text = "$" + cost.ToString ();
		descText.text = descName;



		button = transform.GetComponent<Button> ();

		//executes the ButtonClicked function when we click the button
		button.onClick.AddListener(this.ButtonClicked);

		//get a referance to our gamecontroller
		controller = GameObject.FindObjectOfType<GameController>();
	}

	// Update is called once per frame
	private void Update () {
		//To check if it exists Should be limited to once per second.
		updateTimer -= Time.deltaTime;
		if ((bought == false) && (updateTimer <= 0)) {
			Debug.Log ("Updates");
			updateTimer = 1;
			button.interactable = (controller.CurrentTris >= cost);
		}
	}

	//When the Button is clicked do this
	//What type of button was clicked and where to add the new value
	public void ButtonClicked(){
		controller.CurrentTris -= cost;
		switch(upgradeType){
		case UpgradeType.ClickingMulti:
			controller.clickingMP *= multiplierAmount;
			break;

		case UpgradeType.ProgrammerMulti:
			controller.programmerMP *= multiplierAmount;
			break;

		case UpgradeType.BasementMulti:
			controller.basementMP *= multiplierAmount;
			break;

		case UpgradeType.ArtistMulti:
			controller.artistMP *= multiplierAmount;
			break;

		case UpgradeType.OvertimeMulti:
			controller.overworkMP *= multiplierAmount;
			break;

		case UpgradeType.OfficeMulti:
			controller.officeMP *= multiplierAmount;
			break;

		case UpgradeType.HappyHourMulti:
			controller.happyHourMP *= multiplierAmount;
			break;

		case UpgradeType.RenderFarmMulti:
			controller.renderFarmsMP *= multiplierAmount;
			break;

		case UpgradeType.QuantumComputerMulti:
			controller.quantumComputersMP *= multiplierAmount;
			break;

		case UpgradeType.FullDiveVRMulti:
			controller.fullDiveVRMP *= multiplierAmount;
			break;


		}
		bought = true;

		controller.Recalculate ();

		gameObject.SetActive(false);
	}

	//dont know what i will do with this yet
	//Maybe use it to check the requirement to  unlock the upgrade
	private bool CheckRequirement(UpgradeType upgradeTypes){
		switch (upgradeTypes) {
		case UpgradeType.ClickingMulti:
			// return controller.clicking;
			break;

		case UpgradeType.ProgrammerMulti:
			controller.programmerMP *= multiplierAmount;
			break;

		case UpgradeType.BasementMulti:
			controller.basementMP *= multiplierAmount;
			break;

		case UpgradeType.ArtistMulti:
			controller.artistMP *= multiplierAmount;
			break;

		case UpgradeType.OvertimeMulti:
			controller.overworkMP *= multiplierAmount;
			break;

		case UpgradeType.OfficeMulti:
			controller.officeMP *= multiplierAmount;
			break;

		case UpgradeType.HappyHourMulti:
			controller.happyHourMP *= multiplierAmount;
			break;

		case UpgradeType.RenderFarmMulti:
			controller.renderFarmsMP *= multiplierAmount;
			break;

		case UpgradeType.QuantumComputerMulti:
			controller.quantumComputersMP *= multiplierAmount;
			break;

		case UpgradeType.FullDiveVRMulti:
			controller.fullDiveVRMP *= multiplierAmount;
			break;
		}
		return true;
	}
}
