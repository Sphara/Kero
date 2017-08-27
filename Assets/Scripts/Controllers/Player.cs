using UnityEngine;
using System.Collections;

[RequireComponent (typeof(Controller))]
public class Player : MonoBehaviour {

    Renderer renderer;
	Controller controller;
	public Characteristics stats;

	float velocityXSmoothing;

	float gravity;
	float jumpVelocity;
	float timeJumpWasCalled = -2f;

	Vector3 velocity;
    float faceDirection = 1;

	public LayerMask InteractionLayer;
	public LayerMask EnemyLayer;
    public PlayerState playerState = PlayerState.IDLE;

	private Animator anim;

	void Start () 
	{
		stats = new Characteristics ();
        renderer = GetComponent<MeshRenderer>();
		controller = GetComponent<Controller> ();
		gravity = -(2 * stats.jumpHeight) / Mathf.Pow (stats.timeToJumpApex, 2);
		jumpVelocity = Mathf.Abs (gravity) * stats.timeToJumpApex;
		anim = transform.GetChild(0).gameObject.GetComponent<Animator>();
	}

	void Update ()
	{
		Vector3 newScale = transform.localScale;

		/* Prevent y velocity to buffer while we're grounded or hitting ceiling */

		if (controller.collisions.above || controller.collisions.below)
			velocity.y = 0;

		/* Jump, controls & gravity */

		Vector2 input = new Vector2 (Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        if (input.x == -1)
            faceDirection = 1;
        else if (input.x == 1)
            faceDirection = -1;

        if (Input.GetAxisRaw("Jump") > 0) {
			timeJumpWasCalled = Time.timeSinceLevelLoad;
		}

		/* Interactions ! */

		RaycastHit2D hit;
		if (Input.GetAxisRaw("Fire1") > 0) {

            if (hit = controller.ManualRayCast(InteractionLayer, -faceDirection, 0, 2.0f)) // Change length maybe ?
            {
                InteractionScript interaction = hit.transform.gameObject.GetComponent<InteractionScript>();

                interaction.Interact(gameObject);
            }
        }

		if (hit = controller.ManualRayCast(EnemyLayer, -faceDirection, 0, 2.0f)) // Change length maybe ?
		{
			InteractionScript interaction = hit.transform.gameObject.GetComponent<InteractionScript>();

			interaction.Interact(gameObject);
		}

		float TargetHorizontalVelocity = input.x * stats.moveSpeed;

		velocity.x = Mathf.SmoothDamp(velocity.x, TargetHorizontalVelocity, ref velocityXSmoothing, controller.collisions.below ? stats.groundedAcceleration : stats.airborneAcceleration);

        // Before gravity, otherwise we're always moving
		if (Mathf.Abs(velocity.x) < 0.1f && Mathf.Abs(velocity.y) < 0.1f)
			playerState = PlayerState.IDLE;
		else if (controller.collisions.below)
			playerState = PlayerState.MOVING;
		else if (velocity.y > 0.1f)
			playerState = PlayerState.JUMPING;
		else
			playerState = PlayerState.DOWN;
		anim.SetInteger("State", (int)playerState);
        velocity.y += gravity * Time.deltaTime;

	}

	void FixedUpdate () {

        if (controller.collisions.below && (Time.timeSinceLevelLoad - timeJumpWasCalled) < 0.1f) {
			velocity.y = jumpVelocity;
			timeJumpWasCalled = -2f;
		}

        controller.Move (velocity * Time.deltaTime);
    }

}
