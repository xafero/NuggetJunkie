using CommandLine;

namespace NuggetJunkie
{
    public class Options
    {
        [Option('p', "project", HelpText = "The project to operate on.")]
        public string Project { get; set; }

        [Option('m', "makePacks", HelpText = "Make packages configuration.")]
        public bool MakePacks { get; set; }
    }
}