using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Team8.TopicTwister
{
    public class Querys : MonoBehaviour
    {
        List<Student> students = new List<Student>();
        void Start()
        {
            students.Add(new Student() { Id = 0, Name = "Unelen", LastName = "Pino", NickName = "Une", Regular = true });
            students.Add(new Student() { Id = 1, Name = "Sebastian", LastName = "Fiochi", NickName = "Seba", Regular = true });
            students.Add(new Student() { Id = 2, Name = "Yesica", LastName = "Navarro", NickName = "Yeka", Regular = false });
            students.Add(new Student() { Id = 3, Name = "Armando", LastName = "Hess", NickName = "Pela", Regular = false });
            students.Add(new Student() { Id = 4, Name = "Rodrigo", LastName = "Forcada", NickName = "Gori", Regular = true });

            var regularStudent = students.Where(r => r.Regular).OrderBy(l => l.LastName);

            Debug.Log("Estudiantes Regulares");
            foreach(var rS in regularStudent)
            {
                Debug.Log(rS.Name);
            }
            Debug.Log("Estudiantes que su nombre comienzan con vocal");
            var vowelName = students.Where(s => s.Name.StartsWith('A') || s.Name.StartsWith('E') || s.Name.StartsWith('I') || s.Name.StartsWith('O') || s.Name.StartsWith('U'));
            foreach (var vS in vowelName)
            {
                Debug.Log(vS.Name);
            }

            List<Student> lastNameMoreThanFour = students.Where(s => s.LastName.Length > 4).ToList();
            ArrayList lastNameLessThanFour = students.Where(s => s.Id <= 2) as ArrayList;
            
            var arrayStudent = students.Select(r => r.Id).ToArray();
            var arrayNameANDNick = students.Select(student => new { myName = student.Name, myNick = student.NickName }).ToArray();

            foreach (var nn in arrayNameANDNick)
            {
                Debug.Log(nn.myName + " - " + nn.myNick);
            }

            Dictionary<string,string> arrayNameANDNickDic = students
                .Select(student => new { myName = student.Name, myNick = student.NickName })
                .ToDictionary(sName => sName.myName, sNick => sNick.myNick);

            Dictionary<int, Student> studentIDDictonary = students.ToDictionary(students => students.Id);
            
            foreach(KeyValuePair<int, Student> st in studentIDDictonary)
            {
                Debug.Log($"El estudiente con el codigo {st.Key} es {st.Value.Name}, y actualmente se considera como alumno regular {st.Value.Regular}");
            }

        }

    }

    public class Student
    {
        public int Id { set; get; }
        public string Name { set; get; }
        public string LastName { set; get; }
        public string NickName { set; get; }
        public bool Regular { set; get; }

        ~Student()
        {
            Debug.Log("Me destruyeron");
        }
    }
}
