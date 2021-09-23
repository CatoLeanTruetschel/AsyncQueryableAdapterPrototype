using System.IO;

namespace AsyncQueryableAdapter.Specifications.Generator
{
    public sealed class ApplicationOptions
    {
        public string OutputDirectory { get; set; } = Directory.GetCurrentDirectory();
    }
}
