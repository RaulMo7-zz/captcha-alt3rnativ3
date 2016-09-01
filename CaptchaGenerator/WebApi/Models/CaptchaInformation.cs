using System;

namespace WebApi.Models
{
    public class CaptchaInformation
    {
        public const string QUESTION_TYPE_GREATER = "GREATER";
        public const string QUESTION_TYPE_LESS = "LESS";

        public Guid Id { get; set; }
        public int[] Options { get; set; }
        public string QuestionType { get; set; }
        public string ImageBase64 { get; set; }
    }
}