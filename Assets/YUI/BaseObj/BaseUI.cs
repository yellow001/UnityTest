using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using YUI;

[RequireComponent(typeof(AudioSource))]
public abstract class BaseUI : MonoBehaviour {

    public event OnUIStateChange UIStateChangeEvent=null;
    
    private UIState _uistate=UIState.None;
    protected UIState State {
        get {
            return _uistate;
        }
        set {
            UIState nstate = value;
            if (_uistate != nstate) {
                if (UIStateChangeEvent != null) {
                    UIStateChangeEvent(this.gameObject, _uistate, nstate);     //事件调用
                }
                _uistate = nstate;  //改变状态
            }
        }

    }




	// Use this for initialization
	void Start () {
        State = UIState.Init;
        OnStart();
	}
	
	// Update is called once per frame
	void Update () {
        if (State == UIState.Ready) {
            OnUpdate();
        }
	}

    /// <summary>
    /// 外界调用关闭函数
    /// </summary>
    public void Close() {
        State = UIState.Close;
        OnClose();
        Destroy(this.gameObject);
    }

    void OnDestroy() {
        State = UIState.None;
    }

    /// <summary>
    /// 子类可覆盖，在Start()中调用
    /// </summary>
    protected virtual void OnStart() {
        PlayStartAu();
    }

    /// <summary>
    /// 子类可覆盖，当 state 为 ready 时在Update()中调用
    /// </summary>
    protected virtual void OnUpdate() { }

    /// <summary>
    /// 子类可覆盖，在Close()中调用
    /// </summary>
    protected virtual void OnClose() {
        PlayCloseAu();
    }

    /// <summary>
    /// 外界调用，当打开UI时调用函数 SetUI  LoadDataAsyn
    /// </summary>
    public void SetUIOpening(params object[] uiparams) {
        SetUI(uiparams);
        State=UIState.Load;     //设为加载
        StartCoroutine(LoadDataAsyn());     //开始加载
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="uiparams"></param>
    protected virtual void SetUI(params object[] uiparams)
    {
        
    }


    IEnumerator LoadDataAsyn(){
        yield return new WaitForSeconds(0);
        if(State==UIState.Load){
            OnLoad();
            State = UIState.Ready;
        }
    }

    /// <summary>
    /// 子类可重写，由 LoadDataAsyn() 调用
    /// </summary>
    protected virtual void OnLoad() { }


    protected virtual void PlayStartAu() { }

    protected virtual void PlayCloseAu() { }
}
