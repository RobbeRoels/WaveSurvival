using UnityEngine;
using System.Collections;

public class DayNightCycle : MonoBehaviour {
	public float timer=0.0f;
	public bool day=false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (!day) {
			//licht worden
			timer += Time.deltaTime;
			day = (timer >= 10.0f);
		} else {
			//donker worden
			timer-=Time.deltaTime;
			day = !(timer <= 0.0f);
		}
		GetComponent<Light>().intensity=timer*0.75f/10.0f;

	}
}
