using System.ComponentModel;

namespace Articles.Abstractions.Enums;

public enum ArticleStage : int
{
    None = 0,

    //Submission
    [Description("The Author created the Article")]
    Created = 101,
}