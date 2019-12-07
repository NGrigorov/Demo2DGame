using UnityEngine;

public class Move : MonoBehaviour
{
    private float speed = 20f, horMove = 0f;
    bool jump = false, crouch = false;
    public CharacterController2D myChar;
    public Animator myAnimator;
    public Joystick joystick;
    // Update is called once per frame
    void Update()
    {
        if (joystick.Horizontal >= .2f)
        {
            horMove = speed;
        }else if (joystick.Horizontal <= -.2f)
        {
            horMove = -speed;
        }
        else
        {
            horMove = 0f;
        }
        myAnimator.SetFloat("Speed", Mathf.Abs(horMove));

        float verticalMove = joystick.Vertical;

        if(verticalMove >= .5f)
        {
            jump = true;
            myAnimator.SetBool("isFlying", true);
        }

        if(verticalMove <= -.5f)
        {
            crouch = true;
        }
        else
        {
            crouch = false;
        }
    }

    public void OnLanding()
    {
        myAnimator.SetBool("isFlying", false);
    }

    public void OnCrouching(bool isCrouching)
    {
        myAnimator.SetBool("isCrouching", isCrouching);
    }

    private void FixedUpdate()
    {
        myChar.Move(horMove * Time.fixedDeltaTime,crouch, jump);
        jump = false;
        
    }
}
