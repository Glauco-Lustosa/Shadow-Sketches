
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerInputHandler : MonoBehaviour
{
   public Vector2 _movement { get; private set; }
//    public Rigidbody2D _rb2D { get; private set; }


    private void Awake()
    {
       // _rb2D = GetComponent<Rigidbody2D>();
    }

   public void OnMove(InputValue input)
    {
        Debug.Log(input);
        _movement = input.Get<Vector2>();
        //_movement.y = 0f;

    }

   /* private void FixedUpdate()
    {
        _rb2D.MovePosition(_rb2D.position + _movement * Time.fixedDeltaTime);
    }
    */

}
