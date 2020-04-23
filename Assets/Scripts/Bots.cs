using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bots : MonoBehaviour {
	
	private Transform going;
	
	private GameObject img;
	private GameCtrl gc;
	private bool compro = false;
	
	public GameObject Img {
		get { return img; }
		set { img = value; }
	}

	public bool Compro {
		get { return compro; }
	}

	// Use this for initialization
	void Start () {
		gc = GameObject.Find("GameCtrl").GetComponent<GameCtrl>();
		img = transform.GetChild(0).gameObject;
		img.SetActive(false);
		if(transform.position == GameObject.Find("Spawner").GetComponent<Transform>().position) {
			going = GameObject.Find("Destroyer(1)").GetComponent<Transform>();
			
		} else {
			going = GameObject.Find("Destroyer").GetComponent<Transform>();
			transform.rotation = new Quaternion(0,180,0,0);
		}
	}
	
	public void Activate() {
		img.SetActive(true);
		compro = true;
	}
	// Update is called once per frame
	void Update () {
		transform.position = Vector2.MoveTowards(transform.position, going.position, 2 * Time.deltaTime);
//		RaycastHit2D hit = Physics2D.Raycast(new Vector2(Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position).x, Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position).y), Vector2.zero, 0);
//		if(hit) {
//			if(hit.collider.CompareTag("chars")) {
//				print("Clic");
//			}
//		}
	}

	void OnTriggerStay2D(Collider2D other) {
		if(other.CompareTag("Player") && !compro) {
			if( Input.GetMouseButton(0)) {
			Vector3 pos = Input.mousePosition;
			Collider2D hit = Physics2D.OverlapPoint(Camera.main.ScreenToWorldPoint(pos));
			if(hit != null && hit.CompareTag("chars")) {
				Activate();
				gc.vender();
			}
		}
		}
	}

}
