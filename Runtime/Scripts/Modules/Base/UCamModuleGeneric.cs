namespace UCamSystem.Modules
{
    public class UCamModuleGeneric<T> : UCamModule where T: UCamModuleData
    {
        protected T state;

        public void Set(T state) 
        {
            this.state = state;

            if(state == null || !state.Enable)
                Deactive();
        }
    }
}