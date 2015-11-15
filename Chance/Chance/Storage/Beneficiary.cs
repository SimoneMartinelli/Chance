using System.Web.Services.Description;

namespace Chance.Storage
{
    public class Beneficiary : IStorable
    {
        public string Name;

        public Beneficiary(string name, int id, string code, string imgPath, string message)
        {
            Name = name;
            Code = code;
            Id = id;
            ImgPath = imgPath;
            Message = message;
        }

        public string Code { get; private set; }
        public int Id{ get; set; }
        public string ImgPath { get; set; }
        public string Message { get; set; }
    }
}