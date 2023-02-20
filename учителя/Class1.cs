using System;

namespace teachers
{

    public class Teacher
    {
        public string name;
        public int birthday;
        public string item;
        public string education;
        public int count;
        public string[][] works;
        

        public Teacher(string a, int b, string c, string ed, int k, string[][] d)
        {
            name = a;
            birthday = b;
            item = c;
            education = ed;
            count = k;
            works = d;
        }

    }
    public class Class1
    {
        private static Teacher[] teachers; 
        
        public static void Main()
        {
            bool menu_checker = true;
            while (menu_checker)
            {
                menu_checker = Menu();
            }
        }

        public static bool Menu()
        {
            Console.Clear();
            Console.WriteLine("--ГЛАВНОЕ МЕНЮ--");
            Console.WriteLine("1) Ввести нового учителя");
            Console.WriteLine("2) Вывести список учителей");
            Console.WriteLine("3) Выход");
            Console.Write("\r\nВыберите действие: ");
            String str=Console.ReadLine();
            switch(str)
            {
                case "1":
                    teachers = Completion();
                    return true;
                case "2":
                    Output(teachers);
                    return true;
                case "3":
                    return false;
                default:
                    return true;
            }
        }
        
        static Teacher[] Completion()
        {
            Console.Clear();
            Console.Write("Введите количество учителей ");
            int n = Convert.ToInt32(Console.ReadLine());
            Teacher[] teachers = new Teacher[n];

            for (int i = 0; i < n; i++)
            {
                Console.Write("Введите имя ");
                string a = Console.ReadLine();
                Console.Write("Введите год рождения ");
                int b = Convert.ToInt32(Console.ReadLine());
                Console.Write("Введите наименование предмета ");
                string c = Console.ReadLine();
                Console.Write("Введите наименование организации, в которой сотрудник получил образлвание: ");
                string ed = Console.ReadLine();
                Console.Write("Введите количество организаций, в которых работал сотрудник ");
                int q = Convert.ToInt32(Console.ReadLine());
                string [][] d = new string[q][];
                for (int j = 0; j < q; j++)
                {
                    string[] work = new string[4];
                    Console.Write("Введите год поступления в организацию ");
                    int date_receipt = Convert.ToInt32(Console.ReadLine());
                    work[0] = Convert.ToString(date_receipt);
                    Console.Write("Введите наименанование организации ");
                    string organization = Console.ReadLine();
                    work[1] = organization;
                    Console.Write("Введите дату увольнения из огранизации ");
                    int date_dismissal = Convert.ToInt32(Console.ReadLine());
                    work[2] = Convert.ToString(date_dismissal);
                    int experience = date_dismissal - date_receipt;
                    work[3] = Convert.ToString(experience);
                    d[j] = work;
                }
                Teacher teacher = new Teacher(a, b, c, ed, q, d);
                teachers[i] = teacher;
                Console.Clear();
            }
            return teachers;
        }

        static void Output(Teacher[] t )
        {
            Console.Clear();
            if (t != null)
            {
                Console.WriteLine("--ВЫБОРКА УЧИТЕЛЕЙ--");
                Console.WriteLine("1) По наименованию предмета ");
                Console.WriteLine("2) По стажу работы на последнем месте ");
                Console.WriteLine("3) По общему стажу работы ");
                Console.WriteLine("4) Вывод всех учителей ");
                Console.Write("\rВыберите действие: ");
                string key = Console.ReadLine();
                switch (key)
                {
                    case "1":
                        Console.Clear();
                        Console.Write("Введите наименование предмета ");
                        string name_item = Console.ReadLine();
                        for (int i = 0; i < t.Length; i++)
                        {
                            if (name_item == t[i].item)
                            {
                                Console.Clear();
                                Console.Write($"ФИО: {t[i].name} \nДата рождения: {t[i].birthday} \nНаименование предмета: {t[i].item} \nНаименование орагнизации, где получил образование: {t[i].education}\n");
                                for (int k = 0; k < t[i].count; k++)
                                {
                                    Console.Write($"Год поступления в органищацию: {t[i].works[k][0]} \nНаименование организации: {t[i].works[k][1]} \nГод увольнения из организации: {t[i].works[k][2]}\n" );
                                }
                            }
                            
                        }

                        Console.ReadLine();
                        Menu();
                        break;
                    
                    case "2":
                        Console.Clear();
                        Console.Write("Введите требуемый стаж раюоты на последнем рабочем месте: ");
                        int count_experience = Convert.ToInt32(Console.ReadLine());
                        foreach (var teacher in t)
                        {
                            if (Convert.ToInt32(teacher.works[teacher.works.Length-1][3]) == count_experience)
                            {
                                Console.Clear();
                                Console.Write($"ФИО: {teacher.name} \nДата рождения: {teacher.birthday} \nНаименование предмета: {teacher.item} \nНаименование орагнизации, где получил образование: {teacher.education}\n");
                                for (int k = 0; k < teacher.count; k++)
                                {
                                    Console.Write($"Год поступления в органищацию: {teacher.works[k][0]} \nНаименование организации: {teacher.works[k][1]} \nГод увольнения из организации: {teacher.works[k][2]}\n" );
                                }
                            }
                            else
                            {
                                Console.Write("Совпадений не найдено");
                            }
                        }
                        Console.ReadLine();
                        Menu();
                        break;
                    
                    case "3":
                        Console.Clear();
                        Console.Write("Введите требуемый общий стаж раюоты: ");
                        int general_experience = Convert.ToInt32(Console.ReadLine());
                        foreach (var teacher in t)
                        {
                            int sum = 0;
                            foreach (var w in teacher.works)
                            {
                                sum += Convert.ToInt32(w[3]);
                            }

                            if (general_experience == sum)
                            {
                                Console.Clear();
                                Console.Write($"ФИО: {teacher.name} \nДата рождения: {teacher.birthday} \nНаименование предмета: {teacher.item} \nНаименование орагнизации, где получил образование: {teacher.education}\n");
                                for (int k = 0; k < teacher.count; k++)
                                {
                                    Console.Write($"Год поступления в органищацию: {teacher.works[k][0]} \nНаименование организации: {teacher.works[k][1]} \nГод увольнения из организации: {teacher.works[k][2]}\n" );
                                }
                            }
                            else
                            {
                                Console.Write("Совпадений не найдено");
                            }
                        }
                        Console.ReadLine();
                        Menu();
                        break;
                    
                    case "4":
                        Console.Clear();
                        foreach (var teacher in t)
                        {
                            Console.Write($"ФИО: {teacher.name} \nДата рождения: {teacher.birthday} \nНаименование предмета: {teacher.item} \nНаименование орагнизации, где получил образование: {teacher.education}\n");
                            for (int k = 0; k < teacher.count; k++)
                            { 
                                Console.Write($"Год поступления в органищацию: {teacher.works[k][0]} \nНаименование организации: {teacher.works[k][1]} \nГод увольнения из организации: {teacher.works[k][2]}\n" );
                            }
                            Console.Write("-----------------------------\n");
                        }
                        Console.ReadLine();
                        Menu();
                        break;
                    
                    default:
                        Menu();
                        break;
                }
            }
            else
            {
                Console.Write("База данных пуста");
                Console.ReadLine();
            }
        }
    }
}