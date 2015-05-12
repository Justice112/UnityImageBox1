/// <summary>
/// Author: Fu
/// CreateDate: 2015-05-01
/// Function: 设置魔方颜色
/// </summary>
using UnityEngine;
using System.Collections;

public class SetImageBox : MonoBehaviour {
	public Transform [] Cubes0 = new Transform[9];
	public Transform [] Cubes1 = new Transform[9];
	public Transform [] Cubes2= new Transform[9];
	public Transform [] Cubes3 = new Transform[9];
	public Transform [] Cubes4 = new Transform[9];
	public Transform [] Cubes5 = new Transform[9]; 
	public Material [] CubeMaterials= new Material[6]; 
	// Use this for initialization
	void Start () {
		for (int k = 0; k<9;k ++) {
			Cubes0[k]=GameObject.Find("0"+k).transform; 
			Cubes1[k]=GameObject.Find("1"+k).transform; 
			Cubes2[k]=GameObject.Find("2"+k).transform; 
			Cubes3[k]=GameObject.Find("3"+k).transform; 
			Cubes4[k]=GameObject.Find("4"+k).transform; 
			Cubes5[k]=GameObject.Find("5"+k).transform;   
		}     
	} 
	public void SetCubeColors(string [] colors) {  
		if(colors.Length!=6) {
			Debug.Log(" 所给的颜色组不对!");
			return;
		}
		for (int i = 0; i<colors.Length;i++) {
			colors[i].ToCharArray();
		} 
		for (int j=0; j<9; j++) {
			Cubes0[j].GetComponent<Renderer>().material = getMaterial(colors[0][j]);
			Cubes1[j].GetComponent<Renderer>().material = getMaterial(colors[1][j]);
			Cubes2[j].GetComponent<Renderer>().material = getMaterial(colors[2][j]);
			Cubes3[j].GetComponent<Renderer>().material = getMaterial(colors[3][j]);
			Cubes4[j].GetComponent<Renderer>().material = getMaterial(colors[4][j]);
			Cubes5[j].GetComponent<Renderer>().material = getMaterial(colors[5][j]);
		} 
	}
	private Material getMaterial (char color) {
		Material material=null; 
		for(int k = 0; k<CubeMaterials.Length;k++) {
			if(CubeMaterials[k].name==color.ToString()) {
				material=CubeMaterials[k];
				continue;
			}
		} 
		return material; 
	}

}
