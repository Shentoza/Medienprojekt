using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

namespace ECS{
	//Singleton class of EntityManager: only one Instance of this object
	public class EntityManager {

		static List<GameObject> entityDir = new List<GameObject> ();

		/*returns a component of a specific entityID:
		 * returns component if 
		 * 	-this entity exists and has the component of Type type
		 * return null if
		 * 	-the entity does not exist
		 * 	-the entity does exist but doesn't have the component of Type type
		 * */
		public static Component getComponent(GameObject entity, Type type)
		{
			if (type.IsSubclassOf (typeof(Component))) {
				return entity.GetComponent (type);
			}
			return null;
		}

		//Generates a new Entity if not in Directory
		public static void generateEntity(GameObject entity){
			if (!entityDir.Contains(entity)) {
				entityDir.Add (entity);
			}
		}

		//returns true if the searched entityID is in Directory.
		//returns false if not (DUUUH....)
		public static bool hasEntity(GameObject entity){
			return entityDir.Contains (entity);
		}

		
		public static bool hasComponent(GameObject entity, Type t)
		{
			if(t.IsSubclassOf(typeof(Component))){
				if(hasEntity (entity)){
					return (entity.GetComponent(t) == null) ? false : true;
				}
			}
			return false;
		}
		
		public static Component addComponent(GameObject entity, Type component)
		{
			if (component.IsSubclassOf (typeof(Component))) {
				if (entityDir.Contains (entity)) {
					if (!hasComponent (entity, component)) {
						entity.AddComponent (component);
					}
				}else{
					generateEntity (entity);
					entity.AddComponent (component);
				}
			}
			return entity.GetComponent (component);
		}

		public static void printStatus(){
			string status = "Status: \n";
			foreach (GameObject entity in entityDir) {
				status += "Entity (" + entity.GetInstanceID() + ")\n";
				foreach(Component compo in entity.GetComponents(typeof(Component))){
					status += "\t" + compo.GetType () + "\n";
				}
			}
			Debug.Log(status);

			string status2 = "Status: \n";
			foreach (GameObject entity in getGameObjectsWithComponents(typeof(PlayerComponent))) {
				status2 += "Entity (" + entity.GetInstanceID() + ")\n";
				foreach(Component compo in entity.GetComponents(typeof(Component))){
					status2 += "\t" + compo.GetType () + "\n";
				}
			}
			Debug.Log(status2);


		}

		public static GameObject[] getGameObjectsWithComponents(params Type[] t){
			List<GameObject> list = new List<GameObject>();

			foreach (GameObject g  in entityDir) {
				bool hasAllCompos = true;
				for(int i = 0; i < t.Length; i++){
					if(!hasComponent (g, t[i])){
						hasAllCompos = false;
					}
				}
				if(hasAllCompos){
					list.Add (g);
				}
			}

			GameObject[] go = new GameObject[list.Count];
			for (int i = 0; i < list.Count; ++i) {
				go[i] = list[i];
			}
			return go;
		}
	}
}
