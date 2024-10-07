using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace Skola.Models
{
    internal class AllHelp
    {
        public ObservableCollection<Employee> Help { get; set; } = new ObservableCollection<Employee>();

        public AllHelp() =>
            LoadHelp();

        public void LoadHelp()
        {
            Help.Clear();

            string appDataPath = FileSystem.AppDataDirectory;

            IEnumerable<Employee> helps = Directory

                                        .EnumerateFiles(appDataPath, "*.helps.txt")

                                        .Select(filename => new Employee()
                                        {
                                            Filename = filename,
                                            Name = File.ReadAllText(filename)
                                        })

                                        .OrderBy(help => help.Name);

            foreach (Employee help in helps)
                Help.Add(help);
        }
    }
}
