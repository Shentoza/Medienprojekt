using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

namespace ECS{
	//Singleton class of EntityManager: only one Instance of this object
	public class EntityManager {

		static Dictionary<long, List<IComponent>> entityDir = new Dictionary<long, List<IComponent>> ();
		//List of all Entities in game
		static List<IEntity> entityList = new List<IEntity> ();

		/*returns a component of a specific entityID:
		 * returns component if 
		 * 	-this entity exists and has the component of Type type
		 * return null if
		 * 	-the entity does not exist
		 * 	-the entity does exist but doesn't have the component of Type type
		 * */
		public static IComponent getComponent(long entityID, Type type)
		{
			if (type.IsSubclassOf (typeof(IComponent)) && hasEntity(entityID)) {
				foreach(IComponent compo in entityDir[entityID]){
					if(compo.GetType() == type){
						return compo;
					}
				}
			}
			return null;
		}

		//adds a new Entity to the List (ID is generated in IEntity)
		public static void addEntity(IEntity entity){
			entityList.Add (entity);
			entityDir.Add (entity.id, new List<IComponent>());
		}

		//returns true if the searched entityID is in List.
		//return false if not (DUUUH....)
		public static bool hasEntity(long id){
			return entityDir.ContainsKey (id);
		}

		//returns true if the specific id owns a component of type T (where T : IComponent)
		public static bool hasComponent<T>(long id) where T : IComponent
		{
			if(hasEntity (id)){
				foreach(IComponent compo in entityDir[id]){
					if(compo.GetType () == typeof(T)){
						return true;
					}
				}
			}
			return false;
		}
		
		public static bool hasComponent(long id, Type t)
		{
			if(hasEntity (id)){
				foreach(IComponent compo in entityDir[id]){
					if(compo.GetType () == t){
							return true;
						}
				}
			}
			return false;
		}

		public static void addComponent<T>(long id, T component) where T : IComponent
		{
			if (entityDir.ContainsKey(id)) {
				if(!hasComponent<T>(id)){
					entityDir[id].Add (component);
				}
			}
		}
		
		public static void addComponent(long id, IComponent component)
		{
			if (entityDir.ContainsKey (id)) {
				Type type = component.GetType ();
				if (!hasComponent (id, type)) {
					entityDir[id].Add (component);
				}
			}
		}

		//returns true if the specific entity owns a component of type t (checks if t is subclass of IComponent)
		public static bool hasComponent(IEntity entity, Type t)
		{
			return hasComponent (entity.id, t);
		}

		//returns true if the specific entity owns a component of type T (where T : IComponent)
		//only usable in this class
		public static bool hasComponent<T>(IEntity entity) where T : IComponent
		{
			return hasComponent<T> (entity.id);
		}

		private int generateID(){
			return UnityEngine.Random.Range(0, int.MaxValue);
		}
	}
}
