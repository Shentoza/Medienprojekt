using System;
using System.Collections.Generic;
using UnityEngine;

namespace ECS{
	public class IEntity
	{
		public int id;

		public IEntity (int id)
		{
			this.id = id;
			Debug.Log ("new Entity with id " + id + "\n");
		}

		void OnDestroy(){

		}
	}
}


