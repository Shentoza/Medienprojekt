using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

namespace ECS{
	//Singleton class of EntityManager: only one Instance of this object
	public class EntityManager {

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
			if (type.IsSubclassOf (typeof(IComponent))) {
				for (int i = 0; i < entityList.Count; ++i) {
					if (entityList [i].id == entityID) {
						IEntity entity = entityList [i];
						for (int j = 0; j < entity.getList ().Count; ++j) {
							if (entity.getList() [j].GetType () == type) {
								return entity.getList() [j];
							}
						}
					}
				}
				Debug.Log ("Entity with ID " + entityID + " has no Component of type " + type);
			} else {
				Debug.Log ("Second Argument type is not a subclass of IComponent");
			}
			return null;
		}

		//adds a new Entity to the List (ID is generated in IEntity)
		public static void addEntity(IEntity entity){
			entityList.Add (entity);
		}
	
		//returns the entity with the specific id if in List
		public static IEntity getEntity(long id){
			foreach(IEntity entity in entityList){
				if(entity.id == id){
					return entity;
				}
			}
			return null;
		}

		//returns true if the searched entityID is in List.
		//return false if not (DUUUH....)
		public static bool hasEntity(long id){
			foreach(IEntity entity in entityList){
				if(entity.id == id){
					return true;
				}
			}
			return false;
		}

		//returns the entire entityList
		public static List<IEntity> getEntityList(){
			return entityList;
		}

		//returns true if the specific id owns a component of type T (where T : IComponent)
		public static bool hasComponent<T>(long id) where T : IComponent
		{
			IEntity entity = getEntity (id);
			if (entity != null) {
				foreach (IComponent compo in entity.getList ()) {
					if (compo.GetType () == typeof(T)) {
						return true;
					}
				}
			}
			return false;
		}
		
		public static bool hasComponent(long id, Type t)
		{
			IEntity entity = getEntity (id);
			if (entity != null) {
				if (t.IsSubclassOf (typeof(IComponent))) {
					foreach (IComponent compo in entity.getList ()) {
						if (compo.GetType () == t) {
							return true;
						}
					}
				}
			}
			return false;
		}

		public static void addComponent<T>(long id, T component) where T : IComponent
		{
			IEntity entity = getEntity (id);
			if (entity != null) {
				if (!hasComponent<T> (entity)) {
					entity.getList ().Add (component);
				}
			}
		}
		
		public static void addComponent(long id, IComponent component)
		{
			IEntity entity = getEntity (id);
			if (entity != null) {
				Type type = component.GetType ();
				if (!hasComponent (entity, type)) {
					entity.getList ().Add (component);
				}
			}
		}

		//returns true if the specific entity owns a component of type t (checks if t is subclass of IComponent)
		public static bool hasComponent(IEntity entity, Type t)
		{
			if (entity != null) {
				if (t.IsSubclassOf (typeof(IComponent))) {
					foreach (IComponent compo in entity.getList ()) {
						if (compo.GetType () == t) {
							return true;
						}
					}
				}
			}
			return false;
		}

		//returns true if the specific entity owns a component of type T (where T : IComponent)
		//only usable in this class
		public static bool hasComponent<T>(IEntity entity) where T : IComponent
		{
			if (entity != null) {
				foreach (IComponent compo in entity.getList ()) {
					if (compo.GetType () == typeof(T)) {
						return true;
					}
				}
			}
			return false;
		}

		private int generateID(){
			Debug.Log (sizeof(int));
			return UnityEngine.Random.Range(0, sizeof(int));
		}
	}
}
