﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * This component destroys its object whenever it triggers a 2D collider with the given tag.
 */
public class DestroyOnTrigger2D : MonoBehaviour
{
    [Tooltip("Every object tagged with this tag will trigger the destruction of this object")]
    [SerializeField]
    string triggeringTag;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (enabled)
        {
            if (other.tag == triggeringTag && triggeringTag != "Person")
            {
                Debug.Log("Masked");
                GameObject maskGameObject = this.gameObject.transform.GetChild(0).gameObject;
                var maskComponent = maskGameObject.GetComponent<Renderer>();
                if(maskComponent.enabled){
                    MaskShooter.score--;
                    Debug.Log("Already Masked\nPoints:"+MaskShooter.score);
                }
                else{
                    MaskShooter.score++;
                    maskComponent.enabled = true;
                    Debug.Log("Masked\nPoints:"+MaskShooter.score);
                }

                Destroy(other.gameObject);
            }
        }
    }
}
