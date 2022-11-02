using Essity.FutureProof.Infrastructure.Entities;

namespace Essity.FutureProof.Infrastructure.Migrations
{
    public static class Initialize
    {
        public static void Seed(this DataContext context)
        {
            context.Database.EnsureCreated();

            // --step 1: insert types
            // insert into ubconsenttypes(code, description)
            UbConsentType? optinType = context.UbConsentTypes.FirstOrDefault(t => t.Code == "OPTIN");
            UbConsentType? tosType = context.UbConsentTypes.FirstOrDefault(t => t.Code == "TOS");
            UbConsentType? contestType = context.UbConsentTypes.FirstOrDefault(t => t.Code == "CONTEST");

            // values('TOS', 'Terms of service'),
            //  ('OPTIN', 'Opt in')
            if (tosType == null)
            {
                tosType = new UbConsentType() { Code = "TOS", Description = "Terms of service" };
                context.UbConsentTypes.Add(tosType);
            }

            if (optinType == null)
            {
                optinType = new UbConsentType() { Code = "OPTIN", Description = "Opt in" };
                context.UbConsentTypes.Add(optinType);
            }

            if (contestType == null)
            {
                contestType = new UbConsentType() { Code = "CONTEST", Description = "Contest Rules" };
                context.UbConsentTypes.Add(contestType);
            }

            context.SaveChanges();
            optinType = context.UbConsentTypes.FirstOrDefault(t => t.Code == "OPTIN");
            tosType = context.UbConsentTypes.FirstOrDefault(t => t.Code == "TOS");

            UbConsent? newsLetterOptinConsent = context.UbConsents.FirstOrDefault(t => t.Source == "NEWSLETTER" && t.Title == "NewsLetter");
            UbConsent? newsLetterTOSConsent = context.UbConsents.FirstOrDefault(t => t.Source == "NEWSLETTER" && t.Title == "Terms of Service");

            if (newsLetterOptinConsent == null && optinType != null)
            {
                newsLetterOptinConsent = new UbConsent() { TypeId = optinType.Id, Source = "NEWSLETTER", Title = "NewsLetter", Description = "NewsLetter", DateCreated = DateTime.Now };
                context.UbConsents.Add(newsLetterOptinConsent);
            }

            if (newsLetterTOSConsent == null && tosType != null)
            {
                newsLetterTOSConsent = new UbConsent() { TypeId = tosType.Id, Source = "NEWSLETTER", Title = tosType.Description, Description = tosType.Description, DateCreated = DateTime.Now };
                context.UbConsents.Add(newsLetterTOSConsent);
            }

            context.SaveChanges();

            UbConsent? downloadTOSConsent = context.UbConsents.FirstOrDefault(t => t.Source == "DOWNLOADS" && t.Title == "Terms of Service");
            UbConsent? contactTOSConsent = context.UbConsents.FirstOrDefault(t => t.Source == "CONTACT" && t.Title == "Terms of Service");
            UbConsent? contactNewsletterConsent = context.UbConsents.FirstOrDefault(t => t.Source == "CONTACT" && t.Title == "NewsLetter");
            UbConsent? contestNewsLetterConsent = context.UbConsents.FirstOrDefault(t => t.Source == "CONTEST" && t.Title == "NewsLetter");
            UbConsent? contestTOSConsent = context.UbConsents.FirstOrDefault(t => t.Source == "CONTEST" && t.Title == "Terms of Service");
            UbConsent? contestConsent = context.UbConsents.FirstOrDefault(t => t.Source == "CONTEST" && t.Title == "Contest Rules");
            UbConsent? reviewNewsLetterConsent = context.UbConsents.FirstOrDefault(t => t.Source == "REVIEW" && t.Title == "NewsLetter");
            UbConsent? reviewTOSConsent = context.UbConsents.FirstOrDefault(t => t.Source == "REVIEW" && t.Title == "Terms of Service");
            UbConsent? eqSurveyNewsLetterConsent = context.UbConsents.FirstOrDefault(t => t.Source == "EQUALITYSURVEY" && t.Title == "NewsLetter");
            UbConsent? eqSurveyTOSConsent = context.UbConsents.FirstOrDefault(t => t.Source == "EQUALITYSURVEY" && t.Title == "Terms of Service");

            if (downloadTOSConsent == null && tosType != null)
            {
                downloadTOSConsent = new UbConsent() { TypeId = tosType.Id, Source = "DOWNLOADS", Title = "Terms of Service", Description = "Terms of Service", DateCreated = DateTime.Now };
                context.UbConsents.Add(downloadTOSConsent);
            }

            if (contactTOSConsent == null && tosType != null)
            {
                contactTOSConsent = new UbConsent() { TypeId = tosType.Id, Source = "CONTACT", Title = "Terms of Service", Description = "Terms of Service", DateCreated = DateTime.Now };
                context.UbConsents.Add(contactTOSConsent);
            }

            if (contactNewsletterConsent == null && optinType != null)
            {
                contactNewsletterConsent = new UbConsent() { TypeId = optinType.Id, Source = "CONTACT", Title = "Newsletter", Description = "Newsletter", DateCreated = DateTime.Now };
                context.UbConsents.Add(contactNewsletterConsent);
            }

            if (contestTOSConsent == null && tosType != null)
            {
                contactTOSConsent = new UbConsent() { TypeId = tosType.Id, Source = "CONTEST", Title = "Terms of Service", Description = "Terms of Service", DateCreated = DateTime.Now };
                context.UbConsents.Add(contactTOSConsent);
            }

            if (contestNewsLetterConsent == null && optinType != null)
            {
                contactNewsletterConsent = new UbConsent() { TypeId = optinType.Id, Source = "CONTEST", Title = "Newsletter", Description = "Newsletter", DateCreated = DateTime.Now };
                context.UbConsents.Add(contactNewsletterConsent);
            }

            if (contestConsent == null)
            {
                contestConsent = new UbConsent() { TypeId = contestType.Id, Source = "CONTEST", Title = "Contest Rules", Description = "Contest Rules", DateCreated = DateTime.Now };
                context.UbConsents.Add(contestConsent);
            }

            if (reviewNewsLetterConsent == null && optinType != null)
            {
                reviewNewsLetterConsent = new UbConsent() { TypeId = optinType.Id, Source = "REVIEW", Title = "Newsletter", Description = "Newsletter", DateCreated = DateTime.Now };
                context.UbConsents.Add(reviewNewsLetterConsent);
            }

            if (reviewTOSConsent == null)
            {
                reviewTOSConsent = new UbConsent() { TypeId = contestType.Id, Source = "REVIEW", Title = "Terms of Service", Description = "Terms of Service", DateCreated = DateTime.Now };
                context.UbConsents.Add(reviewTOSConsent);
            }

            if (eqSurveyNewsLetterConsent == null && optinType != null)
            {
                eqSurveyNewsLetterConsent = new UbConsent() { TypeId = optinType.Id, Source = "EQUALITYSURVEY", Title = "Newsletter", Description = "Newsletter", DateCreated = DateTime.Now };
                context.UbConsents.Add(eqSurveyNewsLetterConsent);
            }

            if (eqSurveyTOSConsent == null)
            {
                eqSurveyTOSConsent = new UbConsent() { TypeId = contestType.Id, Source = "EQUALITYSURVEY", Title = "Terms of Service", Description = "Terms of Service", DateCreated = DateTime.Now };
                context.UbConsents.Add(eqSurveyTOSConsent);
            }

            context.SaveChanges();
        }
    }
}