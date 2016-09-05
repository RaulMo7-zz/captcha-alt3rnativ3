using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Provider.Model
{
    public class Captcha
    {
        public Guid Id { get; set; }
        public string Base64 { get; set; }
        public int[] Answers { get; set; }

        public QuestionType QuestionType { get; set; }
    }

    public enum QuestionType
    {
        Greater, Less, Sum
    }
}
