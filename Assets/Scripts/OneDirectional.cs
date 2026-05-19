using UnityEngine;
 

public class NewMonoBehaviourScript : MonoBehaviour
{


     public enum Axis {X, Y, Z, None}

     public Axis movementAxis = Axis.X;
     public float speed = 5f;

     private Vector3 direction;

  

    void Update()
    {
        direction = GetAxisVector(movementAxis);
        transform.position += direction * speed * Time.deltaTime;
    }

    Vector3 GetAxisVector(Axis axis)
    {
        switch (axis)
        {
            case Axis.X:
                return Vector3.right;
            case Axis.Y:
                return Vector3.up;
            case Axis.Z:
                return Vector3.forward;
            case Axis.None:
                return Vector3.zero;
            default:
                return Vector3.right;
        }
    }   


}
