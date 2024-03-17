using System;
using Unity.Mathematics;
using UnityEngine;

public class ChangeDirection : MonoBehaviour
{

    /// <summary>
    /// change cube rotarion and grabity
    /// </summary>
    //private void ChangeDirection(Rigidbody2D objRb2d, StateDB.State objState, Animation animation, bool bottomLeftContacting, bool bottomRightContacting, bool upperRightContacting,bool upperLeftContacting)
    //{
    //    objRb2d.velocity = Vector2.zero;

    //    if (bottomLeftContacting && !bottomRightContacting)
    //    {
    //        switch (objState)
    //        {
    //            case StateDB.State.vectorUp:
    //                Physics2D.gravity = Vector2.left * Physics2D.gravity.magnitude;
    //                animation.Play("1_UpToRightRotation");
    //                objState = StateDB.State.vectorRight;
    //                break;
    //            case StateDB.State.vectorRight:
    //                Physics2D.gravity = Vector2.up * Physics2D.gravity.magnitude;
    //                animation.Play("2_RightToDownRotation");
    //                objState = StateDB.State.vectorDown;
    //                break;
    //            case StateDB.State.vectorDown:
    //                Physics2D.gravity = Vector2.right * Physics2D.gravity.magnitude;
    //                animation.Play("3_DownToLeftRotation");
    //                objState = StateDB.State.vectorLeft;
    //                break;
    //            case StateDB.State.vectorLeft:
    //                Physics2D.gravity = Vector2.down * Physics2D.gravity.magnitude;
    //                animation.Play("4_LeftToUpRotation");
    //                objState = StateDB.State.vectorUp;
    //                break;

    //        }
    //    }
    //    else if (!bottomLeftContacting && bottomRightContacting)
    //    {
    //        switch (objState)
    //        {
    //            case StateDB.State.vectorUp:
    //                objState = StateDB.State.vectorLeft;
    //                Physics2D.gravity = Vector2.right * Physics2D.gravity.magnitude;
    //                animation.Play("5_UpToLeftRotation");
    //                break;
    //            case StateDB.State.vectorLeft:
    //                objState = StateDB.State.vectorDown;
    //                Physics2D.gravity = Vector2.up * Physics2D.gravity.magnitude;
    //                animation.Play("6_LeftToDownRotation");
    //                break;
    //            case StateDB.State.vectorDown:
    //                objState = StateDB.State.vectorRight;
    //                Physics2D.gravity = Vector2.left * Physics2D.gravity.magnitude;
    //                animation.Play("7_DownToRightRotation");
    //                break;
    //            case StateDB.State.vectorRight:
    //                objState = StateDB.State.vectorUp;
    //                Physics2D.gravity = Vector2.down * Physics2D.gravity.magnitude;
    //                animation.Play("8_RightToUpRotation");
    //                break;
    //        }
    //    }
    //    if (upperRightContacting)
    //    {
    //        switch (objState)
    //        {
    //            case StateDB.State.vectorUp:
    //                objRb2d.AddForce(Vector2.up * 4, ForceMode2D.Impulse);
    //                Physics2D.gravity = Vector2.right * Physics2D.gravity.magnitude;
    //                rotateAnimation.Play("5_UpToLeftRotation");
    //                objState = StateDB.State.vectorLeft;
    //                break;
    //            case StateDB.State.vectorLeft:
    //                objRb2d.AddForce(Vector2.left * 4, ForceMode2D.Impulse);
    //                Physics2D.gravity = Vector2.up * Physics2D.gravity.magnitude;
    //                rotateAnimation.Play("6_LeftToDownRotation");
    //                objState = StateDB.State.vectorDown;
    //                break;
    //            case StateDB.State.vectorDown:
    //                objRb2d.AddForce(Vector2.down * 4, ForceMode2D.Impulse);
    //                Physics2D.gravity = Vector2.left * Physics2D.gravity.magnitude;
    //                rotateAnimation.Play("7_DownToRightRotation");
    //                objState = StateDB.State.vectorRight;
    //                break;
    //            case StateMachine.State.vectorRight:
    //                objRb2d.AddForce(Vector2.right * 4, ForceMode2D.Impulse);
    //                Physics2D.gravity = Vector2.down * Physics2D.gravity.magnitude;
    //                rotateAnimation.Play("8_RightToUpRotation");
    //                objState = StateDB.State.vectorUp;
    //                break;


    //        }
    //    }
    //    else if (upperLeftContacting)
    //    {
    //        switch (objState)
    //        {
    //            case StateDB.State.vectorUp:
    //                objRb2d.AddForce(Vector2.up * 4, ForceMode2D.Impulse);
    //                Physics2D.gravity = Vector2.left * Physics2D.gravity.magnitude;
    //                rotateAnimation.Play("1_UpToRightRotation");
    //                objState = StateDB.State.vectorRight;
    //                break;
    //            case StateDB.State.vectorRight:
    //                objRb2d.AddForce(Vector2.right * 4, ForceMode2D.Impulse);
    //                Physics2D.gravity = Vector2.up * Physics2D.gravity.magnitude;
    //                rotateAnimation.Play("2_RightToDownRotation");
    //                objState = StateDB.State.vectorDown;
    //                break;
    //            case StateDB.State.vectorDown:
    //                objRb2d.AddForce(Vector2.down * 4, ForceMode2D.Impulse);
    //                Physics2D.gravity = Vector2.right * Physics2D.gravity.magnitude;
    //                rotateAnimation.Play("3_DownToLeftRotation");
    //                objState = StateDB.State.vectorLeft;
    //                break;
    //            case StateDB.State.vectorLeft:
    //                objRb2d.AddForce(Vector2.left * 4, ForceMode2D.Impulse);
    //                Physics2D.gravity = Vector2.down * Physics2D.gravity.magnitude;
    //                rotateAnimation.Play("4_LeftToUpRotation");
    //                objState = StateDB.State.vectorUp;
    //                break;
    //        }
    //    }


    //}
}
