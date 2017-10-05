using NamingIsHard_Code.IntentfulNamingDemo;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NamingIsHard_Code.Naming_Intent
{
    public class CodeWithMoreIntent : ApiController
    {
        HttpUtility _httpUtility = new HttpUtility();
        GenericRepository _genericRepository = new GenericRepository();
        AdobeSignLogic _adobeSignLogic = new AdobeSignLogic();

        [HttpGet]
        public void ProcessDocuments()
        {
            var userId = _httpUtility.GetAuthenticatedUserId(Request);
            var user = _genericRepository.GetById<User>(userId);
            
            var agreementId = user.ESignatureDocuments.First(x => x.IsNotSigned).AgreementId;
            _adobeSignLogic.MinimalProcess(user, agreementId);

            var appsWithDocumentationStep = user.Applications
                .Where(a => a.Steps.Any(s => s.StepType == StepType.Documentation))
                .ToList();
            
            Step documentationStep = null;
            foreach (var app in appsWithDocumentationStep)
            {
                documentationStep = app.Steps.First(s => s.StepType == StepType.Documentation);
                if (!documentationStep.Complete)
                {
                    documentationStep.Complete = true;
                    UpdateApplicationStatusAndTimes(app, documentationStep);
                }
            }
                        
            _adobeSignLogic.SaveAdobeSignFields(user);
        }

        private void UpdateApplicationStatusAndTimes(Application application, Step step)
        {
            //Updates the passed in application status & time
        }
    }

    #region DependencyCode
    internal class AdobeSignLogic
    {
        internal void MinimalProcess(User user, Guid agreementId)
        {
            throw new NotImplementedException();
        }

        internal void SaveAdobeSignFields(User user)
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
        public StepType StepType { get; internal set; }

        public bool Complete { get; set; }
    }

    internal enum StepType
    {
        Documentation = 1
    }

    internal class HttpUtility
    {

        internal int GetAuthenticatedUserId(object request)
        {
            throw new NotImplementedException();
        }
    }

    internal class GenericRepository
    {
        internal T GetById<T>(int userId)
        {
            throw new NotImplementedException();
        }
    }
    #endregion
}