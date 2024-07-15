
namespace C__15
{
    internal class Program
    {
        struct MyInfo
        {
            public long count;
            public long bites;
            public float procentCount;
            public float procentBites;

            public MyInfo(long bites, long count)
            {
                this.count = count;
                this.bites = bites;
                procentCount = count / 100f;
                procentBites = bites / 100f;
            }

            public override string ToString()
            {
                return count + " " + bites + " " + procentCount + " " + procentBites;
            }
        }

        static void Main(string[] args)
        {
            DirectoryInfo root = new DirectoryInfo(@"C:\Users\user\Desktop\HTML\");
            FileInfo[] files = root.GetFiles("*", SearchOption.AllDirectories);

            Dictionary<string, MyInfo> d = new Dictionary<string, MyInfo>();

            foreach (FileInfo file in files)
            {
                string extension = file.Extension;
                if (!d.ContainsKey(extension))
                {
                    d[extension] = new MyInfo(0, 0);
                }

                MyInfo info = d[extension];
                info = new MyInfo(info.bites + file.Length, info.count + 1);
                d[extension] = info;
            }

            Console.WriteLine("# | расширение | кол-во шт. | обший обьем в байтах | % от общего кол-ва | % от общего обьема");

            int totalFiles = files.Length;
            long totalSize = 0;
            foreach (var file in files)
            {
                totalSize += file.Length;
            }

            int index = 1;
            foreach (var entry in d)
            {
                string extension = entry.Key;
                MyInfo info = entry.Value;

                float procentCount = (info.count / (float)totalFiles) * 100;
                float procentBites = (info.bites / (float)totalSize) * 100;

                Console.WriteLine($"{index}\t{extension}: \t  {info.count}\t\t\t{info.bites}\t\t   {procentCount:F2}%\t\t{procentBites:F2}%");
                index++;
            }
        }
    }
}
