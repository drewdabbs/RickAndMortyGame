using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RickAndMortyGame
{
    public enum EventType { Get, Use }
    public enum ResultType { NewExit, GetItem, GetMorty, MessageOnly }
    public class Event
    // EFA -- Only a slight bug or so in Module 3.1. Making a new class named 'Events.cs' auto-names the class here to Events. It is referenced as 'Events' creating bugs. Also, the module instructs to make an enum in the class, instead of in the namespace.
    {
        public EventType Type;
        public string TriggerPhrase;
        public Result EventResult;

        public Event(string triggerPhrase, EventType type, Result eventResult)
        {
            TriggerPhrase = triggerPhrase;
            Type = type;
            EventResult = eventResult;
        }
    }
    
    public class Result
    {
        public ResultType Type { get; }

        public string ResultExit { get; }
        public Item ResultItem { get; }
        public Mortys.IMorty ResultMorty { get; }
        // EFA -- As written in module 3.1 this produces an error since 'IMorty' is in the folder 'Mortys'
        public string ResultMessage { get; }

        public Result(string resultExit, string resultMessage)
        {
            Type = ResultType.NewExit;
            ResultExit = resultExit;
            ResultMessage = resultMessage;
        }
        public Result(Item resultItem, string resultMessage)
        {
            Type = ResultType.GetItem;
            ResultItem = resultItem;
            ResultMessage = resultMessage;
        }
        public Result(Mortys.IMorty resultMorty, string resultMessage)
            // EFA -- As above, the 3.1 module skips over the folder.
        {
            Type = ResultType.GetMorty;
            ResultMorty = resultMorty;
            ResultMessage = resultMessage;
        }
        public Result(string resultMessage)
        {
            Type = ResultType.MessageOnly;
            ResultMessage = resultMessage;
        }
    }

}
