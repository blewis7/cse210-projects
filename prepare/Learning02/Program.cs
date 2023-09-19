using System;

class Program
{
    static void Main(string[] args)
    {
        Job job1 = new Job();
        job1._jobTitle = "Software Engineer";
        job1._company = "Google";
        job1._startYear = 2012;
        job1._endYear = 2015;

        Job job2 = new Job();
        job2._jobTitle = "Senior Software Engineer";
        job2._company = "Twitter";
        job2._startYear = 2015;
        job2._endYear = 2016;

        Resume resume1 = new Resume();
        resume1._name = "Test Person";
        resume1._jobs = new List<Job> {job1, job2}; 

        resume1.Display();
    }
}