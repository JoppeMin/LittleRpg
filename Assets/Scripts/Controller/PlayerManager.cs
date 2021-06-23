using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour {

    public int hitPoints;

    public int cashValue;
    Text cash;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    void Start () {
        
	}

    // Update is called once per frame
    void Update () {

	}
}
