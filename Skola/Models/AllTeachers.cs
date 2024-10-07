using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace Skola.Models
{
    internal class AllTeachers
    {
        public ObservableCollection<Employee> Teachers { get; set; } = new ObservableCollection<Employee>();

        public AllTeachers() =>
            LoadTeachers();

        public void LoadTeachers()
        {
            Teachers.Clear();

            string appDataPath = FileSystem.AppDataDirectory;

            IEnumerable<Employee> teachers = Directory

                                        .EnumerateFiles(appDataPath, "*.teachers.txt")

                                        .Select(filename => new Employee()
                                        {
                                            Filename = filename,
                                            Name = File.ReadAllText(filename)
                                        })

                                        .OrderBy(teacher => teacher.Name);

            foreach (Employee teacher in teachers)
                Teachers.Add(teacher);
        }
    }
}
