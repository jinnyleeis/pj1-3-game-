using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 진흙괴물_단순이동 : MonoBehaviour
{
    float rightMax = 2.0f;
    float leftMax = -2.0f;
    float currentPosition;
    float direction = 3.0f;
    SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        currentPosition = transform.position.x;
        spriteRenderer = GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
        currentPosition += Time.deltaTime * direction;
        if (currentPosition >= rightMax)
        {
            direction *= -1;
            currentPosition = rightMax;
            spriteRenderer.flipX = true;
        }

        else if (currentPosition <= leftMax)
        {
            direction *= -1;
            currentPosition = leftMax;
            spriteRenderer.flipX = false;
        }

        transform.position = new Vector3(currentPosition, 0, 0);
    }
}
