using System;
using ECS;
using UnityEngine;
public class AttributeComponent : IComponent
{


	public float health = 100f;
	public float attack = 100f;
	public float armor = 100f;
	public float speed = 8f;
	public float jumpHeight = 500f;
	public bool isGrounded = true;

	//Velocity is a Vector because there is a x and y velocity which are independent on one another
	//if y > 0 we are in a Jumplike State. Or if y > lastgroundTouched.y
	public Vector2 velocity = new Vector2(0,0);
	public float MAX_VELOCITY = 8;
	public float interpolationTime = 0.0f;

	public void changeVelocityX(float acceleration){
		if (velocity.x < MAX_VELOCITY)
			velocity = new Vector2 (acceleration*speed, 0);
		/*
		 * Acceleration Curve   Damping Curve
		 *                      
		 * 1      ---           1
		 *       -   -           
		 *      -     -          
		 *     -       -         
		 *    -         -        
		 *   -           -       
		 * 0-             -     0
		 */
	}

	public void changeVelocityY(float acceleration){
		Debug.Log (velocity.x + " " + velocity.y + " " + MAX_VELOCITY);
		if (velocity.y < MAX_VELOCITY) {
			velocity.y += 0.1f * acceleration;
		}
	}

	//This is an interpolation method, which interpolates the actual velocity to endVelocity. milliseconds is the time 
	//the interpolation durates. Maybe this method will be in PhysicsSystem.
	//This will be a linear Interpolation
	public bool interpolateVelocityLinear(float endVelocity, float milliseconds, float delta){
		if (interpolationTime >= milliseconds) {
			interpolationTime = 0.0f;
			velocity.x = endVelocity;
			return false;
		}
		velocity.x = interpolationTime / milliseconds * endVelocity;
		interpolationTime += delta;
		return true;
	}

	//This is a quadratic interpolation between velocity and endVelocity
	public bool interpolateVelocityQuadratic(float endVelocity, float milliseconds, float delta){
		if (interpolationTime >= milliseconds) {
			interpolationTime = 0.0f;
			velocity.x = endVelocity;
			return false;
		}
		velocity.x = (interpolationTime / milliseconds)*(interpolationTime / milliseconds) * endVelocity;
		interpolationTime += delta;
		return true;
	}

	//This is a quadratic interpolation between velocity and endVelocity
	public bool interpolateVelocitySquaric(float endVelocity, float milliseconds, float delta){
		if (interpolationTime >= milliseconds) {
			interpolationTime = 0.0f;
			velocity.x = endVelocity;
			return false;
		}
		velocity.x = (interpolationTime / milliseconds)/(interpolationTime / milliseconds) * endVelocity;
		interpolationTime += delta;
		return true;
	}

	override public void reset(){
		health = 100;
		attack = 100;
		armor = 100;
		velocity = new Vector2(0,0);
	}
}


