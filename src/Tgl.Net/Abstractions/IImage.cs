namespace Tgl.Net.Abstractions
{
    public interface IImage
    {
        ImagePixelFormat Format { get; }
        byte[] Data { get; }
        int Width { get; }
        int Height { get; }
    }
}
