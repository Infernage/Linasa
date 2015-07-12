using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

class Job
{
    private bool done = false;
    protected readonly object handle = new object();
    private Thread thread = null;
    public bool IsDone
    {
        get
        {
            bool tmp;
            lock (handle)
            {
                tmp = done;
            }
            return tmp;
        }
        set
        {
            lock (handle)
            {
                done = value;
            }
        }
    }

    public virtual void Start()
    {
        thread = new Thread(Run);
        thread.Start();
    }

    public virtual void Abort()
    {
        thread.Abort();
    }

    protected virtual void RunImpl()
    {
        
    }

    protected virtual void OnFinished()
    {

    }

    public virtual bool Update()
    {
        if (IsDone)
        {
            OnFinished();
            return true;
        }
        return false;
    }

    IEnumerator WaitFor()
    {
        while (!Update())
        {
            yield return null;
        }
    }

    private void Run()
    {
        RunImpl();
        IsDone = true;
    }
}
