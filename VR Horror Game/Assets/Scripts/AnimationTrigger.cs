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
        animationSound.Play();

        triggerController.NewActiveTrigger();
        triggerController.activeTriggers.Remove(this.gameObject);
        triggerController.inactiveTriggers.Add(this.gameObject);
        this.gameObject.SetActive(false);
    }

}
