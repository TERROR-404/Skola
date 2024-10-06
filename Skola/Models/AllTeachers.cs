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
        public ObservableCollection<Teacher> Teachers { get; set; } = new ObservableCollection<Teacher>();

        public AllTeachers() =>
            LoadTeachers();

        public void LoadTeachers()
        {
            Teachers.Clear();

            string appDataPath = FileSystem.AppDataDirectory;

            IEnumerable<Teacher> teachers = Directory

                                        .EnumerateFiles(appDataPath, "*.teachers.txt")

                                        .Select(filename => new Teacher()
                                        {
                                            Filename = filename,
                                            Name = File.ReadAllText(filename)
                                        })

                                        .OrderBy(teacher => teacher.Name);

            foreach (Teacher teacher in teachers)
                Teachers.Add(teacher);
        }
    }
}
