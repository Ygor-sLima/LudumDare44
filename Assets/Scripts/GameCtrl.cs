using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameCtrl : MonoBehaviour {

	// levels
	public static int level = 1;
	public static int shopLvl = 1;	
	public static int botsLvl = 1;

	// utilizacao
	public Sprite[] pote;
	public GameObject shop;
	public GameObject poteObj;
	public float[] poteYPos;
	public Sprite[] barraca;
	public float[] timeBtwSpawn;
	public int[] range;
	private int[] lvlVend = {10, 25, 100, 250};
	private int[] shopUpg = {100, 250, 500, 9001};
	//UI
	public Text txtVendas;
	public Text txtBuy;
	public Text txtSpwn;
	public Text txtLv;

	// money
	public static int vendas = 0;

	public int BotsLvl {
		get { return botsLvl;}
	}

	public int ShopLvl {
		get{ return shopLvl;}
	}
	
	void Start() {
		if(level == 4) {
			changeShop(pote[2],barraca[2], poteYPos[2]);	
		}
		else {
			changeShop(pote[level -1],barraca[level -1], poteYPos[level -1]);
		}
	}
	// Update is called once per frame
	void Update () {
		txtVendas.text = "$ " + vendas;
		if(shopLvl == 5) {
			txtBuy.text = "MAX LEVEL";
		}else {
			txtBuy.text = "Buy chance $ " + lvlVend[shopLvl - 1];
		}

		if(botsLvl == 5) {
			txtSpwn.text = "MAX LEVEL";
		}else {
			txtSpwn.text = "++Spawn Rate $ " + lvlVend[botsLvl - 1];
		}
		txtLv.text = "LeveL Up $ " + shopUpg[level -1];
	}
	private void changeShop(Sprite s,Sprite shop, float fa) {
		poteObj.GetComponent<Transform>().position = new Vector3(7.83f, fa, -3f);
		poteObj.GetComponent<SpriteRenderer>().sprite = s;
		this.shop.GetComponent<SpriteRenderer>().sprite = shop;
	}
	public void vender() {
		vendas++;
	}
	public void levelUp() {
		if(level == 5) {
			return;
		}
		else {
			if (vendas >= shopUpg[level - 1]) {
				vendas -= shopUpg[level -1];
				level++;
				SceneManager.LoadScene("Main");
			}
		}
	}

	public void levelUpBots() {
		if(botsLvl == 5) {
			return;
		}
		else {
			if(vendas >= lvlVend[botsLvl - 1]) {
				vendas -= lvlVend[botsLvl - 1];
				botsLvl++;
			}
		}
	}
	public void levelUpShop() {
		if(shopLvl == 5) {
			return;
		}
		
		if(vendas >= lvlVend[shopLvl - 1]) {
			vendas -= lvlVend[shopLvl - 1];
			shopLvl++;
		}
	}
}
