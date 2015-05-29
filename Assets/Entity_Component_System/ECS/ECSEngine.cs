using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ECS{
	public class ECSEngine
	{
		private static ECSEngine engine = new ECSEngine();
		
		static List<ISystem> systemList;
		
		private ECSEngine(){
			systemList = new List<ISystem>();
		}
		
		// mainLoop is called once per frame
		public static void mainLoop (float delta)
		{
			foreach(ISystem system in systemList){
				system.update(delta);
			}
		}
		
		public void addSystem(ISystem system){
			systemList.Add (system);
		}
		
		public static ECSEngine getInstance(){
			return engine;
		}

		public List<ISystem> getList(){
			return systemList;
		}
	}
}

