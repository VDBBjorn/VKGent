using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace p2g33_web.Models.Domain
{
    public class Case : Element
    {
        [DisplayName("Situatieschets")]
        public string situation { get; set; }
        public string movieFilePath { get; set; }
        [DisplayName("Vraag")]
        public virtual CaseQuestion caseQuestion { get; set; }

        public CaseQuestion GetQuestion(int id)
        {
            return GetQuestion(caseQuestion, id);
        }

        public CaseQuestion GetQuestion(CaseQuestion question, int id)
        {
            if (question != null)
            {
                if (question.caseQuestionId.Equals(id))
                {
                    return question;
                }
                if (question.CaseAnswers != null)
                {
                    foreach (var answer in question.CaseAnswers)
                    {
                        if (answer.answer != null && answer.nextQuestion != null)
                        {
                            var q = GetQuestion(answer.nextQuestion, id);
                            if (q != null)
                            {
                                return q;
                            }
                        }
                    }
                }
            }
            return null;
        }
    }
}
