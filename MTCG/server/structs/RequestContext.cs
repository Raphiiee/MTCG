using MTCG.server.enums;

namespace MTCG.DB.structs
{
    public struct RequestContext
    {
        public string Header;
        public string Version;
        public AllowedMethods Method;
        public AllowedPaths Path;
        public string Message;
    }
}