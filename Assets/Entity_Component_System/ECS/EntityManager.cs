using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

namespace ECS{
	//Singleton class of EntityManager: only one Instance of this object
	public class EntityManager {

		static Dictionary<GameObject, List<Type>> entityDir = new Dictionary<GameObject, List<Type>> ();

		/*returns a component of a specific entityID:
		 * returns component if 
		 * 	-this entity exists and has the component of Type type
		 * return null if
		 * 	-the entity does not exist
		 * 	-the entity does exist but doesn't have the component of Type type
		 * */
		public static Type getComponent(GameObject entity, Type type)
		{
			if (type.IsSubclassOf (typeof(IComponent)) && hasEntity(entity)) {
				foreach(Type compo in entityDir[entity]){
					if(compo == type){
						return compo;
					}
				}
			}
			return null;
		}

		//Generates a new Entity if not in Directory
		public static void generateEntity(GameObject entity){
			if (!entityDir.ContainsKey (entity)) {
				entityDir.Add (entity, new List<Type> ());
			}
		}

		//returns true if the searched entityID is in Directory.
		//returns false if not (DUUUH....)
		public static bool hasEntity(GameObject entity){
			return entityDir.ContainsKey (entity);
		}

		
		public static bool hasComponent(GameObject entity, Type t)
		{
			if(t.IsSubclassOf(typeof(IComponent))){
				if(hasEntity (entity)){
					foreach(Type compo in entityDir[entity]){
						if(compo == t){
								return true;
							}
					}
				}
			}
			return false;
		}
		
		public static void addComponent(GameObject entity, Type component)
		{
			if (component.IsSubclassOf (typeof(IComponent))) {
				if (entityDir.ContainsKey (entity)) {
					if (!hasComponent (entity, component)) {
						entityDir[entity].Add (component);
					}
				}else{
					generateEntity (entity);
					entityDir[entity].Add (component);
				}
			}
		}

		public static void printStatus(){
			string status = "Status: \n";
			foreach (GameObject entity in entityDir.Keys) {
				status += "Entity (" + entity.GetInstanceID() + ")\n";
				foreach(Type compo in entityDir[entity]){
					status += "\t" + compo + "\n";
				}
			}
			Debug.Log(status);

		}
	}
}
