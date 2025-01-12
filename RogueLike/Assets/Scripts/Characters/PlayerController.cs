using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerController : AEntity, ICollectable, InputControllers.IPlayerActions
{
    Rigidbody2D rigidbody;
    Animator animator;
    private Vector2 direction;
    public float idleTime = 3f;
    private float timer = 0;
    public Text coinCollectorText;
    public static int coinCollector = 0;
    private Weapon equipedWeapon;
    private Inventory backpack;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        if(rigidbody.velocity.x > 0)
        { 
            animator.SetBool("isWalking", true);
        }
        else
        {
            animator.SetBool("isWalking", false);
        }
        IsAsleep();
        rigidbody.velocity = direction * speed;
        //coinCollectorText.text = coinCollector.ToString();
    }

    void IsAsleep()
    {
        if(animator.GetCurrentAnimatorStateInfo(0).IsName("IdleBlendTree"))
        {
            timer += Time.deltaTime;
            if(timer >= idleTime)
            {
                animator.SetTrigger("Asleep");
                timer = 0;
            }
        }
        else
        {
            timer = 0;
        }
    }

    public void Collect() { }
    public void Buy() { }

    public void OnMovement(InputAction.CallbackContext context)
    {
        direction = context.ReadValue<Vector2>();
    }
}
