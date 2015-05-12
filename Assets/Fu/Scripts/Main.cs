using UnityEngine;
using System.Collections;
using RubikSolverSample;
using System.Threading;
using System;
public class Main : MonoBehaviour {
	public Transform Camera3D;
	public  string[] SideColors;
	private string SolveWay= "";
	public SetImageBox setImageBoxColor;
	public MagicCubeRotate roteMagicCube;
	private string yanZheng="";
	public Thread thread;
	private bool isYanZhengPass;
	// Use this for initialization
	void Start () {
//		SideColors = new string[6] {  
//			  "yyyyyyyyy",  
//			  "rrrrrrrrrr",  
//			  "wwwwwwwww",  
//			  "ooooooooo",  
//			  "bbbbbbbbbb",  
//			  "gggggggggg"   
//		}; 
//		Debug.Log(SideColors[1]);
//		SideColors = new string[6] {  
//			"yybyybyyb",  
//			"rrrrrrrrr",  
//			"wwgwwgwwg",  
//			"ooooooooo",  
//			"bbwbbwbbw",  
//			"yggyggygg"   
//		}; 
//		SideColors = new string[6] {  
//			"yyyyyyyyy",  
//			"gggrrrrrr",  
//			"wwwwwwwww",  
//			"bbboooooo",  
//			"rrrbbbbbb",  
//			"ooogggggg"   
//		}; 
		SideColors = new string[6] {  
			"wrrwyywoy",  
			"ggworoyrb",  
			"rrbrwwygw",  
			"gbbgobgbb",  
			"oyrybwyyo",  
			"ggobgwroo"   
		};  		
//		SideColors = new string[6] {  
//			"yyyyyyyyy",  
//			"rorrrrrrrr",  
//			"wwwwwwwww",  
//			"orooooooo",  
//			"bgbbbbbbbb",  
//			"gbgggggggg"    
//		};  		
//		SideColors = new string[6] {  
//		"ooooyoooo",  
//		"bbbbrbbbb",  
//		"rrrrwrrrr",  
//		"ggggogggg",  
//		"wwwwbwwww",  
//		"yyyygyyyy"    
//		};  
		Camera3D = GameObject.Find("Camera3D").transform;
		setImageBoxColor = this.GetComponent<SetImageBox>();
		roteMagicCube = Camera3D.GetComponent<MagicCubeRotate>(); 
	}
	void OnGUI () { 
//		if (GUILayout.Button("开启蓝牙",GUILayout.Height(50),GUILayout.Width(100))){
//			AndroidJavaClass jc = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
//			AndroidJavaObject jo = jc.GetStatic<AndroidJavaObject>("currentActivity"); 
//			jo.Call("canDiscover"); 
//		}
		string coloStr = "";
		if (GUI.Button(new Rect(0,70,80,40),"获取颜色")) {
			if(SideColors.Length!=6) {
				coloStr= "颜色数组为空";
				return;
			} else {
				setImageBoxColor.SetCubeColors(SideColors);
			}
		}
		
		GUI.Label (new Rect (100,115,100,40),coloStr); 
		GUI.Label (new Rect (80,160,100,40),yanZheng);
		if (GUI.Button(new Rect(0,205,80,40),"验证颜色")) {
			if (ColorsCheck(SideColors)) {
				if (SideColors[0][4]=='y'&&SideColors[1][4]=='r'&&SideColors[2][4]=='w'&&SideColors[3][4]=='o'&&SideColors[4][4]=='b'&&SideColors[5][4]=='g') {
					RubikSolve.InputStr = SetCombine (ChangColorSidesToStandString(SideColors)); 
//					Debug.Log(RubikSolve.InputStr); 
					thread = new Thread(  new ThreadStart(RubikSolve.CheckColors));  
					thread.Start(); 
					if (thread.IsAlive) {
						yanZheng= "正在验证请稍后………";
					}
					StartCoroutine(CheckResult());
				}else {
					yanZheng ="验证失败，请检查颜色输入!!";
					return;
				}
			}else {
				yanZheng ="验证失败，请检查颜色输入!!!";
				return;
			}

		}
		if (isYanZhengPass) {  
			if (SolveWay=="") {
				SolveWay ="已经是还原状态无需还原!!";
			}
			GUI.Label(new Rect(0,250,100,20),"你的公式：");  
			SolveWay=GUI.TextField(new Rect(0,275,200,30),SolveWay);
			if(GUI.Button (new Rect (10, 310, 80, 40), "开始") && !roteMagicCube.isPlay&&SolveWay!="已经是还原状态无需还原!!"&&SolveWay!=""){
				roteMagicCube.formula = SolveWay;
				roteMagicCube.isAuto=true;
				roteMagicCube.isPlay=true;
				roteMagicCube.length=roteMagicCube.formula.Length;
			} 

		}
		if(GUI.Button (new Rect (10, 355, 80, 40), "重置") ){ 
			Application.LoadLevel("RubikCube");
		}
	}
	/// <summary>
	/// 颜色验证
	/// </summary>
	public bool ColorsCheck (string [] colorSides) { 
		int [] ColorCount = new int[6];
		bool isMagicBox= false;;
		for (int i= 0;i<colorSides.Length;i++) {
			colorSides[i].ToCharArray();	// 转化为字符数组
			for (int j = 0;j<colorSides[i].Length;j++) { 
				switch (colorSides[i][j]) {
				case 'y':  ColorCount[0]++; break; 
				case 'r':  ColorCount[1]++; break;
				case 'w': ColorCount[2]++; break;
				case 'o':  ColorCount[3]++;break;
				case 'b':  ColorCount[4]++;break;
				case 'g':  ColorCount[5]++;break;  
				}
			} 
		} 
		for (int k = 0; k<ColorCount.Length; k++) {
			if (ColorCount[k]==9) {
				isMagicBox = true;
				continue;
			}else {
				isMagicBox = false;
				break;
			}
		}
		return isMagicBox;
	}

	IEnumerator CheckResult () {
		yield return new WaitForSeconds (2);
		if (thread.IsAlive) {
			thread.Abort();
			yanZheng="验证失败，请检查颜色输入";
			isYanZhengPass = false;
		}else {
			yanZheng ="验证通过"; 
			isYanZhengPass =true;
			string input= SetCombine (ChangColorSidesToStandString(SideColors)); 
			SolveWay= ChangResult(RubikSolve.GetResult(input)); 
			Debug.Log(SolveWay);
		}
	}
	// 把颜色数组转化成标准输入字符串
	public string [] ChangColorSidesToStandString(string [] colorSides ) {
		string tem=null;
		string [] StandSides =new string[6];
		for (int i= 0;i<colorSides.Length;i++) {
			colorSides[i].ToCharArray();	// 转化为字符数组
			for (int j = 0;j<colorSides[i].Length;j++) { 
				switch (colorSides[i][j]) {
				case 'y':tem+="U";  break; 
				case 'r':tem+="R";  break;
				case 'w':tem+="D"; break;
				case 'o':tem+="L"; break;
				case 'b':tem+="F"; break;
				case 'g':tem+="B"; break;  
				}
			}
			StandSides[i] = tem; 
			tem = null;
//			Debug.Log(StandSides[i]);
		} 
		return StandSides;
	}
	/// <summary>
	/// 创建组合
	/// </summary>
	/// <returns>The combine.</returns>
	/// <param name="StandSides">Stand sides.</param>
	public string SetCombine ( string []StandSides ) {
		for (int i = 0;i< StandSides.Length;i++) {
			StandSides[i].ToCharArray();
		}
		string standString =null; 
		// UF
		standString+=StandSides[0][7].ToString();
		standString+=StandSides[4][1].ToString();
		standString+=" ";
		// UR
		standString+=StandSides[0][5].ToString();
		standString+=StandSides[1][1].ToString();
		standString+=" "; 
		// UB
		standString+=StandSides[0][1].ToString();
		standString+=StandSides[5][1].ToString();
		standString+=" ";
		// UL
		standString+=StandSides[0][3].ToString();
		standString+=StandSides[3][1].ToString(); 
		standString+=" ";
		// DF
		standString+=StandSides[2][1].ToString();
		standString+=StandSides[4][7].ToString(); 
		standString+=" ";
		// DR
		standString+=StandSides[2][5].ToString();
		standString+=StandSides[1][7].ToString(); 
		standString+=" ";
		// DB
		standString+=StandSides[2][7].ToString();
		standString+=StandSides[5][7].ToString(); 
		standString+=" ";
		// DL
		standString+=StandSides[2][3].ToString();
		standString+=StandSides[3][7].ToString(); 
		standString+=" ";  
		// FR
		standString+=StandSides[4][5].ToString();
		standString+=StandSides[1][3].ToString(); 
		standString+=" ";
		// FL
		standString+=StandSides[4][3].ToString();
		standString+=StandSides[3][5].ToString(); 
		standString+=" ";
		// BR
		standString+=StandSides[5][3].ToString();
		standString+=StandSides[1][5].ToString(); 
		standString+=" ";
		// BL
		standString+=StandSides[5][5].ToString();
		standString+=StandSides[3][3].ToString(); 
		standString+=" "; 
		
		// UFR
		standString+=StandSides[0][8].ToString();
		standString+=StandSides[4][2].ToString(); 
		standString+=StandSides[1][0].ToString(); 
		standString+=" ";
		// URB
		standString+=StandSides[0][2].ToString();
		standString+=StandSides[1][2].ToString(); 
		standString+=StandSides[5][0].ToString(); 
		standString+=" ";
		// UBL
		standString+=StandSides[0][0].ToString();
		standString+=StandSides[5][2].ToString(); 
		standString+=StandSides[3][0].ToString(); 
		standString+=" ";
		// ULF
		standString+=StandSides[0][6].ToString();
		standString+=StandSides[3][2].ToString(); 
		standString+=StandSides[4][0].ToString(); 
		standString+=" ";

		// DRF
		standString+=StandSides[2][2].ToString();
		standString+=StandSides[1][6].ToString(); 
		standString+=StandSides[4][8].ToString(); 
		standString+=" ";
		// DFL
		standString+=StandSides[2][0].ToString();
		standString+=StandSides[4][6].ToString(); 
		standString+=StandSides[3][8].ToString(); 
		standString+=" ";
		// DLB
		standString+=StandSides[2][6].ToString();
		standString+=StandSides[3][6].ToString(); 
		standString+=StandSides[5][8].ToString(); 
		standString+=" ";
		// DBR
		standString+=StandSides[2][8].ToString();
		standString+=StandSides[5][6].ToString(); 
		standString+=StandSides[1][8].ToString();  

		return standString;
	}
	private char theOtherSide (char thisSide) {
		switch (thisSide) {
		case 'U': return 'D' ;
		case 'D': return 'U' ;
		case 'F': return 'B' ;
		case 'B': return  'F';
		case 'R': return 'L' ;
		case 'L': return  'R';
		default : return ' ';
		}
	}
	
	/// <summary>
	///         结果转换为 可执行字符串
	/// </summary>
	/// <param name="initResult">Init result.</param>
	public string ChangResult (string initResult) {
		string finalResult="";        
		string []temp =initResult.Split(' '); 
		for (int i=0;i<temp.Length;i++) {
			temp[i].ToCharArray();
			if (temp[i].Length==2) {
				if (temp[i][1]=='1') {
					finalResult+=temp[i][0].ToString();
				}else if (temp[i][1]=='2'){
					finalResult+=temp[i][0].ToString();
					finalResult+=temp[i][0].ToString();
				}else if(temp[i][1]=='3') {
					finalResult+=temp[i][0].ToString().ToLower();
				}
				Debug.Log(finalResult); 
			}else {
				Debug.Log("Finish!");
			}
		}
		string newFinalResult = finalResult;
		finalResult.ToCharArray();
		if (finalResult.Length>=3)  { 
			newFinalResult = null;
			for (int j = 0; j<finalResult.Length;) { 
				if(j+3<finalResult.Length&&(finalResult[j]==finalResult[j+1])&&(finalResult[j+1]==finalResult[j+2])) {
					newFinalResult+=finalResult[j].ToString().ToLower();
					j+=3;
				}else {
					newFinalResult+=finalResult[j].ToString();
					j++;
				} 
			}
		} 
		Debug.Log(newFinalResult);
		Debug.Log(newFinalResult.Length);
		return newFinalResult;
	}
}
