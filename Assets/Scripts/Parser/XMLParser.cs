using UnityEngine;
using System.Collections;
using System.Xml;
using System.IO;
using System.Text;
using System;
using ECS;

public class XMLParser {
	
	public static GameObject[] gameObjectsThroughXML(String path){
		String xmlString = File.ReadAllText(path);
		
		Debug.Log (xmlString);
		int gameObjectCount = countXMLAttribute (xmlString, "Gameobject");
		GameObject[] gameObjects = new GameObject[gameObjectCount];

		using (XmlReader reader = XmlReader.Create(new StringReader(xmlString)))
		{
			while(reader.ReadToFollowing("Gameobject")){
				GameObject gameObject = new GameObject();
				EntityManager.generateEntity(gameObject);
				gameObject.name = reader.GetAttribute ("tag");
				reader.MoveToElement();
				do{
					foreach(Type type in ECSEngine.getComponents()){
						if(reader.GetAttribute("name") == type.Name){
							EntityManager.addComponent(gameObject, type);
						}
					}
				}while(reader.MoveToElement());
			}
		}
		return gameObjects;
	}

	//Not finished yet
	public static GameObject[] gameObjectsThroughXMLDoc(String path){
		XmlDocument doc = new XmlDocument();
		doc.Load(path);
		
		XmlNodeList nodes = doc.DocumentElement.SelectNodes("/Level/Gameobject");
		
		GameObject[] gameObjects = new GameObject[nodes.Count];
		
		int i = 0;
		foreach (XmlNode node in nodes)
		{
			
			gameObjects[i++] = new GameObject();
		}
		Debug.Log (gameObjects.Length);
		return gameObjects;
	}
	
	public static int countXMLAttribute(String xml, String attribute){
		int count = 0;
		
		using (XmlReader reader = XmlReader.Create(new StringReader(xml)))
		{
			while(reader.ReadToFollowing("Gameobject")){
				count++;
			}
		}
		
		return count;
	}
	
}
