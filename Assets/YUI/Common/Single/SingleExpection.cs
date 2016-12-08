using UnityEngine;
using System.Collections;

namespace YUI
{
    public class SingleExpection : System.Exception
    {
        public SingleExpection(string msg) : base(msg) { }
    }

}