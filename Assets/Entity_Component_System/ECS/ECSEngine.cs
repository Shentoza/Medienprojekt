using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ECS{
	public class ECSEngine
	{
		
		static List<ISystem> systemList = new List<ISystem>();
		
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
	}
}

