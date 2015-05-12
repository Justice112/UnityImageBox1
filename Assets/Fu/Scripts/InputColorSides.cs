/// <summary>
/// Author: Fu
/// Function: 
/// </summary>
using UnityEngine;
using System.Collections;

public class InputColorSides : MonoBehaviour {
	private string [] sidesColors = new string[6];
	private Main main ;
	// Use this for initialization
	void Start () {
		for (int i =0;i<sidesColors.Length;i++) {
			sidesColors[i]="点击输入"+i+"面颜色";
		}
		main = transform.GetComponent<Main>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnGUI () {
		GUILayout.Label ("U:黄色中心");
		sidesColors[0]=GUILayout.TextField(sidesColors[0],100);
		GUILayout.Label ("R:红色中心");
		sidesColors[1]=GUILayout.TextField(sidesColors[1],100);
		GUILayout.Label ("D:白色中心");
		sidesColors[2]=GUILayout.TextField(sidesColors[2],100);
		GUILayout.Label ("L:橙色中心");
		sidesColors[3]=GUILayout.TextField(sidesColors[3],100);
		GUILayout.Label ("F:蓝色中心");
		sidesColors[4]=GUILayout.TextField(sidesColors[4],100);
		GUILayout.Label ("B:绿色中心");
		sidesColors[5]=GUILayout.TextField(sidesColors[5],100);
		if ( GUILayout.Button("OK")) {
			main.SideColors = sidesColors;
		}
	}
}
