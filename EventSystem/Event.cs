namespace ProjectTemplate.EventSystem
{
    public class Event
    {
        protected List<Action> pListeners = new();

        public virtual void Raise()
        {
            for (int i = this.pListeners.Count - 1; i >= 0; i--)
            {
                this.pListeners[i].Invoke();
            }
        }

        public void RegistererListener(Action listener)
        {
            this.pListeners.Add(listener);
        }

        public void UnregisterListener(Action listener)
        {
            this.pListeners.Remove(listener);
        }
    }

    public abstract class Event<T0>
    {
        protected List<Action<T0>> pListeners = new();

        public virtual void Raise(T0 arg1)
        {
            for (int i = this.pListeners.Count; i >= 0; i--)
            {
                this.pListeners[i].Invoke(arg1);
            }
        }

        public void RegisterListener(Action<T0> listener)
        {
            this.pListeners.Add(listener);
        }

        public void UnregisterListener(Action<T0> listener)
        {
            this.pListeners.Remove(listener);
        }
    }

    public abstract class Event<T0, T1>
    {
        protected List<Action<T0, T1>> pListeners = new();

        public void Raise(T0 arg0, T1 arg1)
        {
            for (int i = this.pListeners.Count; i >= 0; i--)
            {
                this.pListeners[i].Invoke(arg0, arg1);
            }
        }

        public void RegisterListener(Action<T0, T1> listener)
        {
            this.pListeners.Add(listener);
        }

        public void UnregisterListener(Action<T0, T1> listener)
        {
            this.pListeners.Remove(listener);
        }
    }

    public abstract class Event<T0, T1, T2>
    {
        protected List<Action<T0, T1, T2>> pListeners = new();

        public void Raise(T0 arg0, T1 arg1, T2 arg2)
        {
            for (int i = this.pListeners.Count; i >= 0; i--)
            {
                this.pListeners[i].Invoke(arg0, arg1, arg2);
            }
        }

        public void RegisterListener(Action<T0, T1, T2> listener)
        {
            this.pListeners.Add(listener);
        }

        public void UnregisterListener(Action<T0, T1, T2> listener)
        {
            this.pListeners.Remove(listener);
        }
    }

    public abstract class Event<T0, T1, T2, T3>
    {
        protected List<Action<T0, T1, T2, T3>> pListeners = new();

        public void Raise(T0 arg0, T1 arg1, T2 arg2, T3 arg3)
        {
            for (int i = this.pListeners.Count; i >= 0; i--)
            {
                this.pListeners[i].Invoke(arg0, arg1, arg2, arg3);
            }
        }

        public void RegisterListener(Action<T0, T1, T2, T3> listener)
        {
            this.pListeners.Add(listener);
        }

        public void UnregisterListener(Action<T0, T1, T2, T3> listener)
        {
            this.pListeners.Remove(listener);
        }
    }
}