using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySprite : MonoBehaviour
{
    public Fighter parentFighter;

    public SpriteRenderer spriteRenderer;

    // sprites for charging, idle, death, etc
    public UnityEngine.Sprite chargingSprite;
    public UnityEngine.Sprite idleSprite;
    public UnityEngine.Sprite deadSprite;
    public UnityEngine.Sprite attackSprite;

    // counters
    public int animateCounter;
    public int animateStep;

    // sprite width and height
    public float spriteHeight;
    public float spriteWidth;

    // position x, y, and x of this sprite
    public float spriteX;
    public float spriteY;
    public float spriteZ;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

        if (parentFighter.isIdle)
        {
            AnimateIdle();
        }

        if (parentFighter.isCharging)
        {
            AnimateCharging();
        }

        if (parentFighter.isAttacking)
        {
            AnimateAttack();
        }

        if (parentFighter.isDead)
        {
            AnimateDead();
        }

        UpdateSpriteWidthHeight();
        UpdateSpriteXYZ();
    }

    public void AnimateCharging()
    {
        this.spriteRenderer.sprite = chargingSprite;
    }

    public void AnimateDead()
    {
        this.spriteRenderer.sprite = deadSprite;
    }

    public void AnimateAttack()
    {
        this.spriteRenderer.sprite = attackSprite;
    }

    public void AnimateIdle()
    {
        this.spriteRenderer.sprite = idleSprite;
    }

    public void IterateAnimateCounter()
    {
        if (animateCounter <= 0)
        {

        }
        else if (animateCounter > 0)
        {
            animateCounter -= 1;
        }
    }

    public void UpdateSpriteWidthHeight()
    {
        spriteHeight = spriteRenderer.sprite.bounds.size.y * this.transform.localScale.y;
        spriteWidth = spriteRenderer.sprite.bounds.size.x * this.transform.localScale.x;
    }

    public void UpdateSpriteXYZ()
    {
        this.spriteX = this.transform.position.x;
        this.spriteY = this.transform.position.y;
        this.spriteZ = this.transform.position.z;
    }
}
