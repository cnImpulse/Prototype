//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using Bright.Serialization;
using System.Collections.Generic;


namespace Cfg.Effect
{
   
public partial class TbEffect
{

     private readonly Effect.EffectRes _data;

    public TbEffect(ByteBuf _buf)
    {
        int n = _buf.ReadSize();
        if (n != 1) throw new SerializationException("table mode=one, but size != 1");
        _data = Effect.EffectRes.DeserializeEffectRes(_buf);
        PostInit();
    }


    /// <summary>
    /// 选择特效
    /// </summary>
     public string Select => _data.Select;
    /// <summary>
    /// 攻击特效
    /// </summary>
     public string Attack => _data.Attack;

    public void Resolve(Dictionary<string, object> _tables)
    {
        _data.Resolve(_tables);
        PostResolve();
    }

    public void TranslateText(System.Func<string, string, string> translator)
    {
        _data.TranslateText(translator);
    }

    
    partial void PostInit();
    partial void PostResolve();
}

}