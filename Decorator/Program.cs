using Decorator;

Console.Title = "Decorator";

var statisticDecorator = new StatisticsMailDecorator(new OnPremisesSendMail());
statisticDecorator.SendMail("Hello");
Console.ReadKey();