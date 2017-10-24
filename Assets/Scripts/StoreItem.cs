using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum BuildingType{
	Overwork, 
	Programmer,
	Basement,
	Artist,
	Office,
	HappyHour,
	RenderFarms,
	QuantumComputers,
	FullDiveVR,


};

public class StoreItem : MonoBehaviour {


	[Tooltip("Name of Building")]
	public BuildingType buildingType;

	[Tooltip("How much will this upgrade cost?")]
	public int cost;

	[Tooltip("Cost increase?")]
	public float costIncrease = 1.15f;

	[Tooltip("If purchased, how much will be added?")]
	public float increaseAmount;

	private int qty;

	public Text costText;
	public Text qtyText;
	public Text descText;
	//public Text tooltip;

	private GameController controller;
	private Button button;
		
	// Use this for initialization
	void Start () {
		qty = 0;
		qtyText.text = "Qty: " + qty.ToString ();
		costText.text = "$" + cost.ToString ();
		descText.text = buildingType.ToString();

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
		float tempCost;

		switch(buildingType){
		case BuildingType.Overwork:
			controller.overwork += increaseAmount;
			tempCost = 0f;
			tempCost = (float)cost * costIncrease;
			cost = (int)tempCost;
			break;

		case BuildingType.Programmer:
			controller.programmer += increaseAmount;
			tempCost = 0f;
			tempCost = (float)cost * costIncrease;
			cost = (int)tempCost;
			break;

		case BuildingType.Basement:
			controller.basement += increaseAmount;
			tempCost = 0f;
			tempCost = (float)cost * costIncrease;
			cost = (int)tempCost;
			break;

		case BuildingType.Artist:
			controller.artist += increaseAmount;
			tempCost = 0f;
			tempCost = (float)cost * costIncrease;
			cost = (int)tempCost;
			break;

		case BuildingType.Office:
			controller.office += increaseAmount;
			tempCost = 0f;
			tempCost = (float)cost * costIncrease;
			cost = (int)tempCost;
			break;

		case BuildingType.HappyHour:
			controller.happyHour += increaseAmount;
			tempCost = 0f;
			tempCost = (float)cost * costIncrease;
			cost = (int)tempCost;
			break;

		case BuildingType.RenderFarms:
			controller.renderFarms += increaseAmount;
			tempCost = 0f;
			tempCost = (float)cost * costIncrease;
			cost = (int)tempCost;
			break;

		case BuildingType.QuantumComputers:
			controller.quantumComputers += increaseAmount;
			tempCost = 0f;
			tempCost = (float)cost * costIncrease;
			cost = (int)tempCost;
			break;

		case BuildingType.FullDiveVR:
			controller.fullDiveVR += increaseAmount;
			tempCost = 0f;
			tempCost = (float)cost * costIncrease;
			cost = (int)tempCost;
			break;

		}
		qty++;
		qtyText.text = "Qty: " + qty.ToString();
		costText.text = "Cost: " + cost.ToString ();

		controller.Recalculate ();
	}
}
