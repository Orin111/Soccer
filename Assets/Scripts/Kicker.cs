using UnityEngine;
using System.Collections;
using System; // needs to be added to use Actions
public class Kicker : MonoBehaviour 
{
    public float pushPower = 13.0f; // the power while pushing the ball
    public string kick = "Fire1"; // the button in the Input settings to represent the Kick
    public float kickForce = 30.0f; // the power of the kick
    public float kickTime;
    public Action onKick;
    void Update()
    {
        if(kickTime>0){
            kickTime-=Time.deltaTime; return;
        }
        if(Input.GetButtonDown(kick)) 
        {
            if(onKick!=null) onKick();
            kickTime = 0.4f;
        }
    }
    // This function is called each time a Character Controller touches another Collider
    void OnControllerColliderHit (ControllerColliderHit hit ) 
    {
        Rigidbody body = hit.collider.attachedRigidbody;
        // if a body is marked isKinemtaic, it will not react to physics
        if (body == null || body.isKinematic) return;
        // get the direction of the push
        Vector3 pushDir = new Vector3 (hit.moveDirection.x, 0, hit.moveDirection.z).normalized;
        // set the default force to be the push force
        float pushForce = pushPower;
        // if Kick is pressed change the force to kick Force
        if (kickTime>0) 
        {
            pushForce = kickForce;
        }
        // Apply the force
        body.velocity = pushDir* pushForce;
    }
    
}