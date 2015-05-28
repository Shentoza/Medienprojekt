using System.Collections;
using ECS;

public class AnimationComponent : IComponent
{
	public enum State{
		IDLE,
		WALK,
		RUN,
		ATTACK,
		ROLL,
		ACTION
	}

	public AnimationComponent(State[] s){

	}

	void IComponent.reset(){

	}
}

