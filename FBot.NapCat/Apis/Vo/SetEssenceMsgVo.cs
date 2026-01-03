using System.Text.Json.Serialization;
using FBot.OneBotV11.Events.Messages.Segments;

namespace FBot.NapCat.Apis.Vo;

public record SetEssenceMsgVo
{
    [JsonPropertyName("errCode")]
    public int ErrCode { get; set; }

    [JsonPropertyName("errMsg")]
    public string ErrMsg { get; set; } = null!;

    [JsonPropertyName("result")]
    public EssenceMsgResult Result { get; set; } = null!;
}

public record EssenceMsgResult
{
    [JsonPropertyName("wording")]
    public string Wording { get; set; } = null!;

    [JsonPropertyName("digestUin")]
    public string DigestUin { get; set; } = null!;

    [JsonPropertyName("digestTime")]
    public int DigestTime { get; set; }

    [JsonPropertyName("msg")]
    public EssenceMsgData Msg { get; set; } = null!;

    [JsonPropertyName("errorCode")]
    public int ErrorCode { get; set; }
}

public record EssenceMsgData
{
    [JsonPropertyName("groupCode")]
    public string GroupCode { get; set; } = null!;

    [JsonPropertyName("msgSeq")]
    public int MsgSeq { get; set; }

    [JsonPropertyName("msgRandom")]
    public int MsgRandom { get; set; }

    [JsonPropertyName("msgContent")]
    public Message MsgContent { get; set; } = null!;

    [JsonPropertyName("textSize")]
    public string TextSize { get; set; } = null!;

    [JsonPropertyName("picSize")]
    public string PicSize { get; set; } = null!;

    [JsonPropertyName("videoSize")]
    public string VideoSize { get; set; } = null!;

    [JsonPropertyName("senderUin")]
    public string SenderUin { get; set; } = null!;

    [JsonPropertyName("senderTime")]
    public int SenderTime { get; set; }

    [JsonPropertyName("addDigestUin")]
    public string AddDigestUin { get; set; } = null!;

    [JsonPropertyName("addDigestTime")]
    public int AddDigestTime { get; set; }

    [JsonPropertyName("startTime")]
    public int StartTime { get; set; }

    [JsonPropertyName("latestMsgSeq")]
    public int LatestMsgSeq { get; set; }

    [JsonPropertyName("opType")]
    public int OpType { get; set; }
}
