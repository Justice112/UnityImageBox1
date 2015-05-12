var target : Transform;
var centre:Transform;
var xSpeed = 250.0;
var ySpeed = 120.0;
var yMinLimit = -20;
var yMaxLimit = 80;
var initDis = 20;
var minDis = 3.0;
var maxDis = 50.0;
var wheelSpeed = 5;
static var x = 0.0;
static var y = 0.0;
static var finalx=0.0;
static var finaly=0.0;
static var distance:float;
private var position;
private var rotation:Quaternion;
public var enable:boolean;
private var reset:boolean=false;

function Awake() {
	x = 0;
	y = 35;
}
function Start () {

	transform.rotation = Quaternion.Euler(y, x, 0);
	transform.position =Quaternion.Euler(y, x, 0) * Vector3(0.0, 0.0, -initDis) + target.position; 
  	if (rigidbody)   rigidbody.freezeRotation = true;
  }
  function Update () {  
   
    if(enable==true)    {
    	if(Input.GetMouseButton(2)){   
    		target.localPosition.x-=Input.GetAxis("Mouse X");
    		target.localPosition.y+=Input.GetAxis("Mouse Y");
    	}
    	if(Input.GetKeyDown(KeyCode.F)){
    		reset=true;
    	}
    	if(reset==true){
    		target.position.x=Mathf.Lerp(target.position.x,centre.position.x,Time.deltaTime*5);
    		target.position.y=Mathf.Lerp(target.position.y,centre.position.y,Time.deltaTime*5);
    		if(Mathf.Abs(target.position.x-centre.position.x)<0.01f) {
				reset=false;    		
    		}
        }
    }
    
    
    if (target) {   
    distance = Vector3.Distance(target.position,transform.position);  
    if(Input.GetMouseButton(0)){   
    	 x += Input.GetAxis("Mouse X") * xSpeed * 0.02; 
         y -= Input.GetAxis("Mouse Y") * ySpeed * 0.02;  
         y = ClampAngle(y, yMinLimit, yMaxLimit);  
          }   
    finalx=Mathf.Lerp(finalx,x,Time.deltaTime*2);
    finaly=Mathf.Lerp(finaly,y,Time.deltaTime*2);
    
         distance-= Input.GetAxis("Mouse ScrollWheel")*wheelSpeed;  
         distance = Mathf.Clamp(distance,minDis,maxDis);
         rotation = Quaternion.Euler(finaly, finalx, 0); 
         position = rotation * Vector3(0.0, 0.0, -distance) + target.position;
         transform.rotation = rotation; 
         transform.position = position;}
         }
static function ClampAngle (angle : float, min : float, max : float) {
	if (angle < -360)   
   	 angle += 360;
    if (angle > 360)   
    	angle -= 360;return Mathf.Clamp (angle, min, max);}