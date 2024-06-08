using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

abstract class Person
{
    public string Name { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
    public string Age { get; set; }

    abstract public void SetUserData(string name, string password, string email, string age);
}

class Doctor : Person
{
    public override void SetUserData(string name, string password, string email, string age)
    {
        this.Name = name;
        this.Password = password;
        this.Email = email;
        this.Age = age;
    }
}

class Patient : Person
{
    public override void SetUserData(string name, string password, string email, string age)
    {
        this.Name = name;
        this.Password = password;
        this.Email = email;
        this.Age = age;
    }
}

class Pharmacist : Person
{
    public override void SetUserData(string name, string password, string email, string age)
    {
        this.Name = name;
        this.Password = password;
        this.Email = email;
        this.Age = age;
    }
}

class Medicine
{
    public string Name { get; set; }
    public string Dosage { get; set; }
    public string Schedule { get; set; }
    public string IsSafe { get; set; }

    public static Dictionary<string, Medicine> GetMedicines()
    {
        return new Dictionary<string, Medicine>
        {
            { "Paracetamol", new Medicine { Name = "Paracetamol", Dosage = "500mg", Schedule = "Every 6 hours", IsSafe = "Yes" } },
            { "Ibuprofen", new Medicine { Name = "Ibuprofen", Dosage = "200mg", Schedule = "Every 4 hours", IsSafe = "Yes" } },
            { "Amoxicillin", new Medicine { Name = "Amoxicillin", Dosage = "500mg", Schedule = "Twice a day", IsSafe = "Yes" } },
            { "Loratadine", new Medicine { Name = "Loratadine", Dosage = "10mg", Schedule = "Once a day", IsSafe = "Yes" } },
            { "Omeprazole", new Medicine { Name = "Omeprazole", Dosage = "20mg", Schedule = "Once a day", IsSafe = "Yes" } }
        };
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        List<Patient> patientList = new List<Patient>();
        List<Pharmacist> pharmacistList = new List<Pharmacist>();
        List<Doctor> doctorList = new List<Doctor>();

        while (true)
        {
            Console.WriteLine("1- Sign up");
            Console.WriteLine("2- Login");
            int choice = int.Parse(Console.ReadLine());

            if (choice == 1)
            {
                SignUp(doctorList, patientList, pharmacistList);
            }
            else if (choice == 2)
            {
                Login(doctorList, patientList, pharmacistList);
            }
            else
            {
                Console.WriteLine("Invalid choice, exiting...");
                Environment.Exit(0);
            }
        }
    }

    static void SignUp(List<Doctor> doctorList, List<Patient> patientList, List<Pharmacist> pharmacistList)
    {
        Console.WriteLine("1- Sign up as Doctor");
        Console.WriteLine("2- Sign up as Patient");
        Console.WriteLine("3- Sign up as Pharmacist");
        int userType = int.Parse(Console.ReadLine());

        Console.WriteLine("Please enter email");
        string email = Console.ReadLine();
        Console.WriteLine("Please enter password");
        string password = Console.ReadLine();
        Console.WriteLine("Please enter name");
        string name = Console.ReadLine();
        Console.WriteLine("Please enter age");
        string age = Console.ReadLine();

        string emailPattern = @"^[\w\.-]+@(yahoo|gmail|hotmail)\.com$";
        string agePattern = @"^\d+$";
        string namePattern = @"^[a-zA-Z]+$";

        if (Regex.IsMatch(email, emailPattern) && Regex.IsMatch(age, agePattern) && Regex.IsMatch(name, namePattern))
        {
            switch (userType)
            {
                case 1:
                    Doctor doctor = new Doctor();
                    doctor.SetUserData(name, password, email, age);
                    doctorList.Add(doctor);
                    Console.WriteLine("Successfully signed up as Doctor");
                    break;
                case 2:
                    Patient patient = new Patient();
                    patient.SetUserData(name, password, email, age);
                    patientList.Add(patient);
                    Console.WriteLine("Successfully signed up as Patient");
                    break;
                case 3:
                    Pharmacist pharmacist = new Pharmacist();
                    pharmacist.SetUserData(name, password, email, age);
                    pharmacistList.Add(pharmacist);
                    Console.WriteLine("Successfully signed up as Pharmacist");
                    break;
                default:
                    Console.WriteLine("Invalid user type");
                    break;
            }
        }
        else
        {
            Console.WriteLine("Invalid data format");
        }
    }

    static void Login(List<Doctor> doctorList, List<Patient> patientList, List<Pharmacist> pharmacistList)
    {
        Console.WriteLine("1- Login as Doctor");
        Console.WriteLine("2- Login as Patient");
        Console.WriteLine("3- Login as Pharmacist");
        int userType = int.Parse(Console.ReadLine());

        Console.WriteLine("Please enter email");
        string email = Console.ReadLine();
        Console.WriteLine("Please enter password");
        string password = Console.ReadLine();

        switch (userType)
        {
            case 1:
                if (AuthenticateUser(doctorList, email, password))
                {
                    Console.WriteLine("Welcome Doctor! You have logged in successfully.");
                    DoctorMenu();
                }
                else
                {
                    Console.WriteLine("Invalid email or password");
                }
                break;
            case 2:
                if (AuthenticateUser(patientList, email, password))
                {
                    Console.WriteLine("Welcome Patient! You have logged in successfully.");
                    PatientMenu();
                }
                else
                {
                    Console.WriteLine("Invalid email or password");
                }
                break;
            case 3:
                if (AuthenticateUser(pharmacistList, email, password))
                {
                    Console.WriteLine("Welcome Pharmacist! You have logged in successfully.");
                    PharmacistMenu();
                }
                else
                {
                    Console.WriteLine("Invalid email or password");
                }
                break;
            default:
                Console.WriteLine("Invalid user type");
                break;
        }
    }

    static bool AuthenticateUser<T>(List<T> userList, string email, string password) where T : Person
    {
        foreach (var user in userList)
        {
            if (user.Email == email && user.Password == password)
            {
                return true;
            }
        }
        return false;
    }

    static void DoctorMenu()
    {
        Console.WriteLine("1- Add Prescription");
        Console.WriteLine("2- View Prescriptions");
        int choice = int.Parse(Console.ReadLine());
        // Implement Doctor's functionalities
    }

    static void PatientMenu()
    {
        Console.WriteLine("1- Search for Medicine");
        Console.WriteLine("2- View Prescriptions");
        int choice = int.Parse(Console.ReadLine());

        if (choice == 1)
        {
            SearchMedicine();
        }
        // Implement other Patient's functionalities
    }

    static void PharmacistMenu()
    {
        Console.WriteLine("1- Search for Patient's Prescription");
        Console.WriteLine("2- View Medicines");
        int choice = int.Parse(Console.ReadLine());
        // Implement Pharmacist's functionalities
    }

    static void SearchMedicine()
    {
        var medicines = Medicine.GetMedicines();
        Console.WriteLine("Enter medicine name:");
        string medicineName = Console.ReadLine();

        if (medicines.TryGetValue(medicineName, out Medicine medicine))
        {
            Console.WriteLine($"Name: {medicine.Name}");
            Console.WriteLine($"Dosage: {medicine.Dosage}");
            Console.WriteLine($"Schedule: {medicine.Schedule}");
            Console.WriteLine($"Is Safe: {medicine.IsSafe}");
        }
        else
        {
            Console.WriteLine("Medicine not found");
        }
    }
}

