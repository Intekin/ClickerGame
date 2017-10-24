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

	[Tooltip("If purchased, how much will be added?")]
	public float multiplierAmount;

	public Text costText;
	public Text descText;
	//public Text tooltip;

	private GameController controller;
	private Button button;

	// Use this for initialization
	void Start () {
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
		button.interactable = (controller.CurrentTris >= cost);
	}

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

		controller.Recalculate ();

		gameObject.SetActive(false);
	}
}
