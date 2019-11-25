using System.Collections.Generic;

namespace Pokemon.Dataloader.FileReader
{
    public interface IFileReader<T>
    {
        List<T> ReadFile();
    }
}
