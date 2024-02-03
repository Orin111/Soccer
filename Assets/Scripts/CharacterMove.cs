using UnityEngine;
using System.Collections;
public class CharacterMove : MonoBehaviour 
{
    CharacterController controller ; // a connection to the character controller component
    public float speed = 10; // the speed of movement units per second public string
    public string horizontal = "Horizontal"; // the name of the horizontal axis control public string
    public string vertical = "Vertical"; // the name of the vertical axis control
    void Awake()
    {
        controller = GetComponent<CharacterController>();
    }
    void Update () 
    {
        float x = Input.GetAxis (horizontal);
        float z = Input.GetAxis (vertical);
        Vector3 moveDir = (new Vector3(x,0,z)).normalized;
        controller.SimpleMove(moveDir * speed);
    }
}