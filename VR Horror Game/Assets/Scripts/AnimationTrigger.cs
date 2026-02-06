using System.Collections;
using UnityEngine;

public class AnimationTrigger : MonoBehaviour
{

    [SerializeField]
    private Animator monsterAnimation;

    [SerializeField]
    private AudioSource animationSound;

    [SerializeField]
    private TriggerController triggerController;

    public int roomID;

    void OnTriggerEnter(Collider other)
    {
        //Using a coroutine, since it can be paused while it playes the sound effect
        StartCoroutine(TestingSound(animationSound.clip.length));

        /*
        animationSound.Play();
        monsterAnimation.SetBool("Animate", true);

        new WaitForSeconds(10f);

        triggerController.NewActiveTrigger();
        triggerController.activeTriggers.Remove(this.gameObject);
        triggerController.inactiveTriggers.Add(this.gameObject);
        this.gameObject.SetActive(false);
        */
    }

    private IEnumerator TestingSound(float soundEffectLength)
    {
        animationSound.Play();
        monsterAnimation.SetBool("Animate", true);

        yield return new WaitForSeconds(soundEffectLength);

        triggerController.NewActiveTrigger();
        triggerController.activeTriggers.Remove(this.gameObject);
        triggerController.inactiveTriggers.Add(this.gameObject);
        this.gameObject.SetActive(false);
    }

}
