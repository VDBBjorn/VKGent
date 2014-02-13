using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using p2g33_web.Models.Domain;

namespace p2g33_web.Models.ViewModels
{
    public class EvaluationFormViewModel
    {
        public EvaluationFormViewModel()
        {
            
        }
        
        public EvaluationFormViewModel(Evaluation evaluation, LearningProcess lp)
        {
            LearningProcessCode = lp.learningProcessCode;
        }

        [DisplayName("Ik heb achtergrondInformatie gekregen")]
        [Range(1,5,ErrorMessage = "Gelieve voor \"{0}\" een optie te kiezen")]
        public int BackgroundInformation { get; set; }
        [DisplayName("Ik kan de  achtergrondinformatie gebruiken in mijn werksituatie")]
        [Range(1, 5, ErrorMessage = "Gelieve voor \"{0}\" een optie te kiezen")]
        public int UsefulBackgroundInformation { get; set; }
        [DisplayName("Ik heb praktijkvoorbeelden gekregen")]
        [Range(1, 5, ErrorMessage = "Gelieve voor \"{0}\" een optie te kiezen")]
        public int PracticeExamples { get; set; }
        [DisplayName("Ik kan de praktijkvoorbeelden toepassen in mijn werksituatie")]
        [Range(1, 5, ErrorMessage = "Gelieve voor \"{0}\" een optie te kiezen")]
        public int UsefulPracticeExamples { get; set; }
        [DisplayName("De inhoud van de vorming voldoet aan mijn verwachtingen")]
        [Range(1, 5, ErrorMessage = "Gelieve voor \"{0}\" een optie te kiezen")]
        public int ContentExpectation { get; set; }

        [DisplayName("Opmerking i.v.m. opleiding")]
        public string RemarksFormation { get; set; }


        [DisplayName("Het leerplatform is een goede voorbereiding voor  het persoonlijk vormingsmoment")]
        [Range(1, 5, ErrorMessage = "Gelieve voor \"{0}\" een optie te kiezen")]
        public int PreperationLearningPlatform { get; set; }
        [DisplayName("De presentatiewijze van het leerplatform spreekt aan")]
        [Range(1, 5, ErrorMessage = "Gelieve voor \"{0}\" een optie te kiezen")]
        public int PresentationLearningPlatform { get; set; }
        [DisplayName("Het leerplatform biedt duidelijke informatie")]
        [Range(1, 5, ErrorMessage = "Gelieve voor \"{0}\" een optie te kiezen")]
        public int ContentLearningPlatform { get; set; }
        [DisplayName("Het leerplatform is gebruiksvriendelijk")]
        [Range(1, 5, ErrorMessage = "Gelieve voor \"{0}\" een optie te kiezen")]
        public int UsefulLearningPlatform { get; set; }

        [DisplayName("Opmerking i.v.m. leerplatform")]
        public string RemarksLearningPlatform { get; set; }
        

        [DisplayName("De informatie wordt duidelijk gebracht")]
        [Range(1, 5, ErrorMessage = "Gelieve voor \"{0}\" een optie te kiezen")]
        public int ClearInformation { get; set; }
        [DisplayName("De presentatiewijze spreekt aan")]
        [Range(1, 5, ErrorMessage = "Gelieve voor \"{0}\" een optie te kiezen")]
        public int ClearPresentation { get; set; }
        [DisplayName("De begeleider gaat gepast in op vragen van de groep")]
        [Range(1, 5, ErrorMessage = "Gelieve voor \"{0}\" een optie te kiezen")]
        public int QuestionsMentor { get; set; }
        [DisplayName("De manier waarop de vorming gebracht werd voldoet aan mijn verwachtingen")]
        [Range(1, 5, ErrorMessage = "Gelieve voor \"{0}\" een optie te kiezen")]
        public int FormationManner { get; set; }
        
        [DisplayName("Opmerking i.v.m. opleider")]
        public string RemarksMentor { get; set; }

        [DisplayName("Andere opmerkingen of suggesties")]
        public string GeneralRemark { get; set; }

        [DisplayName("Gemist tijdens de vorming")]
        public string MissedInFormation { get; set; }

        public string LearningProcessCode { get; set; }
    }
   

}