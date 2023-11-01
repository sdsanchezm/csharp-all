public class Student
{
    private DateTime _birthdate; // private classes always with underscore, and camelCase

    public void SetBirthdate(DateTime birthdate)
    {
        this._birthdate = birthdate;
    }

    public DateTime GetBirthdate()
    {
        return _birthdate;
    }
}

// the above code is the same as:

public class Student
{
    private DateTime _birthdate;

    public DateTime Birthdate
    {
        get { return this._birthdate; }
        set { _birthdate = value; }
    }
}

// the above code could be even shorter, like the below code (auto-implemented properties):

public class Student
{
    // These are auto-implemented properties (get; set;)
    public DateTime Birthdate { get; set; }
}