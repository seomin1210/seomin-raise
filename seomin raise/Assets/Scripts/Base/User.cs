using System.Collections.Generic;

[System.Serializable]

public class User
{
    public long money;
    public int userJob;
    public long userJobc;
    public long userJobs;
    public long userStr;
    public long userDex;
    public long userInt;
    public List<Stats> statsList = new List<Stats>();
    public List<Job> jobList = new List<Job>();
}
