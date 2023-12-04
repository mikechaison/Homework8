using System;

//Порушений принцип відкритості/закритості

class Email
{
    public String Theme { get; set; }
    public String From { get; set; }
    public String To { get; set; }
}

class EmailSender
{
    public void Send(Email email, IEmailFormatter formatter)
    {
        // ... sending...
        Console.WriteLine(formatter.FormatReport(email));
    }
}

interface IEmailFormatter
{
    String FormatReport(Email email);
}

class ShortFormFormatter: IEmailFormatter
{
    String IEmailFormatter.FormatReport(Email email)
    {
        string s = "Email from '" + email.From + "' to '" + email.To + "' was send";
        return s;
    }
}

class LongFormFormatter: IEmailFormatter
{
    String IEmailFormatter.FormatReport(Email email)
    {
        string s = "Email from " + email.From + " to " + email.To + " with theme " + email.Theme + " was send";
        return s;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Email e1 = new Email() { From = "Me", To = "Vasya", Theme = "Who are you?" };
        Email e2 = new Email() { From = "Vasya", To = "Me", Theme = "vacuum cleaners!" };
        Email e3 = new Email() { From = "Kolya", To = "Vasya", Theme = "No! Thanks!" };
        Email e4 = new Email() { From = "Vasya", To = "Me", Theme = "washing machines!" };
        Email e5 = new Email() { From = "Me", To = "Vasya", Theme = "Yes" };
        Email e6 = new Email() { From = "Vasya", To = "Petya", Theme = "+2" };

        EmailSender es = new EmailSender();
        ShortFormFormatter shortFormFormatter = new ShortFormFormatter();
        LongFormFormatter longFormFormatter = new LongFormFormatter();
        es.Send(e1, shortFormFormatter);
        es.Send(e2, longFormFormatter);
        es.Send(e3, shortFormFormatter);
        es.Send(e4, longFormFormatter);
        es.Send(e5, shortFormFormatter);
        es.Send(e6, longFormFormatter);
    }
}