/// <summary>
/// Author:
/// CreateDate: 
/// Function:移动魔方脚本，通过输入的公式，选择魔方
/// </summary>
using UnityEngine;
using System.Collections;

public class MagicCubeRotate : MonoBehaviour {
	public Transform[] cube= new Transform[20];
	public  int i=20;
	private int count;
	public int length;
	public  string formula="ruRU";
	public Vector2 scrollPosition = Vector2.zero; 
//	private string[] pll={"UruRuRURurURURRurU","RUrurBRRuruRUrb","RuRURURururr"}; 
	
	//移动父对象
	public Transform left_center;
	public Transform right_center;
	public Transform up_center;
	public Transform down_center;
	public Transform forward_center;
	public Transform back_center;

	//状态变量
	private bool isF;
    	private bool isB;
	private bool isL;
	private bool isR;
	private bool isU;
	private bool isD;
	private bool isf;
    	private bool isb;
	private bool isl;
	private bool isr;
	private bool isu;
	private bool isd; 

	public bool isAuto;
	public bool isPlay;
	public bool isenable=true;
	//
	private  GameObject []cubes ;

	// Use this for initialization
	void Start () {
		cubes = GameObject.FindGameObjectsWithTag("Cube");
		for(int i=0;i<cubes.Length;i++) {
			cube[i] = cubes[i].transform;
		} 
	}
	void Awake() {
		count=0;
		isAuto=false;
	}
	void OnGUI() {
//		GUI.Label(new Rect(10,10,100,20),"输入你的公式：");
//		formula=GUI.TextField(new Rect(100,10,200,30),formula);
//		if(GUI.Button(new Rect(10,40,80,40),"ok")&&isPlay==false){
//			isAuto=true;
//			isPlay=true;
//			length=formula.Length;
//		}
//		scrollPosition=GUI.BeginScrollView(new Rect(10,80,150,250),scrollPosition,new Rect(0, 0, 220, 300));
//		GUI.Label(new Rect(0,0,100,30),"pll公式1：");
//		GUI.Label(new Rect(0,30,100,60),pll[0]);
//		GUI.Label(new Rect(0,60,100,30),"pll公式2：");
//		GUI.Label(new Rect(0,90,100,60),pll[1]);
//		GUI.EndScrollView();
		
	}

	public void RestoreImageBox () {
		if (formula!=null) {
			isAuto=true;
			isPlay=true;
			length=formula.Length;
		}else {
			return;
		}
	}
	// Update is called once per frame
	void Update () { 
		if(isAuto){
			switch(formula[count])
			{
				case'F':isF=true;isAuto=false; break;
				case'D':isD=true;isAuto=false; break;
				case'R':isR=true;isAuto=false; break;
				case'B':isB=true;isAuto=false; break;
				case'U':isU=true;isAuto=false; break;
				case'L':isL=true;isAuto=false; break;
				case'f':isf=true;isAuto=false; break;
				case'd':isd=true;isAuto=false; break;
				case'r':isr=true;isAuto=false; break;
				case'b':isb=true;isAuto=false; break;
				case'u':isu=true;isAuto=false; break;
				case'l':isl=true;isAuto=false; break; 
			}  
		}
//		//输入控制
//		
//		if(Input.GetKeyDown(KeyCode.F)){ 
//			if(isenable){
//				isF=true;
//				isenable=false;
//			}
//		}
//		if(Input.GetKeyDown(KeyCode.B)){
//			if(isenable){
//				isB=true;
//				isenable=false;
//			}
//		}
//		if(Input.GetKeyDown(KeyCode.U)){
//			if(isenable){
//				isU=true;
//				isenable=false;
//			}
//		}
//		if(Input.GetKeyDown(KeyCode.D)){
//			if(isenable){
//				isD=true;
//				isenable=false;
//			}
//		}
//		if(Input.GetKeyDown(KeyCode.L)){
//			if(isenable){
//				isL=true;
//				isenable=false;
//			}
//		}
//		if(Input.GetKeyDown(KeyCode.R)){
//			if(isenable){
//				isR=true;
//				isenable=false;
//			}
//		}  
		if(isD) { 
			for(i=0;i<20;i++) {
				//cube[i].DetachChildren();
				eight_point(1,down_center); 
		    } 
			iTweenEvent.GetEvent(GameObject.Find("down_center"),"down").Play();
			isD=false;
		 }
		if(isd) { 
			for(i=0;i<20;i++) {
				//cube[i].DetachChildren();
				eight_point(1,down_center); 	
		    } 
			iTweenEvent.GetEvent(GameObject.Find("down_center"),"d").Play();
			isd=false;
		 }
		if(isB) { 
			for(i=0;i<20;i++) {
				//cube[i].DetachChildren();
				eight_point(2,back_center); 
		    }
			iTweenEvent.GetEvent(GameObject.Find("back_center"),"back").Play();
			isB=false;
		 }
		if(isb) { 
			for(i=0;i<20;i++) {
				//cube[i].DetachChildren();
				eight_point(2,back_center); 	
		    }
			iTweenEvent.GetEvent(GameObject.Find("back_center"),"b").Play();
			isb=false;
		 }
		if(isF) { 
			for(i=0;i<20;i++) {
				//cube[i].DetachChildren();
				eight_point(2,forward_center);
				
		    }	
			iTweenEvent.GetEvent(GameObject.Find("forward_center"),"forward").Play();
			isF=false;
		 }
		if(isf) { 
			for(i=0;i<20;i++) {
				//cube[i].DetachChildren();
				eight_point(2,forward_center); 
		    }	
			iTweenEvent.GetEvent(GameObject.Find("forward_center"),"f").Play();
			isf=false;
		 }
		if(isU) { 
			for(i=0;i<20;i++) {
				//cube[i].DetachChildren();
				eight_point(1,up_center); 
		    }
			iTweenEvent.GetEvent(GameObject.Find("up_center"),"up").Play();
			isU=false;
		 }
		if(isu) { 
			for(i=0;i<20;i++) {
				//cube[i].DetachChildren();
				eight_point(1,up_center); 
		    }
			iTweenEvent.GetEvent(GameObject.Find("up_center"),"u").Play();
			isu=false;
		 }
		if(isL) { 
			for(i=0;i<20;i++) {
				//cube[i].DetachChildren();
				eight_point(0,left_center); 
		    }
			iTweenEvent.GetEvent(GameObject.Find("left_center"),"left").Play();
			isL=false;
		 }
		if(isl) { 
			for(i=0;i<20;i++) {
				//cube[i].DetachChildren();
				eight_point(0,left_center);
				
		    }
			iTweenEvent.GetEvent(GameObject.Find("left_center"),"l").Play();
			isl=false;
		 }
		if(isR) { 
			for(i=0;i<20;i++) {
				//cube[i].DetachChildren();
				eight_point(0,right_center); 
		    }
			iTweenEvent.GetEvent(GameObject.Find("right_center"),"right").Play();
			isR=false;
		 }
		if(isr) { 
			for(i=0;i<20;i++) {
				//cube[i].DetachChildren();
				eight_point(0,right_center); 
		    }
			iTweenEvent.GetEvent(GameObject.Find("right_center"),"r").Play();
			isr=false;
		 }
		  
	}
	void eight_point(int p,Transform center) {
		int x,y,z;
		x=y=z=1;
		switch(p) {
			case 0:x=0;break;
			case 1:y=0;break;
			case 2:z=0;break;
		}
		judge(new Vector3(center.position.x+x,center.position.y+y,center.position.z+z),center);
		judge(new Vector3(center.position.x+x,center.position.y+y,center.position.z-z),center);
		judge(new Vector3(center.position.x+x,center.position.y-y,center.position.z+z),center);
		judge(new Vector3(center.position.x+x,center.position.y-y,center.position.z-z),center);
		judge(new Vector3(center.position.x-x,center.position.y+y,center.position.z-z),center);
		judge(new Vector3(center.position.x-x,center.position.y+y,center.position.z+z),center);
		judge(new Vector3(center.position.x-x,center.position.y-y,center.position.z+z),center);
		judge(new Vector3(center.position.x-x,center.position.y-y,center.position.z-z),center);
		judge(new Vector3(center.position.x,center.position.y,center.position.z+z),center);
		judge(new Vector3(center.position.x,center.position.y,center.position.z-z),center);
		judge(new Vector3(center.position.x,center.position.y+y,center.position.z),center);
		judge(new Vector3(center.position.x,center.position.y-y,center.position.z),center);
		judge(new Vector3(center.position.x-x,center.position.y,center.position.z),center);
		judge(new Vector3(center.position.x+x,center.position.y,center.position.z),center); 
	}
	
	void judge(Vector3 temp,Transform center) {
		if(temp==cube[i].position) {
			cube[i].parent=center;
					
		}
	}
	
	void OnFinish() {
		isenable=true;
		if(isPlay){
			if(count==length-1){
				count=0;
				isAuto=false;
				isPlay=false;
				}else{
				isAuto=true;
				count++;
			}
		}  
	}
	
}
