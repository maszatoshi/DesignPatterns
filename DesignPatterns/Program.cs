using DesignPatterns.Behavioral.ChainOfResponsibility;
using DesignPatterns.Behavioral.Command;
using DesignPatterns.Behavioral.Interpreter;
using DesignPatterns.Behavioral.Iterator;
using DesignPatterns.Behavioral.Mediator;
using DesignPatterns.Behavioral.Observer;
using DesignPatterns.Behavioral.State;
using DesignPatterns.Behavioral.Strategy;
using DesignPatterns.Behavioral.Strategy.TravelStrategies;
using DesignPatterns.Behavioral.TemplateMethod;
using DesignPatterns.Creational.AbstractFactory;
using DesignPatterns.Creational.AbstractFactory.ConcreteFactory;
using DesignPatterns.Creational.Builder;
using DesignPatterns.Creational.Factory;
using DesignPatterns.Creational.Prototype;
using DesignPatterns.Creational.Singleton;
using DesignPatterns.Structural.Adapter;
using DesignPatterns.Structural.Bridge;
using DesignPatterns.Structural.Bridge.Discounts;
using DesignPatterns.Structural.Bridge.Insurances;
using DesignPatterns.Structural.Composite;
using DesignPatterns.Structural.Decorator;
using DesignPatterns.Structural.Facade;
using DesignPatterns.Structural.Flyweight;
using DesignPatterns.Structural.Proxy;
using System.Text.RegularExpressions;
using static DesignPatterns.Creational.Builder.User;



void Title(string title, ConsoleColor color)
{
    var prevBackgroundColor = Console.BackgroundColor;
    var prevForegroundColor = Console.ForegroundColor;
    Console.ForegroundColor = color;
    Console.WriteLine("\n" + new string('-', 100));
    Console.ForegroundColor = prevForegroundColor;
    Console.BackgroundColor = color;
    if (color == ConsoleColor.Yellow)
       Console.ForegroundColor = ConsoleColor.Black;
    Console.WriteLine($"{title}");
    Console.ForegroundColor = prevForegroundColor;
    Console.BackgroundColor = prevBackgroundColor;
}

#region Singleton
Title("S I N G L E T O N", ConsoleColor.Red);

Thread t1 = new(() =>
{
    var instance = UploadService.Instance();
});

Thread t2 = new(() =>
{
    var instance = UploadService.Instance();
});

t1.Start();
t2.Start();

t1.Join();
t2.Join();
#endregion

#region Factory Method

Title("F A C T O R Y   M E T H O D", ConsoleColor.Red);

IPayment payment = PaymentFactory.Create(PaymentMethod.CeditCard);
payment.Pay(1000);
#endregion

#region Abstract Factory Method
Title("A B S T R A C T   F A C T O R Y   M E T H O D", ConsoleColor.Red);

IInternationalFactory factory = new EnglandFactory();
ILanguage language = factory.CreateLanguage();
ICapitalCity capitalCity = factory.CreateCapital();

language.Greet();
Console.WriteLine($"Total population: {capitalCity.GetPolulation()}");
Console.WriteLine($"Top Attractions: {string.Join(", ", capitalCity.ListTopAttractions())}");

Console.WriteLine();
factory = new SpainFactory();
language = factory.CreateLanguage();
capitalCity = factory.CreateCapital();

language.Greet();
Console.WriteLine($"Total population: {capitalCity.GetPolulation()}");
Console.WriteLine($"Top Attractions: {string.Join(", ", capitalCity.ListTopAttractions())}");

Console.WriteLine("\n");
Console.WriteLine("PROVIDER:");


// Ugyanez, csak provider-rel használva
Country country = Country.ENGLAND;
InternationalProvider.CreateLanguage(country).Greet();
Console.WriteLine($"Total population: {InternationalProvider.CreateCapitalCity(country).GetPolulation()}");
Console.WriteLine($"Top Attractions: {string.Join(", ", InternationalProvider.CreateCapitalCity(country).ListTopAttractions())}");

Console.WriteLine();
country = Country.SPAIN;
InternationalProvider.CreateLanguage(country).Greet();
Console.WriteLine($"Total population: {InternationalProvider.CreateCapitalCity(country).GetPolulation()}");
Console.WriteLine($"Top Attractions: {string.Join(", ", InternationalProvider.CreateCapitalCity(country).ListTopAttractions())}");

#endregion

#region Builder

Title("B U I L D E R", ConsoleColor.Red);

User user = new UserBuilder()
    .WithName("Teszt Elek")
    .WithAge(33)
    .WithAddress("1111 Budapest Bocskai út 1.")
    .Build();

Console.WriteLine($"Name: {user.Name}");
Console.WriteLine($"Age: {user.Age}");
Console.WriteLine($"Address: {user.Address}");
#endregion

#region Prototype
Title("P R O T O T Y P E", ConsoleColor.Red);

Teacher teacher = new Teacher("Sean", "Creational Design Patterns in C#");
Teacher teacherClone = (Teacher)teacher.Clone();

Console.WriteLine($"Teacher was cloned: {teacherClone.Name} who teaches {teacherClone.Course}");

Student student = new Student("James", teacherClone);
Student studentClone = (Student)student.Clone();

Console.WriteLine($"Student was cloned: {studentClone.Name} who is enrolled with {studentClone.Teacher.Name}'s course.");

// Change the name of the teacher, dep copy-nak utána nézni, hogy ez hogy is működik
teacherClone.Name = "John";
Console.WriteLine($"Student was cloned: {studentClone.Name} who is enrolled with {studentClone.Teacher.Name}'s course.");
#endregion

#region Adapter
Title("A D A P T E R", ConsoleColor.Blue);

//Legacy xml serialization
string someXml = @"<?xml version='1.0' encoding='UTF-8' standalone='yes'?>
                    <note>
                        <to>John</to>
                        <from>Jane</from>
                        <heading>Reminder</heading>
                        <body>Remember to pick me up at work!</body>
                    </note>";

IXmlParser<Note> parser = new XmlParser<Note>();
Note note = parser.Parse(someXml);
Console.WriteLine("XML parse:");
Console.WriteLine(parser.ConverToXml(note));
Console.WriteLine("\n");

Console.WriteLine("XML to Json parse:");
IJsonParser<Note> jsonParser = new XmlToJsonAdapter<Note>();
note = jsonParser.Parse(someXml);
Console.WriteLine(jsonParser.ConvertToJson(note));



#endregion

#region Bridge
Title("B R I D G E", ConsoleColor.Blue);

Discount safeDiscount = new SafeDriverDiscount();
CarInsurance comp1 = new Comprehensive(2023, "Mercedes-Benz", "E-class", safeDiscount);
CarInsurance thirdParty1 = new ThirdParty(2023, "VW", "Tiguan", safeDiscount);
CarInsurance propDamage1 = new PropertyDamage(2023, "Cadillac", "Escalade", safeDiscount);
Console.WriteLine("Safe Driver Discount:");
Console.WriteLine("---------------------");
Print(comp1);
Print(thirdParty1);
Print(propDamage1);

Discount noClaimsDiscount = new NoClaimsDiscount();
CarInsurance comp2 = new Comprehensive(2023, "Mercedes-Benz", "E-Class", noClaimsDiscount);
CarInsurance thirdParty2 = new ThirdParty(2023, "VW", "Tiguan", noClaimsDiscount);
CarInsurance propDamage2 = new PropertyDamage(2023, "Cadillac", "Escalade", noClaimsDiscount);
Console.WriteLine("\nNo Claims Discounts:");
Console.WriteLine("--------------------");
Print(comp2);
Print(thirdParty2);
Print(propDamage2);

Discount autoOwnersDiscount = new AutoOwnersDiscount();
CarInsurance comp3 = new Comprehensive(2023, "Mercedes-Benz", "E-Class", autoOwnersDiscount);
CarInsurance thirdParty3 = new ThirdParty(2023, "VW", "Tiguan", autoOwnersDiscount);
CarInsurance propDamage3 = new PropertyDamage(2023, "Cadillac", "Escalade", autoOwnersDiscount);
Console.WriteLine("\nAuto Owners Discounts:");
Console.WriteLine("----------------------");
Print(comp3);
Print(thirdParty3);
Print(propDamage3);

static void Print(CarInsurance carInsurance)
{
    Console.WriteLine($"{PascalCaseToSentence(carInsurance.GetType().Name)} Premium: {carInsurance.Year} {carInsurance.Make} {carInsurance.Model} @ ${carInsurance.CalculatePremium():f2} p/m");
}

static string PascalCaseToSentence(string input)
{
    return Regex.Replace(input, "(\\B[A-Z])", " $1").Trim();
}
#endregion

#region Composite
Title("C O M P O S I T E", ConsoleColor.Blue);

GitComponent mainBranch = new Branch("main");
GitComponent commitToMain1 = new Commit("82a79d4");
GitComponent commitToMain2 = new Commit("dk4k35d");
GitComponent commitToMain3 = new Commit("d5fh64d");
GitComponent commitToMain4 = new Commit("ir5i44s");

// Commitokat adunk hozzá
mainBranch.Add(commitToMain1);
mainBranch.Add(commitToMain2);
mainBranch.Add(commitToMain3);
mainBranch.Add(commitToMain4);
mainBranch.Remove(commitToMain3);

// Leágazó branch-et adunk hozzá a main branch-hez
GitComponent smallFeature = new Branch("small-feature");
mainBranch.Add(smallFeature);

// Small feature branch-hez adunk commit-ot
GitComponent commitToSmallFeature1 = new Commit("55fab54");
smallFeature.Add(commitToSmallFeature1);

// Másik leágazó brachet adunk hozzá a main branch-hez
GitComponent bigFeature = new Branch("big-feature");
mainBranch.Add(bigFeature);

// Big feature-höz adunk commitokat
GitComponent commitToBigFeature1 = new Commit("ff46gfd");
GitComponent commitToBigFeature2 = new Commit("5jdfhj6");
GitComponent commitToBigFeature3 = new Commit("d5k767f");
GitComponent commitToBigFeature4 = new Commit("2j8lfe8");
GitComponent commitToBigFeature5 = new Commit("d6gg66j");
GitComponent commitToBigFeature6 = new Commit("f3gj556");

bigFeature.Add(commitToBigFeature1);
bigFeature.Add(commitToBigFeature2);
bigFeature.Add(commitToBigFeature3);
bigFeature.Add(commitToBigFeature4);
bigFeature.Add(commitToBigFeature5);
bigFeature.Add(commitToBigFeature6);

Console.WriteLine("Small feature commit history:");
Console.WriteLine("-----------------------------");
smallFeature.ShowDetailes();

Console.WriteLine("\nBig feature commit history:");
Console.WriteLine("-----------------------------");
bigFeature.ShowDetailes();

Console.WriteLine("\nSmall feature commit history:");
Console.WriteLine("-----------------------------");
smallFeature.ShowDetailes();

Console.WriteLine("\nFull commit history:");
Console.WriteLine("-----------------------------");
mainBranch.ShowDetailes();
#endregion

#region Decorator
Title("D E C O R A T O R", ConsoleColor.Blue);

IPizza pizza = new Pizza();
IPizza cheeseDecorator = new CheeseDecorator(pizza);
IPizza tomatoDecorator = new TomatoDecorator(pizza);
IPizza onionDecorator = new OnionDecorator(pizza);
Console.WriteLine(pizza.GetPizzaType());
Console.WriteLine(cheeseDecorator.GetPizzaType());
Console.WriteLine(tomatoDecorator.GetPizzaType());
Console.WriteLine(onionDecorator.GetPizzaType());

#endregion

#region Facade
Title("F A C A D E", ConsoleColor.Blue);

NetworkFacade networkFacade = new NetworkFacade("8.8.8.8", "UDP");

networkFacade.BuildNetworkLayer();
networkFacade.SendPacketOverNetwork();
#endregion

#region Flyweight
// https://refactoring.guru/design-patterns/flyweight/csharp/example
Title("F L Y W E I G H T", ConsoleColor.Blue);

// The client code usually creates a bunch of pre-populated
// flyweights in the initialization stage of the application.
var flyweightFactory = new FlyweightFactory(
    new Car { Company = "Chevrolet", Model = "Camaro2018", Color = "pink" },
    new Car { Company = "Mercedes Benz", Model = "C300", Color = "black" },
    new Car { Company = "Mercedes Benz", Model = "C500", Color = "red" },
    new Car { Company = "BMW", Model = "M5", Color = "red" },
    new Car { Company = "BMW", Model = "X6", Color = "white" }
);

flyweightFactory.ListFlyweights();

addCarToPoliceDatabase(flyweightFactory, new Car
{
    Number = "CL234IR",
    Owner = "James Doe",
    Company = "BMW",
    Model = "M5",
    Color = "red"
});

addCarToPoliceDatabase(flyweightFactory, new Car
{
    Number = "CL234IR",
    Owner = "James Doe",
    Company = "BMW",
    Model = "X1",
    Color = "red"
});

flyweightFactory.ListFlyweights();

void addCarToPoliceDatabase(FlyweightFactory factory, Car car)
{
    Console.WriteLine("\nClient: Adding a car to database.");

    var flyweight = factory.GetFlyweight(new Car
    {
        Color = car.Color,
        Model = car.Model,
        Company = car.Company
    });

    // The client code either stores or calculates extrinsic state and
    // passes it to the flyweight's methods.
    flyweight.Operation(car);
}
#endregion

#region Proxy
Title("P R O X Y", ConsoleColor.Blue);

IService concreteService = new ConcreteService();
IService proxy = new Proxy(concreteService);

concreteService.Login(15);
proxy.Login(15);

concreteService.Login(18);
proxy.Login(18);
#endregion

#region Chain of responsibility
Title("C H A I N   O F   R E S P O N S I B I L I T Y", ConsoleColor.Yellow);

IManager manager = new SeniorManager();
IManager vicePresident = new VicePresident();
IManager ceo = new CEO();

manager.SetSupervisor(vicePresident);
vicePresident.SetSupervisor(ceo);

var expense = new ExpenseReport("Monitor", 100);
Console.WriteLine(expense);
manager.ApproveRequest(expense);
Console.WriteLine("\n");

expense = new ExpenseReport("Desk", 900);
Console.WriteLine(expense);
manager.ApproveRequest(expense);
Console.WriteLine("\n");

expense = new ExpenseReport("Travel", 4500);
Console.WriteLine(expense);
manager.ApproveRequest(expense);
Console.WriteLine("\n");

expense = new ExpenseReport("Car", 9000);
Console.WriteLine(expense);
manager.ApproveRequest(expense);
Console.WriteLine("\n");
#endregion

#region Command
Title("C O M M A N D", ConsoleColor.Yellow);

Light light = new Light();                      // Receiver
ICommand lightOn = new LightOnCommand(light);   // Command ON
ICommand lightOff = new LightOffCommand(light); // Command OFF
RemoteControl remote = new RemoteControl();     // Invoker

remote.SetCommand(lightOn);
remote.PressButton();

remote.SetCommand(lightOff);
remote.PressButton();
#endregion

#region Interpreter
Title("I N T E R P R E T E R", ConsoleColor.Yellow);

string input = "1+7-5";
int result = new Context().InsertExpression(input);
Console.WriteLine($"{input} = {result}");
#endregion

#region Iterator
Title("I T E R A T O R", ConsoleColor.Yellow);

Collection collection = new Collection();
for (int i = 0; i < 8; i++)
{
    collection[i] = new Item($"Item {i}");

}

Iterator iterator = collection.CreateIterator();

iterator.Step = 2;

Console.WriteLine("Iterating over collection:");


while (!iterator.IsDone)
{
    Console.WriteLine(iterator.CurrentItem.Name);
    iterator.Next();
}
#endregion

#region Mediator
Title("M E D I A T O R", ConsoleColor.Yellow);

Chatroom chatroom = new Chatroom();

Participant george = new Beatle("George");
Participant paul = new Beatle("Paul");
Participant ringo = new Beatle("Ringo");
Participant john = new Beatle("John");
Participant yoko = new NonBeatle("Yoko");

chatroom.Register(george);
chatroom.Register(paul);
chatroom.Register(ringo);
chatroom.Register(john);
chatroom.Register(yoko);

yoko.Send("John", "Hi John!");
paul.Send("Ringo", "All you need is love");
ringo.Send("George", "My sweet Lord");
paul.Send("John", "Can't buy me love");
john.Send("Yoko", "My sweet love");
#endregion

#region Observer
Title("O B S E R V E R", ConsoleColor.Yellow);

WeatherStation weatherStation = new WeatherStation();
NewsAgency agency1 = new NewsAgency("Alpha New Agency");
NewsAgency agency2 = new NewsAgency("Omega New Agency");
weatherStation.Attach(agency1);
weatherStation.Attach(agency2);

weatherStation.Tempreature = 31.2f;
weatherStation.Tempreature = 28.7f;
weatherStation.Tempreature = 25.6f;
weatherStation.Tempreature = 30.8f;

#endregion

#region State
Title("S T A T E", ConsoleColor.Yellow);
Caar car = new Caar();

Console.WriteLine($"State: {car.CurrentState}");

car.TakeAction(Caar.Action.Start);
Console.WriteLine($"State: {car.CurrentState}");

car.TakeAction(Caar.Action.Start);
Console.WriteLine($"State: {car.CurrentState}");

car.TakeAction(Caar.Action.Accelerate);
Console.WriteLine($"State: {car.CurrentState}");

car.TakeAction(Caar.Action.Stop);
Console.WriteLine($"State: {car.CurrentState}");

#endregion

#region Strategy
Title("S T R A T E G Y", ConsoleColor.Yellow);

TavelPlanner travelPlanner = new TavelPlanner();

travelPlanner.SetTravelStrategy(new Caaar());
Console.Write("CAR\t");
travelPlanner.Drive(1100);

Console.Write("BUS\t");
travelPlanner.SetTravelStrategy(new Bus());
travelPlanner.Drive(1100);

Console.Write("PLANE\t");
travelPlanner.SetTravelStrategy(new Plane());
travelPlanner.Drive(1100);

#endregion

#region TemplateMethod
Title("T E M P L A T E   M E T H O D", ConsoleColor.Yellow);

BuildProject buildProject = new BuildProject();
Console.WriteLine();
BuildProjectOnStaging buildProjectOnStaging = new BuildProjectOnStaging();

#endregion