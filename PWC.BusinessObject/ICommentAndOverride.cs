using System.Data.SqlTypes;

namespace PWC.BusinessObject
{
    interface ICommentAndOverride
    {
        SqlDateTime DateTime { get; set; }
        SqlString Comment { get; set; }
        SqlBoolean IsOverride { get; set; }
    }
}
