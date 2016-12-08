using UnityEngine;
using System.Collections;

namespace YUI {

    public delegate void OnUIStateChange(object sender,UIState ostate,UIState nstate);

    public enum UIState { 
        None,  //无或者销毁
        Init,    //初始化
        Load,    //加载
        Ready, //就绪
        Close,    //关闭
    }
}
