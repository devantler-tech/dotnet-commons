using System.ComponentModel;
using System.Runtime.Serialization;

namespace Devantler.Commons.Extensions.Tests.EnumExtensionsTests;

enum TestEnum
{
  [Description("First Value - Description")]
  [EnumMember(Value = "First Value - Enum Member")]
  FirstValue,

  SecondValue
}
