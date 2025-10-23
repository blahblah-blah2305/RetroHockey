using UnityEngine;

public class SMScript : MonoBehaviour
{


// Singleton for global use. Should make this more convenient
public static SMScript I {get; private set; }

    [SerializeField] private AudioClip bigHit_clip; // Only going to use these sound effects if the main player runs into someone. Don't want it to make uneccessary sounds 
    [SerializeField] private AudioClip normalHit_clip;
    [SerializeField] private AudioClip goal_horn_clip;
    [SerializeField] private AudioClip puck_hit_clip;
    [SerializeField] private AudioClip board_hit_clip;
    [SerializeField] private AudioClip foul_sound_clip;


    [Header("Music")]
    [SerializeField] private AudioClip background_clip;
    [Range(0f, 1f)] [SerializeField] private float background_volume = 0.7f; // allows adjustment of volume in Unity

    private AudioSource musicSrc; // has everything I need for sound
    private AudioSource sfx2D;

    void Awake()
    {
        // Need this for the singleton so there is no duplicates

        if (I != null && I != this) { Destroy(gameObject); return; }
            I = this;
            DontDestroyOnLoad(gameObject);
        // create audio sources 
        musicSrc = gameObject.AddComponent<AudioSource>();
        musicSrc.loop = true;
        musicSrc.playOnAwake = false;
        musicSrc.spatialBlend = 0f; // Plays equal sound in both ears

        // Sound effects don't loop this is so it happens for instances
        sfx2D = gameObject.AddComponent<AudioSource>(); 
        sfx2D.playOnAwake = false;
        sfx2D.loop = false;
        sfx2D.spatialBlend = 0f;
    }

    void Start()
    {
        if (background_clip != null)
            BackgroundMusic();
    }


    public void BackgroundMusic()
    {
        musicSrc.volume = background_volume;
        musicSrc.clip = background_clip;

        musicSrc.time = 50f;
        musicSrc.Play();
    }

    public void StopBackground(){
        musicSrc.Stop();
    }

   // SFX
    public void GoalHorn(){
        Play2D(goal_horn_clip);
    }
    public void BigHit(){
        Play2D(bigHit_clip);
    }
    public void NormalHit(){
        Play2D(normalHit_clip);
    }
    public void PuckHit(){
        Play2D(puck_hit_clip);
    }
    public void BoardHit(){
        Play2D(board_hit_clip);
    }
        public void Foul(){
        Play2D(foul_sound_clip);
    }
 

    // Helper function to play sound effects over the background volume once
    private void Play2D(AudioClip clip, float volume = 0.7f)
    {
        if (clip == null) return;
        sfx2D.PlayOneShot(clip, volume);
    }
}