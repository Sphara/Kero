using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInteractionScript : InteractionScript {

	//Je fais ca comme ca parce qu'on est en game jam et j'ai la F L E M M E
	public bool isLegs;

	public override void Interact(GameObject InteractionAuthor)
	{
		if (isLegs)
			transform.parent.gameObject.GetComponent<HeronController>().Attack();
		else
			GameObject.Find("Death").GetComponent<Death>().Die();
	}

}
