using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Manager : MonoBehaviour {

    GameObject Player;
    PlayerManager playerManager;

    Text displayCurrency;
    Slider hitPoints;
	// Use this for initialization
	void Start () {
        Player = GameObject.FindGameObjectWithTag("Player");
        playerManager = Player.GetComponent<PlayerManager>();
        displayCurrency = GetComponentInChildren<Text>();
        hitPoints = GetComponentInChildren<Slider>();
        hitPoints.maxValue = playerManager.hitPoints;
    }
	
	// Update is called once per frame
	void Update () {
        displayCurrency.text = "" + playerManager.cashValue;
        hitPoints.value = playerManager.hitPoints;
    }
}
