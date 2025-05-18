using System;
using System.Collections.Generic;

public interface IObserver
{
    void Update(string message);
}

public interface ISubject
{
    void Attach(IObserver observer);
    void Detach(IObserver observer);
    void Notify();
}

public class Subject : ISubject
{
    private List<IObserver> _observers = new List<IObserver>();
    private string _message;

    public void Attach(IObserver observer)
    {
        Console.WriteLine("Subject: Attached an observer");
        _observers.Add(observer);
    }

    public void Detach(IObserver observer)
    {
        _observers.Remove(observer);
        Console.WriteLine("Subject: Detached an observer");
    }

    public void Notify()
    {
        Console.WriteLine("Subject: Notifying observers");
        foreach (var observer in _observers)
        {
            observer.Update(_message);
        }
    }

    public void CreateMessage(string message)
    {
        _message = message;
        Notify();
    }
}

public class Observer : IObserver
{
    private string _name;

    public Observer(string name)
    {
        _name = name;
    }

    public void Update(string message)
    {
        Console.WriteLine($"{_name} menerima pesan: {message}");
    }
}

class Program
{
    static void Main(string[] args)
    {
        var subject = new Subject();

        var observer1 = new Observer("Observer A");
        var observer2 = new Observer("Observer B");

        subject.Attach(observer1);
        subject.Attach(observer2);

        subject.CreateMessage("Katalog baru telah dirilis!");

        subject.Detach(observer2);

        subject.CreateMessage("Diskon spesial untuk minggu ini!");
    }
}
