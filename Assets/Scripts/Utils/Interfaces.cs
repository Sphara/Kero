using UnityEngine;
using System.Collections;

interface IPlatformGuideFunction {
	Vector3 GetMovement();
};

interface IInteractable
{
    void Interact(GameObject InteractionAuthor);
}