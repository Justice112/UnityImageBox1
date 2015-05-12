using UnityEngine;
using System.Collections;
using System.Threading;

public class ThreadTest : MonoBehaviour {
	public Thread thread;
	// Use this for initialization
	void Start () {
		thread= new Thread(  new ThreadStart(HelloWorld));  
		thread.Start(); 
		StartCoroutine(AbortThread());
	}
	
	// Update is called once per frame
	void Update () {

	}
	protected void HelloWorld()   {  
		Debug.Log("string strstring strstring str");  
	}  
	IEnumerator AbortThread() {
		yield return new WaitForSeconds (2);
		if (thread.IsAlive) {
			thread.Abort();
			Debug.Log("Thread is Abort");
		}else {
			Debug.Log("Is Finish");
		}
	}

}
