using AutoFixture;
using AutoFixture.Xunit2;
using DevantlerTech.Commons.Extensions.Tests.Setup.SpecimenBuilders;

namespace DevantlerTech.Commons.Extensions.Tests.Setup.AutoDataAttributes;

/// <summary>
/// An auto data attribute that generates negative integers.
/// </summary>
sealed class NegativeIntegerAutoDataAttribute : AutoDataAttribute
{
  /// <summary>
  /// Creates a new instance of the <see cref="NegativeIntegerAutoDataAttribute"/> class.
  /// </summary>
  public NegativeIntegerAutoDataAttribute() : base(() =>
  {
    var fixture = new Fixture();
    fixture.Customizations.Add(new NegativeIntegerSpecimenBuilder());
    return fixture;
  })
  {
  }
}
