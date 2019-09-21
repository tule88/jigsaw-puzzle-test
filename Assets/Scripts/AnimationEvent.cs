using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Script for Event Triggers in animations

public class AnimationEvent : MonoBehaviour {

	public void AllowPickingPeaces()
    {
        GameControl.instance.canPickPiece = true; //Allow picking puzzle pieces after animation
    }
}
