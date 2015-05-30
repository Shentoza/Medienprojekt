using System;
using ECS;
using UnityEngine;
public class InputComponent : IComponent{


	public String inputLeft = "a";
	public String inputRight = "d";
	public String inputUp = "w";
	public String inputAttack = "space"; 
	public String inputAction1 = "o";
	public String inputAction2 = "p";

	override public void reset(){
		inputLeft = "a";
		inputRight = "s";
		inputUp = "w";
		inputAttack = "space";
		inputAction1 = "o";
		inputAction2 = "p";
	}
}
