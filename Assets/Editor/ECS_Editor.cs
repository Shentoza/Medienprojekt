using UnityEngine;
using UnityEditor;
using System.Collections.Generic;
using System.IO;
using System;
using ECS;

namespace Editor {
	public class ECS_Editor : EditorWindow {
		[MenuItem ("Window/ECS/ECS_Editor")]

		public static void ShowWindow () {
			EditorWindow win = EditorWindow.GetWindow<ECS_Editor> ("Sprite normals tool", true);
			win.minSize = new Vector2 (100, 100);
		}

		private GameObject gameObject;
		public Type component;
		public Vector3 gposition;

		public List<bool> componentsBool;

		public void OnGUI () {
			EditorGUILayout.BeginVertical ();
			{
				gposition = EditorGUILayout.Vector3Field("Position", gposition);

				EditorGUILayout.BeginToggleGroup("Player/Enemy", true);
					for(int i = 0; i < ECSEngine.getComponents().Count; ++i){
						EditorGUILayout.Toggle(ECSEngine.getComponents()[i].Name, false);
					}
				EditorGUILayout.EndToggleGroup();

				//component = IComponent.getComponentType();
				EditorGUILayout.Space ();
				if (GUILayout.Button ("Generate Gameobject"))
					generateGameobject();

				GUI.enabled = true;
			}
			EditorGUILayout.EndVertical ();
		}
		
		private void generateGameobject () {
			gameObject = new GameObject ();
			gameObject.tag = "ECS_Gameobject";
			gameObject.transform.position = gposition;
			Instantiate (gameObject);
			EntityManager.generateEntity (gameObject);
			if (component != null) {
				EntityManager.addComponent (gameObject, component);
			}
			gposition = new Vector2 ();
		}
	}
}