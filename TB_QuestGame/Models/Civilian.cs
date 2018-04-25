using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TB_QuestGame
{
    class Civilian : Npc, ISpeak
    {
        public override int Id { get; set; }
        public override string Description { get; set; }
        public List<string> Messages { get; set; }
        public int healing { get; set; }
        public string Speak()
        {
            if(this.Messages != null)
            {
                return GetMessage();
                
            }
            else
            {
                return $"My name is {this.Name}";
            }
        } 

        private string GetMessage()
        {
            Random R = new Random();
            int messageIndex = R.Next(0, Messages.Count());
            return Messages[messageIndex];
        }

    }
}
