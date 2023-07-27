using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using Unity.Jobs;
using UnityEngine;

public class JOBS : MonoBehaviour
{

    private void Start()
    {
        sumEachElement();
    }

    public  void sumEachElement()
    {

        NativeArray<int> a = new NativeArray<int>(4, Allocator.TempJob);

        NativeArray<int> b = new NativeArray<int>(4, Allocator.TempJob);

        NativeArray<int> c = new NativeArray<int>(4, Allocator.TempJob);

        for(int i  = 0; i < 4; i++) 
        {
            a[i] = i + 1;
            b[i] = i + 1;
        }
        IncrementByDeltaTimeJob myParallelJobs = new IncrementByDeltaTimeJob();
        myParallelJobs.a = a;
        myParallelJobs.b = b;
        myParallelJobs.c = c;

        JobHandle handle = myParallelJobs.Schedule(4, 2);
        
        handle.Complete();

        foreach(int i in c)
        {
            Debug.LogError(i);
        }

        for(int i =0; i < c.Length; i++)  
        {
            Debug.Log(c[i]);
        }
        // Free the memory allocated by the arrays
        a.Dispose();
        b.Dispose();
        c.Dispose();

    }

    struct IncrementByDeltaTimeJob : IJobParallelFor
    {
        public NativeArray<int> a;
        public NativeArray<int> b;
        public NativeArray<int> c;

        public void Execute(int i)
        {
            c[i] = a[i] + b[i];
        }
    }
}


