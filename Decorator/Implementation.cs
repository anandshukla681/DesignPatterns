using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator
{
    public interface IMailService
    {
        bool SendMail(string message);
    }

    public class CloudSendMail : IMailService
    {
        public CloudSendMail() { }
        public bool SendMail(string message) { return true; }
    }

    public class OnPremisesSendMail : IMailService
    {
        public bool SendMail(string message)
        {
            return true;
        }
    }

    public abstract class MailDecoratorBase : IMailService
    {
        IMailService _mailService;
        public MailDecoratorBase(IMailService mailService)
        {
            _mailService = mailService;
        }
        public virtual bool SendMail(string message)
        {
            return _mailService.SendMail(message);
        }
    }

    public class StatisticsMailDecorator : MailDecoratorBase
    {
        public StatisticsMailDecorator(IMailService mailService) : base(mailService)
        {
        }

        public override bool SendMail(string message)
        {
            Console.WriteLine($"Statistics collection");
            return base.SendMail(message);
        }
    }


}
