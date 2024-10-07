using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace Skola.Models
{
    internal class AllStudents
    {
        public ObservableCollection<Employee> Students { get; set; } = new ObservableCollection<Employee>();

        public AllStudents() =>
            LoadStudents();

        public void LoadStudents()
        {
            Students.Clear();

            string appDataPath = FileSystem.AppDataDirectory;

            IEnumerable<Employee> students = Directory

                                        .EnumerateFiles(appDataPath, "*.students.txt")

                                        .Select(filename => new Employee()
                                        {
                                            Filename = filename,
                                            Name = File.ReadAllText(filename)
                                        })

                                        .OrderBy(student => student.Name);

            foreach (Employee student in students)
                Students.Add(student);
        }
    }
}
