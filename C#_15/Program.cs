namespace C__15
{
    internal class Program
    {
        struct MyInfo
        {
            long count;
            long bites;
            float procentCount;
            float procentBites;

            public MyInfo(long bites, long count)
            {
                count = this.count;
                bites = this.bites;
                procentCount = count/100;
                procentBites = bites/100;
            }

            public override string  ToString()
            {
                return count + " " + bites + " " + procentCount + " " + procentBites;
            }
        }
        static void Main(string[] args)
        {
            DirectoryInfo root = new DirectoryInfo(@"C:\Users\user\Desktop\HTML\");
            
            FileInfo[] files = root.GetFiles();

            Dictionary<FileInfo, MyInfo> d = new Dictionary<FileInfo, MyInfo> ();
           
            foreach (FileInfo f in files)
            {
                FileInfo[] filesToRead = root.GetFiles("*.txt", SearchOption.AllDirectories);
                int count = 0;

                foreach (FileInfo f1 in filesToRead)
                {
                    StreamReader tmp = f1.OpenText();
                    if (!d.ContainsKey(f1))
                    {
                        d.Add(f1, new MyInfo(f1.Length, count));
                    }
                    else
                    {
                        count++;
                    }

                    tmp.Close();
                } 
            }
            
            foreach (var f in d)
            {
                Console.WriteLine(f.Key.Name +": " + f.Value.ToString());
            }
                      

           Console.WriteLine("# \t расширение \t кол-во шт. \t обший обьем в байтах \t % от общего кол-ва \t % от общего обьема");
           Console.WriteLine("1\t" + ".txt: \t\t\t" +  d.Keys.Count + "\t\t\t" + d.Values.Count + " ");



            /*FileInfo[] filesToRead1 = root.GetFiles("*.rar", SearchOption.AllDirectories);

            foreach (FileInfo f in filesToRead1)
            {
                StreamReader tmp = f.OpenText();
                count++;
                tmp.Close();
            }
            Console.WriteLine("2\t" + ".rar: \t\t\t" + count + "\t\t\t\t\t" + (double)(count / 100));

            FileInfo[] filesToRead2 = root.GetFiles("*.zip", SearchOption.AllDirectories);

            foreach (FileInfo f in filesToRead2)
            {
                StreamReader tmp = f.OpenText();
                count++;
                tmp.Close();
            }
            Console.WriteLine("3\t" + ".zip: \t\t\t" + count + "\t\t\t\t\t" + (double)(count / 100));*/
        }
    }
}
