using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameController : MonoBehaviour
{

    private bool playEnabled = false;
    [SerializeField] private Camera cam;
    [SerializeField] private BalanceMeter balanceMeter;
    [SerializeField] private BGTreeTexture tree;
    [SerializeField] private Score score;
    [SerializeField] private SpiderController spider;
    [SerializeField] private AcornController acorn;
    [SerializeField] private Death death;
    [SerializeField] private Animator squirrelAnimator;
    [SerializeField] private SoundController soundController;
    [SerializeField] private Animator titleAnimator;
    private bool useGamepad = false;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        CheckForGamepad(); 
        if (!playEnabled && !death.isDead && Input.anyKeyDown) {
            playEnabled = true;
            BeginGame();
        }
        if (death.isDead && playEnabled) {
            playEnabled = false;
            soundController.Die();
            balanceMeter.Die();
            tree.Die();
            score.Die();
            spider.Die();
            acorn.Die();
        }
        if (death.isDead && Input.anyKeyDown) {
            SceneManager.LoadScene( SceneManager.GetActiveScene().name );
            // death.Reset();
            // EnablePlayControllers();
            // StartPlaySequence();
        }        
    }

    private void BeginGame()
    {
        soundController.IntroTransition();
        List<IEnumerator> list = new List<IEnumerator>();
        Vector3 end = new Vector3(cam.transform.position.x + 6.4f, 0f);
        list.Add(Utils.StaticUtils.MoveOverSeconds(cam.transform, end, 3f));
        list.Add(EnablePlayControllersAsync());
        list.Add(StartPlaySequence());
        StartCoroutine(UtilsMono.couroutineSequenceWithPause(list, 0f, false));
    }

    private IEnumerator EnablePlayControllersAsync() {
        EnablePlayControllers();
        yield return null;
    }

    private void EnablePlayControllers() {
        balanceMeter.playEnabled = true;
        tree.playEnabled = true;
        score.playEnabled = true;
        spider.playEnabled = true;
        acorn.playEnabled = true;
        squirrelAnimator.SetBool("PlayEnabled", true);
        soundController.StartGame();
        playEnabled = true;
    }

    private IEnumerator StartPlaySequence() {
        List<IEnumerator> playSequence = new List<IEnumerator>();
        playSequence.Add(increaseSpeed());
        playSequence.Add(increaseSpeed());
        playSequence.Add(increaseSpeed());
        playSequence.Add(increaseSpeed());
        playSequence.Add(increaseSpeed());
        playSequence.Add(increaseSpeed());
        playSequence.Add(increaseSpeed());
        playSequence.Add(increaseSpeed());
        playSequence.Add(increaseSpeed());
        playSequence.Add(increaseSpeed());
        playSequence.Add(increaseSpeed());
        playSequence.Add(increaseSpeed());
        playSequence.Add(increaseSpeed());
        yield return StartCoroutine(UtilsMono.couroutineSequenceWithPause(playSequence, 5f, false));
    }

    private IEnumerator increaseSpeed() {
        // Debug.Log("increase speed");
        if (!playEnabled) yield return null;
        tree.SpeedUp();
        balanceMeter.speed += 3f;
        balanceMeter.turbulenceSpeed += 2f;
        yield return null;
    }

    private void CheckForGamepad()
    {
        foreach (var str in Input.GetJoystickNames())
        {
            if (str.Length > 0)
            {
                titleAnimator.SetBool("useGamepad", true);
                return;
            }
        }
        titleAnimator.SetBool("useGamepad", false);
    }
}
