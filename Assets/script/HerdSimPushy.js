#pragma strict

var _scanner:Transform;
var _pushDistance:float;
var _pushForce:float;
var _returnToOriginalPosition:boolean = true;
var _returnForce:float = 3;
private var _oPos:Vector3;

function Start () {
	
	
	_oPos = transform.position;
	_pushDistance*=transform.localScale.x;
}

function FixedUpdate () {
	Pushy();
	
	
}

//function OnDrawGizmos(){
//		var hit : RaycastHit;
//		if (Physics.Raycast(transform.position, -Vector3.up, hit, 10000000000)){
//
//			Debug.Log("d");
//			transform.position.y = hit.point.y;
//			
//		
//		}
//}

//Uses scanner to push away from obstacles
function Pushy() {
	var hit : RaycastHit;
	_scanner.Rotate(Vector3(0,500*Time.deltaTime,0));
	if (Physics.Raycast(_scanner.transform.position, _scanner.forward, hit, _pushDistance)){	
		var d:float;		
		d = (_pushDistance - hit.distance)/_pushDistance;	
		transform.position -= _scanner.forward*Time.deltaTime*d*_pushForce;		
	}else if(_returnToOriginalPosition && (transform.position - _oPos).magnitude > .05){
		transform.position -= (transform.position-_oPos)*Time.deltaTime*_returnForce;	
	}
}