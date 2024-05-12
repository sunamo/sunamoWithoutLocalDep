


namespace SunamoCollectionOnDrive;


public class PpkOnDrive<T> : PpkOnDriveBase<T> where T : IParserCollectionOnDrive
{
    public override
#if ASYNC
    async Task
#else
void
#endif
    Load()
    {
        if (File.Exists(a.file))
        {
            int dex = 0;
            foreach (string item in
#if ASYNC
            await
#endif
            File.ReadAllLinesAsync(a.file))
            //TFSE.ReadAllLines(a.file))
            {
                T t = (T)Activator.CreateInstance(typeof(T));
                t.Parse(item);
                Add(t);
                dex++;
            }
        }
    }

    public PpkOnDrive(PpkOnDriveArgs a) : base(a)
    {

    }

    public PpkOnDrive(string file2, bool load = true) : base(new PpkOnDriveArgs { file = file2, load = load })
    {
    }

    public PpkOnDrive(string file, bool load, bool save) : base(new PpkOnDriveArgs { file = file, load = load, save = save })
    {
    }
}
