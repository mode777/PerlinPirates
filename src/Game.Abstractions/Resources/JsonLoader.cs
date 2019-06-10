using Newtonsoft.Json;

namespace Game.Abstractions
{
    public abstract class JsonLoader<T, TJson> : StringLoader<T>
    {
        protected override T Load(string rid, string str)
        {
            return Load(rid, JsonConvert.DeserializeObject<TJson>(str));
        }
        
        protected abstract T Load(string rid, TJson data);
    }
}