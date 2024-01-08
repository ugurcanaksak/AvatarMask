using UnityEngine;


public class MaskCharacterController : MonoBehaviour
{
    private CharacterController characterController;
    private CharacterController CharacterController{get {return characterController == null ? characterController = GetComponent<CharacterController>() : characterController; }}

    private Animator animator;
    private Animator Animator{get {return animator == null ? animator = GetComponent<Animator>() : animator; }}

    public float Speed;

    private void Update()
    {
        Move(RecieveInput());
        UpdateAnimations();

        if (Input.GetKeyDown(KeyCode.E))
        {
            ToggleWaving();
        }
    }
    private Vector3 RecieveInput()
    {
        return new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
    }
    private void Move(Vector3 direction)
    {
        CharacterController.Move(direction * Speed * Time.deltaTime);
    }
    private void UpdateAnimations()
    {
        Animator.SetFloat("Speed", CharacterController.velocity.magnitude);
    }
    private void ToggleWaving()
    {
        Animator.SetTrigger("Dance");

    }
}
