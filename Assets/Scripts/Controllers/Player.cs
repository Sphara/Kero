using UnityEngine;
using System.Collections;

[RequireComponent (typeof(Controller))]
public class Player : MonoBehaviour {

	Controller controller;
	public Characteristics stats;

	float velocityXSmoothing;

	float gravity;
	float jumpVelocity;
	float timeJumpWasCalled = -2f;

	Vector3 velocity;
    float faceDirection = 1;

    public LayerMask InteractionLayer;
    public PlayerState playerState = PlayerState.IDLE;

	void Start () 
	{
		stats = new Characteristics ();
		controller = GetComponent<Controller> ();
		gravity = -(2 * stats.jumpHeight) / Mathf.Pow (stats.timeToJumpApex, 2);
		jumpVelocity = Mathf.Abs (gravity) * stats.timeToJumpApex;
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

		if (Input.GetAxisRaw("Fire1") > 0) {
            RaycastHit2D hit;

            if (hit = controller.ManualRayCast(InteractionLayer, -faceDirection, 0, 2.0f)) // Change length maybe ?
            {
                InteractionScript interaction = hit.transform.gameObject.GetComponent<InteractionScript>();

                interaction.Interact(gameObject);
            }
        }

		float TargetHorizontalVelocity = input.x * stats.moveSpeed;

		velocity.x = Mathf.SmoothDamp(velocity.x, TargetHorizontalVelocity, ref velocityXSmoothing, controller.collisions.below ? stats.groundedAcceleration : stats.airborneAcceleration);

        // Before gravity, otherwise we're always moving
        if (Mathf.Abs(velocity.x) < 0.1f && Mathf.Abs(velocity.y) < 0.1f)
            playerState = PlayerState.IDLE;
        else if (controller.collisions.below)
            playerState = PlayerState.MOVING;
        else
            playerState = PlayerState.JUMPING;

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
