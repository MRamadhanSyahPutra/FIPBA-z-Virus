using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class Player : MonoBehaviour
{
    public int HP = 100;
    public GameObject bloodyScreen;
    private Animator animator;
    public TextMeshProUGUI playerhealthUI;
    public GameObject gameOverUI;

    public bool isDead;


    private void Start()
    {
        Transform mcArmatureTransform = transform.Find("Mc+Armature");
        playerhealthUI.text = $"Health:{HP}";

        if (mcArmatureTransform != null)
        {
            animator = mcArmatureTransform.GetComponent<Animator>();
        }
        else
        {
            Debug.LogError("Mc+Armature not found as a child of mainPlayer.");
        }
    }

    public void TakeDamage(int demageAmount)
    {
        HP -= demageAmount;
        if (HP <= 0)
        {
            print("Player is dead!");
            PlayerDead();
            isDead = true;
        }
        else
        {
            print("Player is hit!");
            StartCoroutine(BloodyScreenEffect());
            playerhealthUI.text = $"Health:{HP}";
            SoundManager.Instance.playerChannel.PlayOneShot(SoundManager.Instance.playerHurt);
        }
    }

    private void PlayerDead()
    {
        if (HP == 0)
        {
            SoundManager.Instance.playerChannel.PlayOneShot(SoundManager.Instance.playerDie);

            SoundManager.Instance.playerChannel.clip = SoundManager.Instance.gameOverMusic;
            SoundManager.Instance.playerChannel.PlayDelayed(2f);

            GetComponent<MouseMovement>().enabled = false;
            GetComponent<PlayerMovement>().enabled = false;

            // Animator Death Left
            animator.SetTrigger("deathLeft");

            Transform headTransform = transform.Find("Mc+Armature/Armature/mixamorig:Hips/mixamorig:Spine/mixamorig:Spine1/mixamorig:Spine2/mixamorig:Neck/mixamorig:Head");

            if (headTransform != null)
            {
                Camera.main.transform.SetParent(headTransform);
            }
            else
            {
                Debug.LogError("mixamorig:Head not found in hierarchy.");
            }
            playerhealthUI.gameObject.SetActive(false);
            GetComponent<ScreenFader>().StartFade();
            StartCoroutine(ShowGameOverUI());
        }
    }

    private IEnumerator ShowGameOverUI()
    {
        yield return new WaitForSeconds(1f);
        gameOverUI.gameObject.SetActive(true);
    }

    private IEnumerator BloodyScreenEffect()
    {
        if (bloodyScreen.activeInHierarchy == false)
        {
            bloodyScreen.SetActive(true);
        }

        var image = bloodyScreen.GetComponentInChildren<UnityEngine.UI.Image>();

        // Set the initial alpha value to 1 (fully visible).
        Color startColor = image.color;
        startColor.a = 1f;
        image.color = startColor;

        float duration = 2f;
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            // Calculate the new alpha value using Lerp.
            float alpha = Mathf.Lerp(1f, 0f, elapsedTime / duration);

            // Update the color with the new alpha value.
            Color newColor = image.color;
            newColor.a = alpha;
            image.color = newColor;

            // Increment the elapsed time.
            elapsedTime += Time.deltaTime;

            yield return null; ; // Wait for the next frame.
        }

        if (bloodyScreen.activeInHierarchy)
        {
            bloodyScreen.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ZombieHand"))
        {
            if (isDead == false)
            {
                TakeDamage(other.gameObject.GetComponent<ZombieHand>().damage);
            }
        }
    }
}
