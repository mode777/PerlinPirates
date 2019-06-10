using System.ComponentModel.Design;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Game.Abstractions
{
    public interface IResourceLoader
    {
        object LoadObject(string rid, Stream stream);
    }
}
