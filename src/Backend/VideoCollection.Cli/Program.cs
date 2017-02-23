using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using MediatR;
using static System.Console;
using static VideoCollection.Cli.Commands.Videos.ListAllVideosCommand;
using static VideoCollection.Cli.Commands.MainMenuCommand;

namespace VideoCollection.Cli
{
    public class Program
    {
        private readonly IUnityContainer _container;
        private readonly Dictionary<string, Func<string[], dynamic>> _commands;
        
        public Program(IRequestFactory requestFactory, IMediator mediator)
        {
            _commands = new Dictionary<string, Func<string[], dynamic>>
            {
                ["all-videos"] = args => mediator.Send(requestFactory.MakeRequest<ListAllVideosRequest,ListAllVideosResponse>(args)),
                ["main-menu"] = args => mediator.Send(requestFactory.MakeRequest<MainMenuRequest, MainMenuResponse>(args))
            };
        }

        static void Main(string[] args)
        {
            UnityConfiguration.GetContainer().Resolve<Program>().ProcessArgs(args);
        }
        
        public int ProcessArgs(string[] args)
        {
            bool? verbose = null;
            var success = true;
            var command = "main-menu";
            var lastArg = 0;
            for (; lastArg < args.Length; lastArg++)
            {
                if (IsArg(args[lastArg], "version"))
                {
                    //HelpCommand.PrintVersionHeader();
                    return 0;
                }
                else if (IsArg(args[lastArg], "h", "help"))
                {
                    //HelpCommand.PrintHelp();
                    return 0;
                }
                else if (args[lastArg].StartsWith("-"))
                {
                    WriteLine($"Unknown option: {args[lastArg]}");
                    success = false;
                }
                else
                {
                    command = args[lastArg];
                    break;
                }
            }

            var appArgs = (lastArg + 1) >= args.Length ? Enumerable.Empty<string>() : args.Skip(lastArg + 1).ToArray();

            int exitCode;
            Func<string[], dynamic> builtIn;
            if (_commands.TryGetValue(command, out builtIn))
            {
                builtIn(appArgs.ToArray());
            }
            
            return 0;
        }

        private static bool IsArg(string candidate, string longName) => IsArg(candidate, shortName: null, longName: longName);

        private static bool IsArg(string candidate, string shortName, string longName)
        {
            return (shortName != null && candidate.Equals("-" + shortName)) || (longName != null && candidate.Equals("--" + longName));
        }
    }
}
