using System;
using ECS;
using UnityEngine;
public class InputComponent : IComponent{


	private String m_inputLeft, m_inputRight, m_inputUp, m_inputAttack, m_inputAction1, m_inputAction2;

	public InputComponent(String inputLeft, String inputRight, String inputUp, String inputAttack, 
	                      String inputAction1, String inputAction2)
	{
		this.m_inputLeft = inputLeft;
		this.m_inputRight = inputRight;
		this.m_inputUp = inputUp;
		this.m_inputAttack = inputAttack;
		this.m_inputAction1 = inputAction1;
		this.m_inputAction2 = inputAction2;
	}

	override public void reset(){
		m_inputLeft = "A";
		m_inputRight = "D";
		m_inputUp = "W";
		m_inputAttack = "Space";
		m_inputAction1 = "O";
		m_inputAction2 = "P";
	}

	public String getInputLeft(){
		return m_inputLeft;
	}
	
	public void setInputLeft(String inputLeft){
		m_inputLeft = inputLeft;
	}
	
	public String getInputRight(){
		return m_inputRight;
	}
	
	public void setInputRight(String inputRight){
		m_inputRight = inputRight;
	}
	
	public String getInputUp(){
		return m_inputUp;
	}
	
	public void setInputUp(String inputUp){
		m_inputUp = inputUp;
	}

	public String getInputAttack(){
		return m_inputLeft;
	}
	
	public void setInputAttack(String inputAttack){
		m_inputAttack = inputAttack;
	}
	
	public String getInputAction_1(){
		return m_inputAction1;
	}
	
	public void setInputAction_1(String inputAction1){
		m_inputAction1 = inputAction1;
	}
	
	public String getInputAction_2(){
		return m_inputAction2;
	}
	
	public void setInputAction_2(String inputAction2){
		m_inputAction2 = inputAction2;
	}
}
