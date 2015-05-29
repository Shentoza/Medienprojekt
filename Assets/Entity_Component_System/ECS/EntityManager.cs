using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

namespace ECS{
	//Singleton class of EntityManager: only one Instance of this object
	public class EntityManager {

		static Dictionary<int, List<Type>> entityDir = new Dictionary<int, List<Type>> ();

		/*returns a component of a specific entityID:
		 * returns component if 
		 * 	-this entity exists and has the component of Type type
		 * return null if
		 * 	-the entity does not exist
		 * 	-the entity does exist but doesn't have the component of Type type
		 * */
		public static Type getComponent(int entityID, Type type)
		{
			if (type.IsSubclassOf (typeof(IComponent)) && hasEntity(entityID)) {
				foreach(Type compo in entityDir[entityID]){
					if(compo == type){
						return compo;
					}
				}
			}
			return null;
		}

		public static int generateEntity(){
			int id = generateID ();
			while (entityDir.ContainsKey (id)) {
				id = generateID();
			}
			entityDir.Add (id, new List<Type> ());
			return id;
		}

		//returns true if the searched entityID is in Directory.
		//returns false if not (DUUUH....)
		public static bool hasEntity(int id){
			return entityDir.ContainsKey (id);
		}

		
		public static bool hasComponent(int id, Type t)
		{
			if(t.IsSubclassOf(typeof(IComponent))){
				if(hasEntity (id)){
					foreach(Type compo in entityDir[id]){
						if(compo == t){
								return true;
							}
					}
				}
			}
			return false;
		}
		
		public static void addComponent(int id, Type component)
		{
			if (component.IsSubclassOf (typeof(IComponent))) {
				if (entityDir.ContainsKey (id)) {
					if (!hasComponent (id, component)) {
						entityDir[id].Add (component);
					}
				}
			}
		}

		//returns true if the specific entity owns a component of type t (checks if t is subclass of IIComponent)
		public static bool hasComponent(IEntity entity, Type t)
		{
			return hasComponent (entity.id, t);
		}

		private static int generateID(){
			return UnityEngine.Random.Range(0, int.MaxValue);
		}

		public static void printStatus(){
			string status = "Status: \n";
			foreach (int id in entityDir.Keys) {
				status += "Entity (" + id + ")\n";
				foreach(Type compo in entityDir[id]){
					status += "\t" + compo + "\n";
				}
			}
			Debug.Log(status);

		}
	}
}
