using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //旋轉速度
    public float rotationSpeed = 20f;
    //遊戲組件
    Animator playerAnimator;
    Rigidbody playerRigidbody;
    //旋轉方向
    Vector3 playerVector;
    Quaternion playerQuaternion = Quaternion.identity;
    // Start is called before the first frame update
    void Start()
    {
        playerAnimator = GetComponent<Animator>();
        playerRigidbody = GetComponent<Rigidbody>();
    }

    void FixedUpdate() 
    {
        MoveRotation();
    }
    void MoveRotation()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        playerVector.Set(horizontal,0f,vertical);
        playerVector.Normalize();

        bool playerMoveHorizontal = !Mathf.Approximately(horizontal,0);
        bool playerMoveaVertical = !Mathf.Approximately(vertical,0);
        bool CanMove = playerMoveHorizontal||playerMoveaVertical;

        playerAnimator.SetBool("CanMove",CanMove);

        Vector3 desirForword = Vector3.RotateTowards(transform.forward,playerVector,rotationSpeed*Time.deltaTime,0f);
        playerQuaternion = Quaternion.LookRotation(desirForword);
    }
    //玩家的旋轉和移動
    void OnAnimatorMove() 
    {
        playerRigidbody.MovePosition(playerRigidbody.position+playerVector*playerAnimator.deltaPosition.magnitude);
        playerRigidbody.MoveRotation(playerQuaternion);
    }
}
