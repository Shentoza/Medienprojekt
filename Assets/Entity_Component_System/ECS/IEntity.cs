using System;
using System.Collections.Generic;
using UnityEngine;

namespace ECS{
	public class IEntity
	{
		static long idCounter = 0;
		public long id;
		private List<IComponent> componentList;

		public IEntity ()
		{
			componentList = new List<IComponent>();
			id = idCounter;
			Debug.Log ("new Entity with id " + id + "\n");
			idCounter++;
		}

		public List<IComponent> getList(){
			return componentList;
		}

		void OnDestroy(){

		}
	}
}


