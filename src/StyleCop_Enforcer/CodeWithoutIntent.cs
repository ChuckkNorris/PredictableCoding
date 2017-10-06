using NamingIsHard_Code.IntentfulNamingDemo;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NamingIsHard_Code.Naming_NoIntent
{
    public class CodeWithoutIntent : ApiController
    {
        Utility _utility = new Utility();
        Repository _repository = new Repository();
        Logic _logic = new Logic();

        [HttpGet]
        public void Process()
        {
            Step step = null;
            var userId = _utility.GetAuthenticatedUserId(Request);
            var user = _repository.GetById<User>(userId);

            var agreementId = user.ESignatureDocuments.First(x => x.IsNotSigned).AgreementId;

            _logic.MinimalProcess(user, agreementId);

            var apps = user.Applications
                .Where(a => a.Steps.Any(s => s.StepType == 1))
                .ToList();
            foreach (var app in apps)
            {
                step = app.Steps.First(s => s.StepType == 1);
                if (!step.Complete)
                {
                    step.Complete = true;
                    UpdateApplication(app, step);
                }
            }

            _logic.SaveFields(user);
        }

        private void UpdateApplication(Application application, Step step)
        {
            //Potentially large block of code we now have to read
        }
    }

    #region DependencyCode
    internal class Logic
    {
        internal void MinimalProcess(User user, Guid agreementId)
        {
            throw new NotImplementedException();
        }

        internal void SaveFields(User user)
        {

        }
    }

    internal class User
    {
        public List<ESignatureDocument> ESignatureDocuments { get; set; }

        public List<Application> Applications { get; set; }
    }

    internal class Application
    {
        public List<Step> Steps { get; set; }
    }

    internal class ESignatureDocument
    {
        public bool IsNotSigned { get; set; }
        public Guid AgreementId { get; set; }
    }

    internal class Step
    {
        public int StepType { get; internal set; }

        public bool Complete { get; set; }
    }

    internal class Utility
    {

        internal int GetAuthenticatedUserId(object request)
        {
            throw new NotImplementedException();
        }
    }

    internal class Repository
    {
        internal T GetById<T>(int userId)
        {
            throw new NotImplementedException();
        }
    }
    #endregion
}