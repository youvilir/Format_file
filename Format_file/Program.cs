using System;
using System.IO;
using System.Text;
using System.Text.Json;

namespace FileFormat
{
    abstract class AbstractFileProcessor
    {
        public void ProcessFile(string fileName)
        {
            if (File.Exists(fileName) && Path.GetExtension(fileName).Contains(GetFormat()))
                StartWork(fileName);
            else
                Console.WriteLine("incorrect file format or file not exist");
        }

        protected abstract string GetFormat();
        protected abstract void StartWork(string fileName);
    }

    class FileProcessor
    {
        public AbstractFileProcessor fileProcessor;

        public FileProcessor(AbstractFileProcessor fileProcessor)
        {
            this.fileProcessor = fileProcessor;
        }

        public void ProcessFile(string fileName)
        {
            fileProcessor.ProcessFile(fileName);
        }

    }

    class HtmlProcess : AbstractFileProcessor
    {
        protected override string GetFormat() => ".html";

        protected override void StartWork(string fileName)
        {
            Console.WriteLine("Process with html file");
        }
    }

    class JsonProcess : AbstractFileProcessor
    {
        protected override string GetFormat() => ".json";

        protected override void StartWork(string fileName)
        {
            Console.WriteLine("Process with json file");
        }
    }

    class TextProcess : AbstractFileProcessor
    {
        protected override string GetFormat() => ".txt";

        protected override void StartWork(string fileName)
        {
            Console.WriteLine("Process with txt file");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            FileProcessor fp = new FileProcessor(new HtmlProcess());
            fp.ProcessFile("hello.html");

            fp.fileProcessor = new TextProcess();
            fp.ProcessFile("hello.txt");

            fp.fileProcessor = new JsonProcess();
            fp.ProcessFile("hello.json");


            Console.ReadLine();
        }
    }
}