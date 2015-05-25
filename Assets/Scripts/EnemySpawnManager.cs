using UnityEngine;

public class MySingletonManager : MonoBehaviour {
	//Static singleton property
	public static MySingletonManager Instance {
		get; private set;
	}
	//public property for manager
	public string MyTestProperty = "Hello World";
	void Awake()
	{
		//Save our current singleton instance
		Instance = this;
	}
	//public method for manager
	public void DoSomethingAwesome()
	{ }
}