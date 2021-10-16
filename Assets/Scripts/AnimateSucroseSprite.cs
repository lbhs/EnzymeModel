using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimateSucroseSprite : MonoBehaviour
{
    private Animator sucroseRotationAnimator;

    #region Private Methods
    // Start is called before the first frame update
    void Start()
    {
        sucroseRotationAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collider2D)
    {
        sucroseRotationAnimator.SetTrigger("Move_Sucrose");
    }
    #endregion
}
