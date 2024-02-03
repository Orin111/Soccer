using UnityEngine;

public class ActorAnimator : MonoBehaviour
{
    public CharacterController controller;
    public Animator anim;
    Kicker kicker;

    void Awake()
    {
        controller = GetComponent<CharacterController>();
        kicker = GetComponent<Kicker>();
    }

    void OnEnable()
    {
        kicker.onKick += OnKick;
    }

    void OnDisable()
    {
        kicker.onKick -= OnKick;
    }

    void Update()
    {
        Vector3 speed = new Vector3(controller.velocity.x, 0.0f, controller.velocity.z);
        transform.LookAt(transform.position + speed.normalized);
        anim.SetFloat("Speed", speed.magnitude);
    }

    void OnKick()
    {
        anim.SetTrigger("Kick");
    }

    public void StartDanceAnimation()
    {
        anim.SetTrigger("Dance");
    }
}