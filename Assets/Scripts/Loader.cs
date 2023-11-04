using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class Loader : MonoBehaviour
{
    [SerializeField] private GameObject _loaderCanvas;
    [SerializeField] private UnityEngine.UI.Image _progressBar;
    [SerializeField] private UnityEngine.UI.Image _backgroundImage;
    private float _target;
    private float _time;
    public static Loader Instance;
    private void Awake() {
        if(Instance == null){
            Instance = this;
        }else{
            Destroy(gameObject);
        }
    }
    public void Reset()
    {
        _target = 0;
        _progressBar.fillAmount = 0;
    }
    public void SetTarget(float i){
        _target = i;
    }
    public async void SetActive(bool state){
        if(state == true){
            StartCoroutine(FadeImage(true));
            _loaderCanvas.SetActive(true);
        }else{
            StartCoroutine(FadeImage(false));
            await Task.Delay(500);
            _loaderCanvas.SetActive(false);
        }
    }

    public void SetLoaderFillAmount(float i){
        _progressBar.fillAmount = i;
    }

    public IEnumerator FadeImage(bool fade)
    {
        _time = Time.deltaTime*0.5f;
        if (fade)
        {
            for (float i = 0; i <= 1; i += _time)
            {
                _progressBar.color = new Color(255,255,255,i);
                _backgroundImage.color = new Color(255, 255, 255, i);     
                yield return null;
            }
        }else{
            for (float i = 1; i >= 0; i -= Time.deltaTime*2)
            {
                _progressBar.color = new Color(255,255,255,i);
                _backgroundImage.color = new Color(255, 255, 255, i);
                yield return null;
            }
        }
    }

    void Update()
    {
        _progressBar.fillAmount = Mathf.MoveTowards(_progressBar.fillAmount, _target, 3*Time.deltaTime);
    }
}
