#pragma strict

var n: int;
var cubesize: float = 0.96;
var superCube: Transform;
var cubeScript: nCube ; //main script
var mat: Material;
var matOver: Material;

function Start () {
	superCube = transform.parent.parent.parent.transform;
	cubeScript = superCube.GetComponent(nCube);
}

function OnMouseOver () {
	if(cubeScript.isTweening) {return;}
	renderer.material = matOver;
}

function OnMouseExit () {
	renderer.material = mat;
}

function OnMouseDown () {
	if(cubeScript.tweening)	{
		if(cubeScript.isTweening) {return;}else {cubeScript.isTweening = true;}
	}
	var axis: Vector3;
	var version: String;
	
	var ix=Mathf.Round(transform.parent.transform.position.x+0.5*(n-1));
	var iy=Mathf.Round(transform.parent.transform.position.y+0.5*(n-1));
	var iz=Mathf.Round(transform.parent.transform.position.z+0.5*(n-1));

	var ixx = Mathf.Round(2*transform.position.x);
	var iyy = Mathf.Round(2*transform.position.y);
	var izz = Mathf.Round(2*transform.position.z);

	var ixxx; var iyyy; var izzz;
	
	for (var child:Transform in transform.parent.transform) {
		if(child.transform != transform){
			ixxx = Mathf.Round(2*child.transform.position.x);
			iyyy = Mathf.Round(2*child.transform.position.y);
			izzz = Mathf.Round(2*child.transform.position.z);
			Debug.Log("hit"+ixxx+" "+iyyy+" "+izzz);
		}
	}
	
	if(izz==-n){
		if(ixxx==-n){version = "y";axis=-Vector3.up;}
		if(ixxx==n){version = "y";axis=Vector3.up;}
		if(iyyy==-n){version = "x";axis=Vector3.right;}
		if(iyyy==n){version = "x";axis=-Vector3.right;}
	}
 	if(iyy==-n){
		if(izzz==-n){version = "x";axis=-Vector3.right;}
		if(izzz==n){version = "x";axis=Vector3.right;}
		if(ixxx==-n){version = "z";axis=Vector3.forward;}
		if(ixxx==n){version = "z";axis=-Vector3.forward;}
	}
	if(ixx==-n){
		if(izzz==-n){version = "y";axis=Vector3.up;}
		if(izzz==n){version = "y";axis=-Vector3.up;}
		if(iyyy==-n){version = "z";axis=-Vector3.forward;}
		if(iyyy==n){version = "z";axis=Vector3.forward;}
	}
	if(izz==n){
		if(ixxx==-n){version = "y";axis=Vector3.up;}
		if(ixxx==n){version = "y";axis=-Vector3.up;}
		if(iyyy==-n){version = "x";axis=-Vector3.right;}
		if(iyyy==n){version = "x";axis=Vector3.right;}
	}
    if(iyy==n){
		if(izzz==-n){version = "x";axis=Vector3.right;}
		if(izzz==n){version = "x";axis=-Vector3.right;}
		if(ixxx==-n){version = "z";axis=-Vector3.forward;}
		if(ixxx==n){version = "z";axis=Vector3.forward;}
	}
	if(ixx==n){
		if(izzz==-n){version = "y";axis=-Vector3.up;}
		if(izzz==n){version = "y";axis=Vector3.up;}
		if(iyyy==-n){version = "z";axis=Vector3.forward;}
		if(iyyy==n){version = "z";axis=-Vector3.forward;}
	}
	
	cubeScript.selectRotate(version, axis, ix,iy,iz,false);
}
