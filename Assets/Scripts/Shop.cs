using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour {

	private int range;
	private GameCtrl gc;
	// Use this for initialization
	void Start () {
		gc = GameObject.Find("GameCtrl").GetComponent<GameCtrl>();
	}
	
	// Update is called once per frame
	void Update () {
		range = gc.range[gc.ShopLvl - 1];
	}

	void OnTriggerEnter2D(Collider2D other) {
    Bots b = other.GetComponent<Bots>();
		if(!b.Compro) {
			int compro = Random.Range(0, range);

    	if(compro == 0) {
       	other.GetComponent<Bots>().Activate();
				gc.vender();
     	}
		}	
  }



}
