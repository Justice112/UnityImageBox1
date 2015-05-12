var target : Transform;
var distance = 10.0;
public var dragControl:boolean=false;
 
var sensitivityX: float = 10.0;
var sensitivityY: float = 10.0;
 
var viewerYmin = 0.8;
private var yMinLimit: float = 0;
var yMaxLimit = 80;
 
var distanceMin: float = 3;
var distanceMax: float = 15;
 
private var x: float = 0;
private var y: float = 0;
private var y0: float = 0;

//<--descend var
private var startTime: float = 0;
private var startAngle: float = 0;
private var descending: boolean = false;
//descend var-->
private var i1: int = 0;

//@script AddComponentMenu("Camera-Control/Mouse Orbit")
 
function Start () {
	Init ();
	descending = false;
// Make the rigid body not change rotation
    if (rigidbody)
        rigidbody.freezeRotation = true;
}
 
function LateUpdate () {
    if (target) {
			if(!dragControl||(dragControl&&Input.GetMouseButton(1))){
				x += Input.GetAxis("Mouse X") * sensitivityX * distance;
				y -= Input.GetAxis("Mouse Y") * sensitivityY;
			}
			yMinLimit = - yMaxLimit;
			//yMinLimit = - Mathf.Rad2Deg * Mathf.Asin((target.position.y - viewerYmin)/distance);
			y = ClampAngle(y, yMinLimit, yMaxLimit);
		   
		var localrotation = Quaternion.Euler(y, x, 0);
			
		distance = Mathf.Clamp(distance - Input.GetAxis("Mouse ScrollWheel")*5, distanceMin, distanceMax);

        var hit : RaycastHit;
        if (Physics.Linecast (target.position, transform.position, hit)) {
               //distance =  hit.distance;
        }
       
        var position = localrotation * Vector3(0.0, 0.0, -distance) + target.position;
		
        transform.rotation = localrotation;
        transform.position = position;
   
    }
}

 
static function ClampAngle (angle : float, min : float, max : float) {
    if (angle < -360)
        angle += 360;
    if (angle > 360)
        angle -= 360;
    return Mathf.Clamp (angle, min, max);
}


function Init () { 
	var angles = transform.eulerAngles;
	x = angles.y;
	y = 30; 
}