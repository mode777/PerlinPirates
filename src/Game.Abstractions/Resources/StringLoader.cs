using System.IO;

namespace Game.Abstractions
{
    public abstract class StringLoader<T> : ResourceLoader<T>
    {
        public override T Load(string rid, Stream stream)
        {
            using (StreamReader sr = new StreamReader(stream))
            {
                return Load(rid, sr.ReadToEnd());
            }
        }

        protected abstract T Load(string rid, string str);
    }

    public class StringLoader : StringLoader<string>
    {
        protected override string Load(string rid, string str)
        {
            return str;
        }
    }
}