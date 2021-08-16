
namespace netflixAPI.Contracts.V1
{
    public static class ApiRoutes
    {
        public const string Root = "api";

        public const string Version = "v1";

        public const string Base = Root + "/" + Version;

        public static class Program
        {
            public const string GetAll = Base + "/programs";

            public const string Update = Base + "/programs/{programId}";

            public const string Delete = Base + "/programs/{programId}";

            public const string Get = Base + "/programs/{programId}";

            public const string Create = Base + "/programs";
        }

        public static class Type
        {
            public const string GetAll = Base + "/types";

            public const string Update = Base + "/types/{typeId}";

            public const string Delete = Base + "/types/{typeId}";

            public const string Get = Base + "/types/{typeId}";

            public const string Create = Base + "/types";
        }


        public static class UserProgram
        {
            public const string GetAll = Base + "/userprg";

            public const string Update = Base + "/userprg/{userProgramId}";

            public const string Delete = Base + "/userprg/{userProgramId}";

            public const string Get = Base + "/userprg/{userProgramId}";

            public const string Create = Base + "/userprg";
        }

        public static class ProgramType
        {
            public const string GetAll = Base + "/prgType";

            public const string Update = Base + "/prgType/{prgTypeId}";

            public const string Delete = Base + "/prgType/{prgTypeId}";

            public const string Get = Base + "/prgType/{prgTypeId}";

            public const string Create = Base + "/prgType";
        }
        public static class Identity
        {
            public const string Login = Base + "/identity/login";

            public const string Register = Base + "/identity/register";

            public const string Refresh = Base + "/identity/refresh";
        }
    }
}
