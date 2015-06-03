using System.Collections;
using UnityEngine;
using System;

namespace ECS{
	public abstract class IComponent : MonoBehaviour
	{
		public String typeString;

		public abstract void reset();

		void Awake(){
			addType ();
			Debug.Log (typeString);
		}

		public void addType(){
			typeString = GetType ().Name;
			ECSEngine.addComponentType (this);
		}
	}
}


