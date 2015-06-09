using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace ECS{
	public class ECSEngine
	{
		
		static List<ISystem> systemList = new List<ISystem>();
		static List<Type> components = new List<Type> ();
		
		// mainLoop is called once per frame
		public static void mainLoop (float delta)
		{
			foreach(ISystem system in systemList){
				system.update(delta);
			}
		}
		
		public static void addSystem(ISystem system){
			systemList.Add (system);
		}

		public static List<ISystem> getList(){
			return systemList;
		}

		public static void addComponentType(Type compo){
			if(compo.IsSubclassOf(typeof(ICompoenent))){
				foreach (Type c in components) {
					if(c == compo){
						return;
					}
				}
				components.Add (compo);
			}
		}

		public static List<IComponent> getComponents(){
			return components;
		}
	}
}

