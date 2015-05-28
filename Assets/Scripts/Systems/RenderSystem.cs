using System;
using ECS;

public class RenderSystem : ISystem
{
	public RenderSystem ()
	{
		foreach (IEntity entity in ECSEngine.getInstance ().getList ()) {

		}

	}

	void ISystem.update(float delta){

	}
}


