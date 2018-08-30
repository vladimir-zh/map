using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelManager : MonoBehaviour {
	Animator anim;
	GameObject panel;
	//public bool isPlayed = false;

	// Use this for initialization
	public void Start () {
		anim = GetComponent<Animator> ();
		//AnimPlay ();
	}
	
	// Update is called once per frame
	void Update () {

	}
	public void ExitPanel(){
			anim.Play ("back");	
	}
	public void AnimPlay(){
		anim.Play ("start");
	}
}
