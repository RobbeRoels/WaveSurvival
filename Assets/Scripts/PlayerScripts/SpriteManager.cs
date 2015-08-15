using UnityEngine;
using System.Collections;

public class SpriteManager : MonoBehaviour {

	public Sprite[] availableSprites;
	public int currentSprite = 0;

	SpriteShootMap shootMap = new SpriteShootMap();

	void Awake(){
		GetComponentInChildren<FightBehavior>().sBehavior = shootMap.behavior[currentSprite];
	}


	// Update is called once per frame
	void Update () {
		float mouseWheel = Input.GetAxis ("Mouse ScrollWheel");
		if (mouseWheel < 0) {
			currentSprite ++;
			if(currentSprite >= availableSprites.Length){
				currentSprite = 0;
			}
			GetComponent<SpriteRenderer>().sprite = availableSprites[currentSprite];
			GetComponentInChildren<FightBehavior>().sBehavior = shootMap.behavior[currentSprite];
		} else if (mouseWheel > 0) {
			currentSprite--;
			if(currentSprite < 0){
				currentSprite = availableSprites.Length-1;
			}
			GetComponent<SpriteRenderer>().sprite = availableSprites[currentSprite];
			GetComponentInChildren<FightBehavior>().sBehavior = shootMap.behavior[currentSprite];
		}


	}
}
