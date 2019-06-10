using PTTDigital.SmileTrade.BusinessContracts;
using PTTDigital.SmileTrade.Utils;
using System;

namespace PTTDigital.SmileTrade.Business {

    public abstract class Child : IChild {

        protected IParentBusiness parentBusinessNode;

        public abstract string Name { get; }

        public Child()
            : this(null) {
        }

        public Child(IParentBusiness parentBusinessNode) {
            this.parentBusinessNode = parentBusinessNode;
            AddTrace("Create");
        }

        public virtual bool IsMultiple {
            get {
                return false;
            }
        }

        public virtual bool IsExclusive {
            get {
                return false;
            }
        }

        public virtual bool IsAllowedToRun {
            get {
                return true;
            }
        }

        public abstract void Run();

        public virtual bool Unload() {
            if(parentBusinessNode != null) {
                parentBusinessNode.NotifyUnloaded(this);
            }
            AddTrace("Unload");
            return true;
        }

        public abstract void Stop();

        protected void AddTrace(string methodName)
        {
            if (!(this is DatabaseSettings))
            {
                Settings.Trace.AppendLine(String.Format("{0} {1} {2} {3}", DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss.fff"), Settings.Loginname, this.GetType().Name, methodName));
            }
        }
    }
}
