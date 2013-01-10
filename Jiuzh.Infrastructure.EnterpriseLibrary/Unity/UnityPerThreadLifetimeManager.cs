using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.Unity;
using System.Threading;

namespace Jiuzh.Infrastructure.EnterpriseLibrary
{
    /// <summary>
    /// 线程级别生命周期
    /// </summary>
    public class UnityPerThreadLifetimeManager : LifetimeManager
    {
        private Thread _thread;
        public UnityPerThreadLifetimeManager(Thread thread)
        {
            _thread = thread;
        }
        public UnityPerThreadLifetimeManager()
            : this(Thread.CurrentThread)
        {
  
        }
        public override object GetValue()
        {
            IDictionary<UnityPerThreadLifetimeManager, object> backingStore = BackingStore;
            return backingStore.ContainsKey(this) ? backingStore[this] : null;
        }

        public override void RemoveValue()
        {
            throw new NotImplementedException();
        }

        public override void SetValue(object newValue)
        {
            IDictionary<UnityPerThreadLifetimeManager, object> backingStore = BackingStore;

            if (backingStore.ContainsKey(this))
            {
                object oldValue = backingStore[this];

                if (!ReferenceEquals(newValue, oldValue))
                {
                    IDisposable disposable = oldValue as IDisposable;

                    if (disposable != null)
                    {
                        disposable.Dispose();
                    }

                    if (newValue == null)
                    {
                        backingStore.Remove(this);
                    }
                    else
                    {
                        backingStore[this] = newValue;
                    }
                }
            }
            else
            {
                if (newValue != null)
                {
                    backingStore.Add(this, newValue);
                }
            }
        }

        private IDictionary<UnityPerThreadLifetimeManager, object> BackingStore
        {
            get
            {
                _thread = (Thread.CurrentThread != null) ? Thread.CurrentThread : _thread;

                return UnityPerThreadLifetimeManager.GetInstances(_thread);
            }
        }

        private static IDictionary<Thread, IDictionary<UnityPerThreadLifetimeManager, object>> totalStore = new Dictionary<Thread, IDictionary<UnityPerThreadLifetimeManager, object>>();

        internal static IDictionary<UnityPerThreadLifetimeManager, object> GetInstances(Thread thread)
        {
            IDictionary<UnityPerThreadLifetimeManager, object> instances;

            if (totalStore.ContainsKey (thread ))
            {
                instances = (IDictionary<UnityPerThreadLifetimeManager, object>)totalStore[thread ];
            }
            else
            {
                lock (totalStore)
                {
                    //删除已经结束的线程
                    IList<Thread> threads = totalStore.Keys.ToList();
                    for (int i = totalStore.Count - 1; i >= 0; i--)
                    {
                        Thread item = threads[i];
                        if (item.IsAlive == false)
                        {
                            IDictionary<UnityPerThreadLifetimeManager, object> removeInstances = (IDictionary<UnityPerThreadLifetimeManager, object>)totalStore[item];
                            foreach (var ins in removeInstances )
                            {
                                IDisposable dispose = ins.Value as IDisposable;
                                if (dispose != null)
                                    dispose.Dispose();
                            }
                            totalStore.Remove(item);
                        }
                    }

                    if (totalStore.ContainsKey(thread))
                    {
                        instances = (IDictionary<UnityPerThreadLifetimeManager, object>)totalStore[thread ];
                    }
                    else
                    {
                        instances = new Dictionary<UnityPerThreadLifetimeManager, object>();
                        totalStore.Add(thread, instances);
                    }
                }
            }

            return instances;
        }
    }
}
